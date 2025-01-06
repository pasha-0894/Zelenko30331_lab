using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelenko30331_lab.Domain.Entities;

namespace Zelenko30331_lab.Domain.Models
{
    public class AssetListModel<T>
    {
        // запрошенный список объектов
        public List<T> Items { get; set; } = new();
        // номер текущей страницы
        public int CurrentPage { get; set; } = 1;
        // общее количество страниц
        public int TotalPages { get; set; } = 1;

        public static implicit operator AssetListModel<T>(List<Dish> v)
        {
            throw new NotImplementedException();
        }
    }
}
