using System;
using NUnit.Framework;

namespace bank
{
    [TestFixture]
    public class When_opening_a_new_Account
    {
        [Test]
        public void the_initial_balance_should_be_zero_if_not_specified()
        {
            var account = new Account();

            Assert.AreEqual(0, account.Balance);
        }

        [Test]
        public void the_initial_balance_should_be_set_correctly_if_specified()
        {
            var account = new Account(100.0F);

            Assert.AreEqual(100, account.Balance);
        }

        [Test]
        [ExpectedException(typeof(Exception), "Invalid Initial Balance")]
        public void the_initial_balance_should_not_be_negative()
        {
            var account = new Account(-100.0F);
        }
    }

    [TestFixture]
    public class When_performing_a_deposit_on_an_Account
    {
        [Test]
        public void the_balance_should_increase_correctly()
        {
            var account = new Account();

            account.Deposit(100);

            Assert.AreEqual(100, account.Balance);
        }

        [Test]
        public void the_balance_should_increase_correctly_when_there_is_an_existing_balance()
        {
            var account = new Account();

            account.Deposit(10);
            account.Deposit(100);

            Assert.AreEqual(110, account.Balance);
        }

//        [Test]
//        public void the_balance_should_increase_correctly()
//        {
//            var account = new Account() {Balance = 100};
//
//            account.Deposit(100);
//
//            Assert.AreEqual(100, account.Balance);
//        }
    }
    [TestFixture]
    public class When_performing_a_withdrawal_on_an_Account
    {
        [Test]
        public void the_Account_balance_should_decrease()
        {
            var account = new Account(100);

            account.Withdraw(30);

            Assert.AreEqual(70, account.Balance);
        }

        [Test]
        public void the_Account_should_be_charged_a_flat_fee_if_goes_negative()
        {
            var account = new Account(100);

            account.Withdraw(130);

            Assert.AreEqual(-55, account.Balance);
        }

        [Test]
        public void the_Account_should_not_be_charged_a_flat_fee_if_goes_negative_with_Sullis_snazzy_overdraft_protection()
        {
            var account = new Account(100);

            account.Withdraw(130);

            Assert.AreEqual(-55, account.Balance);
        }

    }

    [TestFixture]
    public class When_transferring_funds_between_accounts
    {
        [Test]
        public void the_amount_and_the_balance_should_be_valid()
        {
            var source = new Account();
            source.Deposit(200.00F);
            var destination = new Account();
            destination.Deposit(150.00F);

            Assert.IsTrue(source.IsValidAmountAndBalance(201.00F));
        }

        [Test]
        public void the_Amount_should_be_deposited_into_the_destination_account()
        {
            var source = new Account();
            source.Deposit(200.00F);
            var destination = new Account();
            destination.Deposit(150.00F);

            source.TransferFunds(destination, 100.00F);
            Assert.AreEqual(250.00F, destination.Balance);
        }

        [Test]
        public void the_Amount_should_be_withdrawn_from_the_source_account()
        {
            var source = new Account();
            source.Deposit(200.00F);
            var destination = new Account();
            destination.Deposit(150.00F);

            source.TransferFunds(destination, 100.00F);
            Assert.AreEqual(100.00F, source.Balance);
        }

        [Test]
        public void the_balance_of_the_source_account_should_not_change()
        {
            var source = new Account();
            source.Deposit(200.00F);
            var destination = new Account();
            destination.Deposit(150.00F);

            source.TransferFunds(destination, 201.00F);
            Assert.AreEqual(200.00F, source.Balance);
        }
    }
}