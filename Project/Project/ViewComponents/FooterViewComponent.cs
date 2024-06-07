using Microsoft.AspNetCore.Mvc;
using Project.Services.Interfaces;
using static Project.ViewComponents.HeaderViewComponent;

namespace Project.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;

        public FooterViewComponent(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var settings = await _settingService.GetAllAsync();

            var response = new FooterVM()
            {
                Settings = settings
            };

            return View(response);
        }

        public class FooterVM
        {
            public Dictionary<string, string> Settings { get; set; }
        }
    }
}
