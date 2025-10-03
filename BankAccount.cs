using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Bankaccount
{
    public class ZeroOrNegativeDeposit : Exception
    {
        public ZeroOrNegativeDeposit(string error) : base(error) { }
    }
    public class ZeroOrNegativeWithdraw : Exception
    {
        public ZeroOrNegativeWithdraw(string error) : base(error) { }
    }
    public class MaximumDepositException : Exception
    {
        public MaximumDepositException(string error) : base(error) { }
    }
    public class MaximumWithDrawException : Exception
    {
        public MaximumWithDrawException(string error) : base(error) { }
    }
    public class Program
    {
        public static void HoldMain()
        {
            /*
            var bankaccount = new BankAccount();
            bankaccount.Deposit(1000m);
            decimal p = 10000;
            decimal n = 24;
            decimal r = 10;
            var result = CalculateSimpleInterest(p, n, r);
            Console.WriteLine("Simple Interest: "+result);
            Console.WriteLine("Total Amount to be Paid: "+ (p + result));

            double p = 10000;
            double r = 10;
            double n = 3;

            var CI = CalculateCompoundInterest(p,r,n);
            Console.WriteLine("Compound Interest: "+Math.Round(CI));
            Console.WriteLine("Total Amount needs to Paid: "+ Math.Round(p+ CI));

            Console.WriteLine(AssignUniqueTransactionId());
            */
            
            Console.ReadLine();
        }
        public static decimal CalculateSimpleInterest(decimal principle, decimal timeperiod, decimal rateOfinterest)
        {
            return (principle * (timeperiod / 12) * rateOfinterest) / 100;
        }
        public static double CalculateCompoundInterest(double principle, double rateofInterest, double timePeriod)
        {
            return (principle * Math.Pow((1 + rateofInterest / 100), timePeriod));
        }
        public static string AssignUniqueTransactionId()
        {
            return Guid.NewGuid().ToString("P");
        }
    }
    public class BankAccount
    {
        /*
        Deposit method: 
        - check whether the input number is non negative and greater than 0. 
        - handle an overflow exception
        - a maximum deposit amount for a account. 


        documentation: 
        - we need to put a validation check whether the number is greater than 0 or not. 
        - then we need to check , for that day the maximum deposit amount already reached or not. so we need to 
        check for the day and the amount received and it reach the maximum amount for a day. 
        - handle an overflow exception. 
        */
        private static decimal _initialbalance = 0m;
        private readonly static decimal _maximumDepositamount = 10000m;
        private readonly static decimal c = 10000m;
        private static decimal _totaldepositamount = 0m;
        private static decimal _totalwithdrawamount = 0m;
        public void Deposit(decimal amount)
        {
            try
            {
                if (amount < 1)
                {
                    throw new ZeroOrNegativeDeposit("an zero or negative deposit found.");
                }
                _totaldepositamount += amount;
                if (_totaldepositamount > _maximumDepositamount)
                {
                    throw new MaximumDepositException("Maximum Deposit amount Reaches");
                }
                _initialbalance += amount;
                Console.WriteLine($"Deposit of amount {amount} done at {DateTime.Now} remaining balance {_initialbalance}");
            }
            catch (MaximumDepositException ec)
            {
                Console.WriteLine("Exception occurs: " + ec.Message);
            }
            catch (ZeroOrNegativeDeposit err)
            {
                Console.WriteLine("Exception occurs: " + err.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled Exception Occurs" + ex.Message);
            }
        }
        public decimal GetBalance()
        {
            return _initialbalance;
        }
        /*
        Documentation for withdraw: 
        - check for non negative numbers. 
        - check whether the withdrawel amount should be less than balance amount. 
        - daily withdraw limit. 
        */

        public void Withdraw(decimal amount)
        {
            if (amount < 1)
            {
                throw new ZeroOrNegativeWithdraw("an zero or negative withdraw found.");
            }
            _totalwithdrawamount += amount;
            if (_totaldepositamount > _totalwithdrawamount)
            {
                throw new MaximumWithDrawException("maximum withdraw amount reached.");
            }
            _initialbalance -= amount;
            Console.WriteLine($"Withdrawal of amount {amount} done at {DateTime.Now} remaining balance {_initialbalance}");
        }
    }
}
