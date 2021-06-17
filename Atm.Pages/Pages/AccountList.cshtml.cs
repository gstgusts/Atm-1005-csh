using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atm.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Atm.Pages.Pages
{
    public class AccountListModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Account> Accounts { get; set; }

        public IActionResult OnGet()
        {
            Accounts = Startup.Atm.GetCustomerAccounts();

            var request = HttpContext.Request;

            if (request.QueryString.HasValue 
                &&  !string.IsNullOrEmpty(request.Query["accountId"]))
            {
               var account = Accounts.FirstOrDefault(a => a.Number == request.Query["accountId"]);

               if(account != null)
                {
                    Startup.Atm.SetAccount(account.Number);

                    return RedirectToPage("Withdraw");
                }
            }

            return Page();
        }
    }
}
