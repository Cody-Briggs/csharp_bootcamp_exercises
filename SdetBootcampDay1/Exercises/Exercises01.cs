using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    [TestFixture]
    public class Exercises01
    {
        [Test]
        public void GivenANewCheckingAccount_WhenIDeposit200_ThenBalanceShouldBe200()
        {
            var account = new Account(AccountType.Checking);

            account.Deposit(200);

            //Debug.Assert(account.Balance <= 199);
            //Debug.Assert(account.Balance != 200);

            Assert.That(account.Balance, Is.EqualTo(200));
            Assert.That(account.Balance, Is.GreaterThan(199));
            

            /**
             * TODO: add an assertion that verifies that the resulting balance is 200.
             */

            /**
             * TODO: add an assertion that verifies that the resulting balance is greater than 199.
             */
        }

        [Test]
        public void GivenANewSavingsAccount_WhenIDeposit200AndWithdraw100_ThenBalanceShouldBe100()
        {

            Account SavingsAccount = new Account(AccountType.Savings);

            SavingsAccount.Deposit(200);
            SavingsAccount.Withdraw(100);

            Assert.That(SavingsAccount.Balance, Is.EqualTo(100));

            //Debug.Assert(SavingsAccount.Balance != 100);
            /**
             * TODO: create a new savings account
             */

            /**
             * TODO: first, deposit 200 dollars, then immediately withdraw 100 dollars again.
             */

            /**
             * TODO: assert that the resulting balance is equal to 100.
             */
        }

        [Test]
        public void GivenNewCheckingAccount_Deposit100AndWithdraw200_TheBalanceShouldBeNegative100(){

            Account NewCheckingAccount = new Account(AccountType.Checking);

            NewCheckingAccount.Deposit(100);
            NewCheckingAccount.Withdraw(200);

            //Debug.Assert(SavingsAccount.Balance != -100);
            Assert.That(NewCheckingAccount.Balance, Is.EqualTo(-100));
        }

        /**
         * TODO: Write a third test method that performs the following steps:
         * - Create a new checking account
         * - Deposit 100 dollars
         * - Withdraw 200 dollars
         * - Check that the resulting balance is -100 dollars
         */

    }
}
