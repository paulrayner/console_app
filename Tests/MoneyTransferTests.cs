using ConsoleApplication1;
using NUnit.Framework;

namespace bank
{
    [TestFixture]
    public class When_transferring_funds
    {
        [Test]
        public void the_destination_account_balance_should_be_updated()
        {
            var sourceAccount = new Account();
            sourceAccount.Deposit(100.0F);
            var destinationAccount = new Account();

            MoneyMover.TransferFunds(sourceAccount, destinationAccount, 50.0F);

            Assert.AreEqual(50.0F, destinationAccount.Balance);
        }

        [Test]
        public void the_source_account_balance_should_be_updated()
        {
            var sourceAccount = new Account();
            sourceAccount.Deposit(100.0F);
            var destinationAccount = new Account();

            MoneyMover.TransferFunds(sourceAccount, destinationAccount, 70.0F);

            Assert.AreEqual(30.0F, sourceAccount.Balance);
        }
    }
}