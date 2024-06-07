using Microsoft.AspNetCore.Mvc;
using Project.Services.Interfaces;

namespace Project.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;

        public HeaderViewComponent(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var settings = await _settingService.GetAllAsync();

            var response = new HeaderVM()
            {
                Settings = settings
            };

            return View(response);
        }

        public class HeaderVM
        {
            public Dictionary<string, string> Settings { get; set; }
        }
    }
}
