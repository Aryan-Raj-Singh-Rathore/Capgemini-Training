using System;
using System.Collections.Generic;

public abstract class Account
{
    protected string AccountNumber;
    protected string OwnerName;
    protected double Balance;

    public string AccountNumberProperty => AccountNumber;
    public string OwnerNameProperty => OwnerName;
    public double BalanceProperty => Balance;

    public Account(string accountNumber, string ownerName, double initialBalance)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    public abstract void CalculateInterest();

    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        Balance += amount;
        Console.WriteLine($"Transaction: Deposited ${amount} to account {AccountNumber}");
        Console.WriteLine($"New balance: ${Balance}");
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds for withdrawal.");
        }

        Balance -= amount;
        Console.WriteLine($"Transaction: Withdrew ${amount} from account {AccountNumber}");
        Console.WriteLine($"New balance: ${Balance}");
    }
}

public class SavingsAccount : Account
{
    private double InterestRate;

    public SavingsAccount(string accountNumber, string ownerName, double initialBalance, double interestRate)
        : base(accountNumber, ownerName, initialBalance)
    {
        InterestRate = interestRate;
    }

    public double InterestRateProperty => InterestRate;

    public override void CalculateInterest()
    {
        double interest = Balance * InterestRate;
        Balance += interest;
        Console.WriteLine($"Interest added: ${interest} to account {AccountNumber}");
        Console.WriteLine($"New balance: ${Balance}");
    }
}

public class CheckingAccount : Account
{
    private double TransactionFee;

    public CheckingAccount(string accountNumber, string ownerName, double initialBalance, double transactionFee)
        : base(accountNumber, ownerName, initialBalance)
    {
        TransactionFee = transactionFee;
    }

    public override void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds for withdrawal.");
        }

        double totalAmount = amount + TransactionFee;
        if (totalAmount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds after transaction fee.");
        }

        Balance -= totalAmount;
        Console.WriteLine($"Transaction: Withdrew ${amount} and paid a fee of ${TransactionFee} from account {AccountNumber}");
        Console.WriteLine($"New balance: ${Balance}");
    }

    public override void CalculateInterest()
    {
        double interest = Balance * 0.01;
        Balance += interest;
        Console.WriteLine($"Interest added: ${interest} to account {AccountNumber}");
        Console.WriteLine($"New balance: ${Balance}");
    }
}

public class Bank
{
    private string BankName;
    private List<Account> Accounts;

    public Bank(string bankName)
    {
        BankName = bankName;
        Accounts = new List<Account>();
    }

    public void AddAccount(Account account)
    {
        Accounts.Add(account);
    }

    public void DepositToAccount(string accountNumber, double amount)
    {
        Account account = Accounts.Find(a => a.AccountNumberProperty == accountNumber);
        if (account != null)
        {
            account.Deposit(amount);
        }
        else
        {
            Console.WriteLine($"Account {accountNumber} not found.");
        }
    }

    public void WithdrawFromAccount(string accountNumber, double amount)
    {
        Account account = Accounts.Find(a => a.AccountNumberProperty == accountNumber);
        if (account != null)
        {
            try
            {
                account.Withdraw(amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Transaction failed: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"Account {accountNumber} not found.");
        }
    }

    public void DisplayAccountSummaries()
    {
        Console.WriteLine($"{BankName} Account Summaries:");
        foreach (var account in Accounts)
        {
            Console.WriteLine($"{account.GetType().Name} - Account #: {account.AccountNumberProperty}");
            Console.WriteLine($"Owner: {account.OwnerNameProperty}");
            Console.WriteLine($"Balance: ${account.BalanceProperty}");
            if (account is SavingsAccount)
            {
                Console.WriteLine($"Interest Rate: {((SavingsAccount)account).InterestRateProperty * 100}%");
            }
            else if (account is CheckingAccount)
            {
                Console.WriteLine("Interest Rate: 1%");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        SavingsAccount savings = new SavingsAccount("S12345", "Alice Johnson", 1000, 0.05);
        CheckingAccount checking = new CheckingAccount("C67890", "Bob Smith", 500, 0.01);

        Bank bank = new Bank("MyBank");
        bank.AddAccount(savings);
        bank.AddAccount(checking);

        bank.DepositToAccount("S12345", 500);
        bank.WithdrawFromAccount("C67890", 200);

        savings.CalculateInterest();
        checking.CalculateInterest();

        bank.DisplayAccountSummaries();

        try
        { 
            bank.WithdrawFromAccount("C67890", 1000);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Transaction failed: {ex.Message}");
        }
    }
}
 