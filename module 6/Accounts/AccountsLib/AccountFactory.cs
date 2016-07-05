using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public static class AccountFactory
    {
        static int i = 0;
        public static Account CreateAccount(int balance)
        {
            if (balance < 0)
                return null;
            Account newAcc = new Account(i++);
            newAcc.Deposit(balance);
            return newAcc;
        }
    }
}
