using System;
using AccountProject;

public class Program
{
    public static void Main(string[] args)
    {
        Account[] accounts = new Account[6]
        {
            new Account(101, "SBI Bank", "Amit", 123456789101 , 400),
            new Account(102, "ICICI Bank", "Harsh", 901234567654, 700),
            new Account(103, "Indian Bank", "Ram", 234567548954),
            new Account(104, "SBI Bank", "Sakshi",231278562678, 1000),
            new Account(104, "Indian Bank", "Anushka",239876572678, 100000),
            new Account(104, "ICICI Bank", "Virat",234455335578)
        };

        bool continueProgram = true;

        while (continueProgram)
        {
            Console.Write("Enter the account number to perform transactions (or enter 0 to exit): ");
            int accountNumber = int.Parse(Console.ReadLine());

            if (accountNumber == 0)
            {
                continueProgram = false;
                break;
            }

            Account selectedAccount = null;

            foreach (Account account in accounts)
            {
                if (account.GetAccountNumber() == accountNumber)
                {
                    selectedAccount = account;
                    break;
                }
            }

            if (selectedAccount != null)
            {
                bool continueTransactions = true;
                while (continueTransactions)
                {
                    Console.WriteLine("\n------Select transaction:------\nPress 1 for Check Balance\nPress 2 for Deposit\nPress 3 for Withdrawl\nPress 4 for Account Details\nPress 5 to get details of account with maximum balance\nPress 6 to Exit");
                    int selectTransaction = int.Parse(Console.ReadLine());

                    switch (selectTransaction)
                    {
                        case 1:
                            selectedAccount.CheckAccountBalance();
                            break;
                        case 2:
                            Console.Write("Enter the amount which you want to deposit : ");
                            double depositAmount = double.Parse(Console.ReadLine());
                            Console.WriteLine(selectedAccount.DepositAmount(depositAmount));
                            break;
                        case 3:
                            Console.Write("Enter the amount which you want to Withdraw : ");
                            double withdrawAmount = double.Parse(Console.ReadLine());
                            Console.WriteLine(selectedAccount.WithdrawAmount(withdrawAmount));
                            break;
                        case 4:
                            selectedAccount.PrintAccountDetails();
                            break;
                        case 5:
                            Console.WriteLine($"Maximum Balance is : {selectedAccount.ReturnMaxBalance(accounts)}");
                            break;
                        case 6:
                            continueTransactions = false;
                            break;
                        default:
                            Console.WriteLine("Select Transaction again...");
                            break;
                    }
                }
            }
            else
                Console.WriteLine("Account not found. Please try again.");
        }
    }
}