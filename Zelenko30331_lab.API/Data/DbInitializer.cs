using NuGet.ContentModel;
using Zelenko30331_lab.Domain.Entities;

namespace Zelenko30331_lab.API.Data
{
    public class DbInitializer
    {
        public static async Task SeedData(WebApplication app)
        {
            // Uri проекта
            var uri = "https://localhost:7002/";
            // Получение контекста БД
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            // Заполнение данными
            if (!context.Category.Any() && !context.Dishes.Any())
            {
                var categories = new Category[]
                    {
                    new Category {Id=1, Name="Фольксваген", NormalizedName="Volkswagen"},
                    new Category {Id=2, Name="Ауди", NormalizedName="Audi"},
                    new Category {Id=3, Name="Шкода", NormalizedName="Shkoda"},
                    new Category {Id=4, Name="Рено", NormalizedName="Reno"},
                    };
                await context.Category.AddRangeAsync(categories);
                await context.SaveChangesAsync();
                var dishes = new List<Dish>
                {
                     new Dish {Id = 1, Name="Фольксваген Пассат",
                    Description="Немного б.у. фольксваген1111", CtegoryId=45882,
                    Price =15000, Photo="images/1.png",
                    Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("Volkswagen"))},
                    new Dish {Id = 2, Name="Фольксваген Поло",
                    Description="Новый", CtegoryId=55971,
                    Price =10200, Photo="images/2.png",
                    Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("Volkswagen"))},
                    new Dish {Id = 3, Name="Шкода Октавия",
                    Description="Один владелец", CtegoryId=60795,
                    Price =12500, Photo="images/3.png",
                    Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("Shkoda"))},
                    new Dish {Id = 4, Name="Ауди 100",
                    Description="Вечный авто", CtegoryId=45701,
                    Price =3500, Photo="images/4.png",
                    Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("Audi"))},
                    new Dish {Id = 5, Name="Рено Меган",
                    Description="Народный авто", CtegoryId=45321,
                    Price =1500, Photo="images/5.png",
                    Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("Reno"))},
                };
                await context.AddRangeAsync(dishes);
                await context.SaveChangesAsync();
            }
        }
    }
}
