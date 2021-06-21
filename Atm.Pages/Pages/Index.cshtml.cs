using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atm.Pages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string ErrorMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Startup.Atm.Exit();
        }

        public IActionResult OnPost(string number, int pin)
        {
            var card = Startup.Cards.FirstOrDefault(c => c.Number == number);

            if(card == null)
            {
                ErrorMessage = "Unable to find a card";
                return Page();
            }

            if(!card.IsPinValid(pin))
            {
                ErrorMessage = "Invalid PIN";
                return Page();
            }

            var result = Startup.Atm.Start(card, pin);

            if(!result)
            {
                ErrorMessage = "Something wrong!";
                return Page();
            }

            return RedirectToPage("AccountList");
        }
    }
}
