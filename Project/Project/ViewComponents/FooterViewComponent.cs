using Microsoft.AspNetCore.Mvc;

namespace Project.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

        public class FooterVM
        {
            public Dictionary<string, string> Settings { get; set; }
        }
    }
}
