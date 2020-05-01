using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RedPanda.WOL.Sender;

namespace RedPanda.WOL.Core.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public MacAddress Mac { get; set; }

        [ViewData]
        public string Message { get; private set; }

        [ViewData]
        public bool HasError { get; private set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var wolSender = new WOLSender();

            HasError = !wolSender.Send(Mac, out var message);

            Message = message;

            return Page();
        }
    }
}
