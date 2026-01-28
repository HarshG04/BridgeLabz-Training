using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class BankAccountMSTests
    {
        private BankAccount account;

        [TestInitialize]
        public void Init()
        {
            account = new BankAccount(1000);
        }

        [TestMethod]
        public void Deposit_ValidAmount_UpdatesBalance()
        {
            account.Deposit(500);

            Assert.AreEqual(1500, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_ValidAmount_UpdatesBalance()
        {
            account.Withdraw(300);

            Assert.AreEqual(700, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_InsufficientFunds_ThrowsException()
        {
            try
            {
                account.Withdraw(2000);
                Assert.Fail("Expected InvalidOperationException was not thrown.");
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
