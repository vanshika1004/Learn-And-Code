using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_principles
{
    internal class LSP
    {
        public static void Run()
        {
            List<IBankAccount> accounts = new List<IBankAccount>
        {
            new SavingsAccount(),
            new CurrentAccount()
        };

            foreach (var account in accounts)
            {
                account.Deposit(1000);
                account.Withdraw(200);

                Console.WriteLine($"{account.GetType().Name} Balance: {account.Balance}");
            }

        }
    }

    //LSP - Liskov Substitution Principle - Subclasses should be substitutable for their base class without breaking behavior.
    interface IBankAccount
    {
        decimal Balance { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }

    class SavingsAccount : IBankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (Balance - amount < 0)
            {
                Console.WriteLine("SavingsAccount: Insufficient balance");
                return;
            }

            Balance -= amount;
        }
    }

    class CurrentAccount : IBankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }

}
