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

        public void OnGet()
        {
            Accounts = Startup.Atm.GetCustomerAccounts();
        }
    }
}
