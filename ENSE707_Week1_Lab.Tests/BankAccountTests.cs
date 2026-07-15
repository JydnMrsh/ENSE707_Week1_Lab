using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENSE707_Week1_Lab;
using System;

namespace ENSE707_Week1_Lab.Tests
{
    [TestClass]
    public sealed class BankAccountTests
    {

        // Negative Opening Balance
        [TestMethod]
        public void Constructor_NegativeOpeningBalance_Throws()
        {
            Assert.ThrowsException<ArgumentException>(() => new BankAccount("Test User", -100m));
        }

        /*
         * DEPOSIT TESTS
        */

        // Deposit Positive Amount
        [TestMethod]
        public void Deposit_PositiveAmount_IncreasesBalance()
        {
            var acc = new BankAccount("Alice", 50m);
            acc.Deposit(100m);
            Assert.AreEqual(150m, acc.Balance);
        }

        // Deposit Negative Amount
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Deposit_NegativeAmount_Throws()
        {
            var acc = new BankAccount("Carol", 10m);
            acc.Deposit(-5m);
        }

        /*
         * WITHDRAW TESTS
        */

        // Withdraw Sufficient Funds
        [TestMethod]
        public void Withdraw_SufficientFunds_DecreasesBalanceAndReturnsTrue()
        {
            var acc = new BankAccount("Dave", 200m);
            var result = acc.Withdraw(50m);
            Assert.IsTrue(result);
            Assert.AreEqual(150m, acc.Balance);
        }

        // Withdraw Exact Balance
        [TestMethod]
        public void Withdraw_ExactBalance_SetsBalanceZero()
        {
            var acc = new BankAccount("Eve", 75m);
            var result = acc.Withdraw(75m);
            Assert.IsTrue(result);
            Assert.AreEqual(0m, acc.Balance);
        }

        // Withdraw Insufficient Funds
        [TestMethod]
        public void Withdraw_InsufficientFunds_ReturnsFalseAndNoChange()
        {
            var acc = new BankAccount("Frank", 30m);
            var result = acc.Withdraw(50m);
            Assert.IsFalse(result);
            Assert.AreEqual(30m, acc.Balance);
        }

        // Withdraw Negative Amount
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Withdraw_Negative_Throws()
        {
            var acc = new BankAccount("Gina", 40m);
            acc.Withdraw(-10m);
        }

        /*
         * TRANSACTION FEE TESTS
        */

        // Calculate Transaction Fee for Valid Amount
        [TestMethod]
        public void CalculateTransactionFree_ValidAmount_ReturnsTwoPercent()
        {
            var acc = new BankAccount("Hank", 0m);
            var fee = acc.CalculateTransactionFree(100m);
            Assert.AreEqual(2.00m, fee);
        }

        // Calculate Transaction Fee for Negative Amount
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateTransactionFree_Negative_Throws()
        {
            var acc = new BankAccount("Jay", 0m);
            acc.CalculateTransactionFree(-10m);
        }
    }
}