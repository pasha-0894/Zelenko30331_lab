using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using Zelenko30331_lab.Domain.Entities;
using Zelenko30331_lab.Domain.Models;

namespace Zelenko30331_lab.Services
{
    public class MemoryProductService : IProductService
    {
        List<Dish> _dishes;
        List<Category> category;
        IConfiguration _config;
        public MemoryProductService([FromServices] IConfiguration config, ICategoryService categoryService)
        {
            _config = config;
            category = categoryService.GetCategoryListAsync()
            .Result
            .Data;
            SetupData();
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _dishes = new List<Dish>
                {
                    new Dish {Id = 1, Name="Фольксваген Пассат",
                    Description="Немного б.у. фольксваген", CtegoryId=45882,
                    Price =15000, Photo="images/1.png",
                    Category=category.Find(c=>c.NormalizedName.Equals("Volkswagen"))},
                    new Dish {Id = 2, Name="Фольксваген Поло",
                    Description="Новый", CtegoryId=55971,
                    Price =10200, Photo="images/2.png",
                    Category=category.Find(c=>c.NormalizedName.Equals("Volkswagen"))},
                    new Dish {Id = 3, Name="Шкода Октавия",
                    Description="Один владелец", CtegoryId=60795,
                    Price =12500, Photo="images/3.png",
                    Category=category.Find(c=>c.NormalizedName.Equals("Shkoda"))},
                    new Dish {Id = 4, Name="Ауди 100",
                    Description="Вечный авто", CtegoryId=45701,
                    Price =3500, Photo="images/4.png",
                    Category=category.Find(c=>c.NormalizedName.Equals("Audi"))},
                    new Dish {Id = 5, Name="Рено Меган",
                    Description="Народный авто", CtegoryId=45321,
                    Price =1500, Photo="images/5.png",
                    Category=category.Find(c=>c.NormalizedName.Equals("Reno"))},
                };
        }

        public Task<ResponseData<AssetListModel<Dish>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            // Создать объект результата
            var result = new ResponseData<AssetListModel<Dish>>();
            // Id категории для фильрации
            int? categoryId = null;
            // если требуется фильтрация, то найти Id категории
            // с заданным categoryNormalizedName
            if (categoryNormalizedName != null)
                categoryId = category
                .Find(c =>
                c.NormalizedName.Equals(categoryNormalizedName))
                ?.Id;
            // Выбрать объекты, отфильтрованные по Id категории,
            // если этот Id имеется
            var data = _dishes
            .Where(d => categoryId == null || d.Id.Equals(categoryId))?
            .ToList();
            // получить размер страницы из конфигурации
            int pageSize = _config.GetSection("ItemsPerPage").Get<int>();
            // получить общее количество страниц
            int totalPages = (int)Math.Ceiling(data.Count / (double)pageSize);
            // получить данные страницы
            var listData = new AssetListModel<Dish>()
            {
                Items = data.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList(),
                CurrentPage = pageNo,
                TotalPages = totalPages
            };
            // поместить данные в объект результата
            result.Data = listData;
            // Если список пустой
            if (data.Count == 0)
            {
                result.Success = false;
                result.ErrorMessage = "Нет объектов в выбраннной категории";
            }
            // Вернуть результат
            return Task.FromResult(result);
        }
        public Task<ResponseData<Dish>> CreateProductAsync(Dish product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }
    }
     
}
