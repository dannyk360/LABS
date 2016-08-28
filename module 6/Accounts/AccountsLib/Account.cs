using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class Account
    {
        public int id;
        public decimal balance = 0;
        public Account(int id)
        {
            this.id = id;
        }
        public int ID
        {
            get { return id; }
        }
        public void Deposit(int money)
        {
            if (money < 0)
            {
                throw new Exception("NegativeExc");
            }
            if (balance >= int.MaxValue - money)
            {
                throw new OverflowException();
            }
            
            balance += money;
        }
        public void Withdraw(int money)
        {
            if(money < 0)
                //Why aren't you using ArgumentOutOfRangeException()
                //Also, you should have used a better string that describes that actual exception
                throw new Exception("NegativeExc");
            if (balance - money < 0)
                throw new InsufficentFundsException();

            balance -= money;
        }
        public decimal Balance
        {
            get { return balance; }
        }
        public bool Transfer(Account friend, int amount)
        {

            if (amount < 0)
                return false;
            if (balance - amount < 0)
                return false;
            friend.balance += amount;
            this.balance -= amount;
            Console.WriteLine("friend balance is " + friend.Balance + " and your is "+this.Balance);
            return true;
        }
    }
}
