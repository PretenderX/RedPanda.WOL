using System.Threading.Tasks;
using Derungsoft.WolSharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RedPanda.WOL.Core.Model;

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
            if (string.IsNullOrEmpty(Mac.Value))
            {
                Message = "MAC地址不能为空！";
                HasError = true;

                return Page();
            }

            if (Mac.Value.Contains(":"))
            {
                Mac.Value = Mac.Value.Replace(":", "-");
            }

            if (Mac.Value.Split('-').Length != 6)
            {
                Message = "MAC地址格式错误！";
                HasError = true;

                return Page();
            }

            var awakener = new Awakener();

            await awakener.WakeAsync(Mac.Value);

            Message = "唤醒指令发送成功！";
            HasError = false;

            return Page();
        }
    }
}
