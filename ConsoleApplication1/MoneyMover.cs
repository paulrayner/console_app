using bank;

namespace ConsoleApplication1
{
    public class MoneyMover
    {
        public static void TransferFunds(Account sourceAccount,
                                         Account destinationAccount,
                                         float amount)
        {
            sourceAccount.Withdraw(amount);
            destinationAccount.Deposit(amount);
        }
    }
}