using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENSE707_Week1_Lab;
using System;

namespace ENSE707_Week1_Lab.Tests
{
    [TestClass]
    public sealed class BankAccountTests
    {
        [TestMethod]
        public void Deposit_PositiveAmount_IncreasesBalance()
        {
            var acc = new BankAccount("Alice", 50m);
            acc.Deposit(100m);
            Assert.AreEqual(150m, acc.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Deposit_Negative_Throws()
        {
            var acc = new BankAccount("Carol", 10m);
            acc.Deposit(-5m);
        }

        [TestMethod]
        public void Withdraw_SufficientFunds_DecreasesBalanceAndReturnsTrue()
        {
            var acc = new BankAccount("Dave", 200m);
            var result = acc.Withdraw(50m);
            Assert.IsTrue(result);
            Assert.AreEqual(150m, acc.Balance);
        }

        [TestMethod]
        public void Withdraw_ExactBalance_SetsBalanceZero()
        {
            var acc = new BankAccount("Eve", 75m);
            var result = acc.Withdraw(75m);
            Assert.IsTrue(result);
            Assert.AreEqual(0m, acc.Balance);
        }

        [TestMethod]
        public void Withdraw_InsufficientFunds_ReturnsFalseAndNoChange()
        {
            var acc = new BankAccount("Frank", 30m);
            var result = acc.Withdraw(50m);
            Assert.IsFalse(result);
            Assert.AreEqual(30m, acc.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Withdraw_Negative_Throws()
        {
            var acc = new BankAccount("Gina", 40m);
            acc.Withdraw(-10m);
        }

        [TestMethod]
        public void CalculateTransactionFree_ValidAmount_ReturnsTwoPercent()
        {
            var acc = new BankAccount("Hank", 0m);
            var fee = acc.CalculateTransactionFree(100m);
            Assert.AreEqual(2.00m, fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateTransactionFree_Negative_Throws()
        {
            var acc = new BankAccount("Jay", 0m);
            acc.CalculateTransactionFree(-10m);
        }
    }
}