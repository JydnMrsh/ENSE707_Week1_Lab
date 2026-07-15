using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSE707_Week1_Lab
{
    public class BankAccount
    {
        public string AccountHolder { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountHolder, decimal openingBalance)
        {
            if (string.IsNullOrWhiteSpace(accountHolder))
            {
                throw new ArgumentException("Account holder name is required.");
            }

            if (openingBalance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(openingBalance), "Opening balance cannot be negative.");
            }

            AccountHolder = accountHolder;
            Balance = openingBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive.");
            }

            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdraw amount must be positive.");
            }

            if (amount > Balance)
            {
                return false;
            }

            Balance -= amount;
            return true;
        }

        public decimal CalculateTransactionFree(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Transaction amount must be positive");
            }

            return Math.Round(amount * 0.02m, 2);
        }
    }
}
