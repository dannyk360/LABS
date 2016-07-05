using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace NUnit.Tests1
{
    [TestFixture]
    public class Test_Account_Class
    {
        [Test]
        public void Test_DepositMax_Failed()
        {
            AccountsLib.Account acc = new AccountsLib.Account(3);
            acc.Deposit(3);
            try
            {
                acc.Deposit(int.MaxValue);
                Assert.Fail();
            }
            catch (OverflowException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Test_DepositNegative_Failed()
        {
            AccountsLib.Account acc = new AccountsLib.Account(3);
            acc.Deposit(3);
            try
            {
                acc.Deposit(-2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("NegativeExc", e.Message);
            }
        }

        [Test]
        public void Test_Deposit_Success()
        {
            AccountsLib.Account acc = new AccountsLib.Account(3);
            acc.Deposit(3);
            acc.Deposit(2);
            Assert.AreEqual(5, acc.Balance);
            
        }
        [Test]
        public void Test_WithdrawNegative_Failed()
        {
            AccountsLib.Account acc = new AccountsLib.Account(3);
            acc.Deposit(3);
            try
            {
                acc.Withdraw(-2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("NegativeExc", e.Message);
            }
        }

        [Test]
        public void Test_Withdraw_Success()
        {
            AccountsLib.Account acc = new AccountsLib.Account(3);
            acc.Deposit(3);
            acc.Withdraw(2);
            Assert.AreEqual(1, acc.Balance);

        }
        [Test]
        public void Test_WithdrawTooMuch_Failed()
        {
            AccountsLib.Account acc = new AccountsLib.Account(3);
            acc.Deposit(2);
            try
            {
                acc.Withdraw(3);
                Assert.Fail();
            }
            catch (InsufficentFundsException)
            {
                Assert.Pass();
            }

        }
        [Test]
        public void Test_TransferNegative_Failed()
        {
            AccountsLib.Account acc = new AccountsLib.Account(3);
            AccountsLib.Account acc2 = new AccountsLib.Account(5);
            acc.Deposit(3);
            Assert.AreEqual(false,acc.Transfer(acc2,4));

        }
        [Test]
        public void Test_TransferNegativeAmount_Failed()
        {
            AccountsLib.Account acc = new AccountsLib.Account(3);
            AccountsLib.Account acc2 = new AccountsLib.Account(5);
            acc.Deposit(3);
            Assert.AreEqual(false, acc.Transfer(acc2, -34));
        }
        [Test]
        public void Test_Transfer_Success()
        {
            AccountsLib.Account acc = new AccountsLib.Account(3);
            AccountsLib.Account acc2 = new AccountsLib.Account(5);
            acc.Deposit(3);
            Assert.AreEqual(true, acc.Transfer(acc2, 2));
            Assert.AreEqual(1, acc.Balance);
            Assert.AreEqual(2, acc2.Balance);

        }


    }
}
