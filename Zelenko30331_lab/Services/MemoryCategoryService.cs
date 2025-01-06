using Zelenko30331_lab.Domain.Entities;
using Zelenko30331_lab.Domain.Models;

namespace Zelenko30331_lab.Services
{
    public class MemoryCategoryService : ICategoryService
    {
        public Task<ResponseData<List<Category>>> GetCategoryListAsync()
        {
            var categories = new List<Category>
{
                new Category {Id=1, Name="Фольксваген",
                NormalizedName="Volkswagen"},
                new Category {Id=2, Name="Ауди",
                NormalizedName="Audi"},
                new Category {Id=3, Name="Шкода",
                NormalizedName="Shkoda"},
                new Category {Id=4, Name="Рено",
                NormalizedName="Reno"},
                };
            var result = new ResponseData<List<Category>>();
            result.Data = categories;
            return Task.FromResult(result);
        }
    }
}
