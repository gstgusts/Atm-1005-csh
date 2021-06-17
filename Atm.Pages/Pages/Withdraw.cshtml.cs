using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atm.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Atm.Pages.Pages
{
    public class Index1Model : PageModel
    {
        [BindProperty]
        public Account Account { get; set; }

        public void OnGet()
        {
            Account = Startup.Atm.GetCurrentAccount();
        }
    }
}
