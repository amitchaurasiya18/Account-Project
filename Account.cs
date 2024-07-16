using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AccountProject
{
    internal class Account
    {
        private int _accountNumber;
        private string _accountHolderName;
        private string _bankName;
        private double _accountBalance;
        private long _aadharNumber;
        public static double MAXIMUM_BALANCE = 0;
        public const double MIN_BALANCE = 500;
        public int maxBalanceAccountNumber;


        //public Account(int accountNumber, string bankName, string accountHolderName) : this(accountNumber, bankName, accountHolderName, 0)
        //{

        //}

        public Account(int accountNumber, string bankName, string accountHolderName, long aadharNumber) : this(accountNumber, bankName, accountHolderName, aadharNumber,MIN_BALANCE)
        {
            
        }

        public Account(int accountNumber, string bankName, string accountHolderName, long aadharNumber, double accountBalance)
        {
            _accountNumber = accountNumber;
            _accountHolderName = accountHolderName;
            _bankName = bankName;
            _aadharNumber = aadharNumber;
            if (accountBalance < MIN_BALANCE)
                _accountBalance = MIN_BALANCE;
            else
                _accountBalance = accountBalance;
        }



        public string DepositAmount(double amount)
        {
            _accountBalance += amount;
            return $"{amount} deposited successfully";
        }

        public string WithdrawAmount(double amount)
        {
            if ((_accountBalance - amount) < MIN_BALANCE)
                return "No withdrawl possilbe";
            _accountBalance -= amount;
            return $"{amount} is withdrawn.";
        }

        public void PrintAccountDetails()
        {
            Console.WriteLine($"Account Number : {_accountNumber}");
            Console.WriteLine($"Account Holder Name : {_accountHolderName}");
            Console.WriteLine($"Account Balance : {_accountBalance}");
            Console.WriteLine($"Aadhar Number : {_aadharNumber}");
            Console.WriteLine();
        }

        public void CheckAccountBalance()
        {
            Console.WriteLine($"The account balance for {_accountNumber} is {_accountBalance}\n");
        }

        public int GetAccountNumber()
        {
            return _accountNumber;
        }

        public double ReturnMaxBalance(Account[] accounts)
        {
            foreach (Account account in accounts)
            {
                if (account._accountBalance > MAXIMUM_BALANCE)
                {
                    MAXIMUM_BALANCE = account._accountBalance;
                }
            }
            return MAXIMUM_BALANCE;
        }
    }
}
