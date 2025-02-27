﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelenko30331_lab.Domain.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CtegoryId { get; set; }
        public decimal Price { get; set; }
        public string? Photo { get; set; }
        public Category Category { get; set; }
    }
}
