using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountsLib.Account newAcc = AccountsLib.AccountFactory.CreateAccount(0);
            newAcc.Deposit(50);
            try
            {
                newAcc.Withdraw(51);
            }
            //You are not handling the ArgumentOutOfRangeException/Exception that you throwed if the amount is negative.
            catch (InsufficentFundsException e)
            {
                Console.WriteLine("there has been an InsufficentFundsException");
            }
            finally //didn't understood why we need the finally now but i did it
            {
                newAcc.Withdraw(29);
                AccountsLib.Account newAcc2 = AccountsLib.AccountFactory.CreateAccount(0);
                newAcc.Transfer(newAcc2, 5);
                Console.WriteLine("{0} {1}", newAcc.Balance, newAcc2.Balance);
                Console.ReadLine();
            }
        }
    }
}
