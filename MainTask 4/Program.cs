
namespace MainTask_4_
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public Account() { }
        public Account(string name) {

            this.Name = name;
        }
        public Account(string Name = "Unnamed Account", double Balance = 0.0)
        {
            this.Name = Name;
            this.Balance = Balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"Name : {Name} , Balance : {Balance}";
        }

        public static Account operator+(Account left, Account right)
        {
            return new Account($"Sum of two Accounts balances: {left.Balance + right.Balance}" );
        }
    }

    class SavingsAccount : Account
    {
        public double intrestRate { get; set; }
        public SavingsAccount() { }
        public SavingsAccount(string name) : base(name) { }

        public SavingsAccount(string name, double balance) :base(name, balance) { }
    
        public SavingsAccount(string name, double balance, double intrestRate)
            : base(name, balance)
        {
            this.intrestRate = intrestRate;
        }
        public override string ToString()
        {
            return $"{base.ToString()} , Rate : {intrestRate}";
        }
    }

    class CheckingAccount : Account
    {
        public CheckingAccount() { }
        public CheckingAccount(string name) : base(name) { }
        public CheckingAccount(string name, double balance) : base(name, balance) { }

        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount + 1.5);
        }
    }

    class TrustAccount : SavingsAccount
    {
        public TrustAccount() { }
        public TrustAccount(string name) : base (name) { }

        public TrustAccount(string name, double balance) : base (name, balance) { }
        public TrustAccount(string name, double balance, double interestRate)
            : base(name, balance, interestRate)
        {

        }
        public override bool Withdraw(double amount)
        {
            if (AccountUtil.CanWithdraw() && amount < (Balance * .2))
            {

                return base.Withdraw(amount);

            }
            else
            {

                Console.WriteLine("Withdrawal limit reached.");
                return false;
            }
        }

        public override bool Deposit(double amount)
        {
            if (amount >= 5000)
            {
                return base.Deposit(amount + 50);
            }
            else if (amount < 5000) 
            { return base.Deposit(amount); }
            return false;
        }
    }

    public static class AccountUtil  
    {
        static int count = 0;
        static int lastYear = DateTime.Now.Year;

        public static bool CanWithdraw()
        {
            if (DateTime.Now.Year > lastYear)
            {
                count = 0;
                lastYear = DateTime.Now.Year;
            }

            if (count >= 3)
                return false;

            count++;
            return true;
        }

        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts =====================================================\n");
            foreach (var acc in accounts)
            {
                Console.WriteLine($"{acc.GetType().Name}: {acc}");
            }
        }

        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts ========================================\n");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==================================\n");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            // Accounts
            //var accounts = new List<Account>();
            //accounts.Add(new Account());
            //accounts.Add(new Account("Larry"));
            //accounts.Add(new Account("Moe", 2000));
            //accounts.Add(new Account("Curly", 5000));

            //AccountUtil.Display(accounts);
            //AccountUtil.Deposit(accounts, 1000);
            //AccountUtil.Withdraw(accounts, 2000);

            //// Savings
            //var savAccounts = new List<Account>();
            //savAccounts.Add(new SavingsAccount());
            //savAccounts.Add(new SavingsAccount("Superman"));
            //savAccounts.Add(new SavingsAccount("Batman", 2000));
            //savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            //AccountUtil.Display(savAccounts);
            //AccountUtil.Deposit(savAccounts, 1000);
            //AccountUtil.Withdraw(savAccounts, 2000);

            //// Checking
            //var checAccounts = new List<Account>();
            //checAccounts.Add(new CheckingAccount());
            //checAccounts.Add(new CheckingAccount("Larry2"));
            //checAccounts.Add(new CheckingAccount("Moe2", 2000));
            //checAccounts.Add(new CheckingAccount("Curly2", 5000));

            //AccountUtil.Display(checAccounts);
            //AccountUtil.Deposit(checAccounts, 1000);
            //AccountUtil.Withdraw(checAccounts, 2000);
            //AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<Account>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.Display(trustAccounts);
            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);

            Console.WriteLine();
        }

    }
}
