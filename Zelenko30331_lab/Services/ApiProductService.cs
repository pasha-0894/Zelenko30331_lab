using NuGet.ContentModel;
using Zelenko30331_lab.Domain.Models;
using Zelenko30331_lab.Domain;
using Zelenko30331_lab.Domain.Entities;

namespace Zelenko30331_lab.Services
{
    public class ApiProductService(HttpClient httpClient) : IProductService
    {
        public async Task<ResponseData<List<Dish>>> GetAssetListAsync()
        {
            var result = await httpClient.GetAsync(httpClient.BaseAddress);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<ResponseData<List<Dish>>>();
            };
            var response = new ResponseData<List<Dish>>
            { Success = false, ErrorMessage = "Ошибка чтения API" };
            return response;
        }
        public async Task<ResponseData<AssetListModel<Dish>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            var uri = httpClient.BaseAddress;
            var queryData = new Dictionary<string, string>();
            queryData.Add("pageNo", pageNo.ToString());
            if (!String.IsNullOrEmpty(categoryNormalizedName))
            {
                queryData.Add("category", categoryNormalizedName);
            }
            var query = QueryString.Create(queryData);
            var result = await httpClient.GetAsync(uri + query.Value);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<ResponseData<AssetListModel<Dish>>>();
            };
            var response = new ResponseData<AssetListModel<Dish>>
            { Success = false, ErrorMessage = "Ошибка чтения API" };
            return response;
        }
    }
}
