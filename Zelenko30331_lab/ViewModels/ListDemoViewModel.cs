using Microsoft.AspNetCore.Mvc.Rendering;

namespace Zelenko30331_lab.ViewModels
{
    public class ListDemoViewModel
    {
        public int SelectedId { get; set; }
        public SelectList Items { get; set; }
    }
}
