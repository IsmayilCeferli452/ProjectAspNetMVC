using Microsoft.AspNetCore.Mvc;

namespace Project.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

        public class HeaderVM
        {
            public Dictionary<string, string> Settings { get; set; }
        }
    }
}
