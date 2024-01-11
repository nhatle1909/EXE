﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EXE.Tools
{
    public class Authentication
    {
        private readonly IConfiguration _configuration;
        public Authentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJwtToken(string userId, float hour)
        {
            var jwtKey = _configuration["JWT:Key"];
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey ?? ""));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim("Id",userId),
        };

            var token = new JwtSecurityToken(
                _configuration["JWT:Issure"],
                _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(hour),
                signingCredentials: signingCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static string GetUserIdFromHttpContext(HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                throw new Exception("Need Authorization");
            }
            string? authorizationHeader = httpContext.Request.Headers["Authorization"];

            if (string.IsNullOrWhiteSpace(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                throw new Exception($"Invalid authorization header: {authorizationHeader}");
            }
            string jwtToken = authorizationHeader["Bearer ".Length..];
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var idClaim = token.Claims.FirstOrDefault(claim => claim.Type == "Id");
            return idClaim?.Value ?? throw new Exception($"Can not get userId from token");
        }
    }
}
