using AutoMapper;
using EXE.Interface;
using EXE.Tools;
using Models.Model;
using Models.ModelView;
using Models.Repository;

namespace EXE.Service
{

    public class TemplateService : ITemplateService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TemplateModel> _repos;
        public TemplateService(IRepository<TemplateModel> TemplateRepo, IMapper mapper)
        {

            _repos = TemplateRepo;
            _mapper = mapper;
        }
        public async Task<TemplateModel> AddOneTemplateItem(TemplateModelView TemplateModelView)
        {
            TemplateModel TemplateItem = _mapper.Map<TemplateModel>(TemplateModelView);
            TemplateItem.id = IdGenerator.GenerateID();
            return await _repos.AddOneItem(TemplateItem);
        }

        public async Task<bool> DeleteTemplateItem(string id)
        {
            return await _repos.RemoveItemByValue(id);
        }

        public async Task<IEnumerable<TemplateModel>> GetAllTemplateItem()
        {
            return await _repos.GetAllAsync();
        }

        public async Task<TemplateModel> UpdateTemplateItem(string id, TemplateModelView TemplateModelView)
        {
            TemplateModel TemplateItem = _mapper.Map<TemplateModel>(TemplateModelView);
            TemplateItem.id = id;
            return await _repos.UpdateItemByValue(id, TemplateItem);
        }
    }

}
