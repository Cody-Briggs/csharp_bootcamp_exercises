using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        /**
         * TODO: rewrite these three tests into a single, parameterized test.
         * You decide if you want to use [TestCase] or [TestCaseSource], but
         * I would like to know why you chose the option you chose afterwards.
         */
        [Test]
        public void CreateNewSavingsAccount_Deposit100Withdraw50_BalanceShouldBe50()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(100);
            account.Withdraw(50);

            Assert.That(account.Balance, Is.EqualTo(50));
        }

        [Test]
        public void CreateNewSavingsAccount_Deposit1000Withdraw1000_BalanceShouldBe0()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(1000);
            account.Withdraw(1000);

            Assert.That(account.Balance, Is.EqualTo(0));
        }

        [Test]
        public void CreateNewSavingsAccount_Deposit250Withdraw1_BalanceShouldBe249()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(250);
            account.Withdraw(1);

            Assert.That(account.Balance, Is.EqualTo(249));
        }

        [Test, TestCaseSource("CheckSavingsAccountBalanceAfterTransaction")]
        public void SavingsAccountBalanceAdjustmentChecks(int DepositAmount, int WithdrawlAmount, int ExpectedBalance)
        {
            ///In this instance, all the actions above were the same, so it made more sense to batch it together in an iterable vs making 3 stand alone objects.
            ///Organizationally it feels cleaner to me. Code wise it's about the same if not more than generating 3 seperate tests though.
            Account NewAccount = new Account(AccountType.Savings);

            NewAccount.Deposit(DepositAmount);
            NewAccount.Withdraw(WithdrawlAmount);

            Assert.That(NewAccount.Balance, Is.EqualTo(ExpectedBalance));
             

        }

        private static IEnumerable<TestCaseData> CheckSavingsAccountBalanceAfterTransaction() 
        {
            yield return new TestCaseData(100, 50, 50).SetName("Deposit100_Withdraw50_Balance50");
            yield return new TestCaseData(1000, 1000, 0).SetName("Deposit1000_Withdraw1000_Balance0");
            yield return new TestCaseData(250, 1, 249).SetName("Deposit250_withdraw1_Balance249");
        }
    }
}
