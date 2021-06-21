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

        [BindProperty]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public string SuccessMessage { get; set; }

        public void OnGet()
        {
            Account = Startup.Atm.GetCurrentAccount();
        }

        //public IActionResult OnPost(int amount)
        //{
        //   return RedirectToPage("AccountList");
        //}

        public void OnPost(int amount)
        {
            Account = Startup.Atm.GetCurrentAccount();

            var result = Startup.Atm.Withdraw(amount);

            switch (result)
            {
                case WithdrawResultEnum.NoMoneyInAtm:
                    ErrorMessage = "Try smaller amount";
                    break;
                case WithdrawResultEnum.NotEnoughtMoney:
                    ErrorMessage = "Not enought money in the account";
                    break;
                case WithdrawResultEnum.TakeYourMoney:
                    SuccessMessage = "Take your money";
                    break;
            }
        }
    }
}
