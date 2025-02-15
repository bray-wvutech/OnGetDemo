using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnGetDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace OnGetDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Param1 { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Param2 { get; set; }

        [BindProperty]
        public ParamsModel Params { get; set; } = new();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            _logger.LogError($"OnPost Param1: {Param1}");
        }

        // you have to make the return type IActionResult if you want to do a redirect
        public IActionResult OnPostHandler1()
        {
            _logger.LogError($"OnPostHander1 Param1: {Param1}");
            // return the redirect
            return RedirectToPage("Privacy");
            // if you want to pass variables you do so by making a new
            // anonymous object with the variable names in it
            // we could just say Param1 here instead of Param1 = Param1
            // since the names are the same
            // comma separate multiple values
            //return RedirectToPage("Privacy", new { Param1 = Param1 });
        }

        public void OnPostHandler2()
        {
            _logger.LogError($"OnPostHander2 Param1: {Param1}");
        }

        // the OnPost handler for our form that uses a Model
        public IActionResult OnPostParamsModel()
        {
            _logger.LogError($"OnPostParamsModel Param1: {Params.Param1}");

            // this just reloads the index page again, but it will have a PersonModel
            // with a value for Param1
            //return Page();

            //return RedirectToPage("Privacy", new { Param1=Params.Param1, Param2=34});//Params);

            // redirect using a POST
            // we can pass our Params object to the next page since its properties
            // line up with the properties the Privacy page is looking for
            // Param1, Param2
            return RedirectToPagePreserveMethod("Privacy", null, Params);
        }
    }
}
