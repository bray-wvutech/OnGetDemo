using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnGetDemo.Pages
{
    [BindProperties(SupportsGet = true)]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        [BindProperty(SupportsGet = true)]
        public int Param1 { get; set; } = 0;

        [BindProperty(SupportsGet = true)]
        public int Param2 { get; set; } = 0;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogError($"Privacy - OnGet - {Param1} - {Param2}");
        }

        public void OnPost()
        {
            _logger.LogError($"Privacy - OnPost - {Param1} - {Param2}");
        }
    }

}
