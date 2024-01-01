using EXE.Interface;
using Models.Model;
using Models.ModelView;
using Models.Repository;

namespace EXE.Service
{

    public class TemplateService : ITemplateService
    {
        private readonly IRepository<TemplateModel> _repos;
        public TemplateService(IRepository<TemplateModel> TemplateRepo)
        {

            _repos = TemplateRepo;
        }
        public async Task<TemplateModel> AddOneTemplateItem(TemplateModelView TemplateModelView)
        {
            TemplateModel TemplateItem = new TemplateModel
            {
                id = "123",
                name = TemplateModelView.name
            };
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
            TemplateModel TemplateItem = new TemplateModel
            {
                id = id,
                name = TemplateModelView.name
            };
            return await _repos.UpdateItemByValue(id, TemplateItem);
        }
    }

}
