using System;

namespace bank
{
    // This is an Account. It represents a customer's bank account
    public class Account
    {
        private const int NegativeBalanceFee = -25;

        public Account()
        {
        }

        public Account(float initialBalance)
        {
            if (initialBalance > 0)
                Balance = initialBalance;
            else
                throw new Exception("Invalid Initial Balance");
        }

        public float Balance { get; private set; }

        public void Deposit(float amount)
        {
            Balance += amount;
        }

        public void Withdraw(float amount)
        {
            Balance -= amount;
            if (Balance < 0) ApplyNegativeBalanceFee();
        }

        private float ApplyNegativeBalanceFee()
        {
            return Balance += NegativeBalanceFee;
        }

        public void TransferFunds(Account destination, float amount)
        {
            if (IsValidAmountAndBalance(amount)) return;
            destination.Deposit(amount);
            Withdraw(amount);
        }

        public bool IsValidAmountAndBalance(float amount)
        {
            return amount >= Balance && Balance > 0 && amount >= 0;
        }
    }
}
