﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using Zelenko30331_lab.Data;
using Zelenko30331_lab.Domain.Entities;
using Zelenko30331_lab.Services;

namespace Zelenko30331_lab.Areas.Admin.Pages
{
    [Authorize(Policy = "admin")]
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Dish> Dish { get;set; } = default!;

        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public async Task OnGetAsync(int? pageNo = 1)
        {
            var response = await _productService.GetProductListAsync(null, pageNo.Value);
            if (response.Success)
            {
                Dish = response.Data.Items;
                CurrentPage = response.Data.CurrentPage;
                TotalPages = response.Data.TotalPages;
            }
        }
    }
}
