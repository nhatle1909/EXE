# EXE Project API Backend + Frontend 
# Code design based on Project OJT ( Code Designer : Nguyễn Hùng Nghĩa )
# Flow Code : 
  - Model : Table Attribute with ID ( Primary Key ) ( Model name is Table Name )
  - ModelView : Table Attribute but without ID <(")
  - Repository : Include basic method for all service
  - Service : Use Method from repository to create CRUD
  - Controller : API that call method from Service
# Guide to Add new CRUD API 
 1. Create Model and ModelView Class ( For example : TemplateModel and TemplateModelView )
 2. Create CRUD Interface Service and Service class based on template ( For example : ITemplateService and TemplateService )
 3. Create Controller class based on template ( For example : TemplateController )
 4. Inject in progarm.cs :
    - Add builder.Services.AddScoped<Model,ModelView>(); ( For example : builder.Services.AddScoped<TemplateModel,TemplateModelView>(); )
# Update Later
