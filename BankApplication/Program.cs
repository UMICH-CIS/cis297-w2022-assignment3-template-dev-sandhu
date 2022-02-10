/// <summary>
/// // Exercise 11.8: Account Inheritance Hierarchy
/// Creating an Inheritance Hierarchy
/// </summary>
/// <Student>Gurnoor Singh Sandhu</Student>
/// <Class>CIS297</Class>
/// <Assignment>#3</Assignment>
/// <Semester>Winter 2022</Semester>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
        
               char selectAction;
               do 
               { 
                    CheckingAccount chek = new CheckingAccount();
                    
                    // user input and console output
                    int num;
                    Console.WriteLine("*******************UNIVERSITY OF MICHIGAN DEARBORN BANK*****************\n");
                    Console.WriteLine("Welcome to the University of Michigan, Dearborn bank! Please select a function to continue.");
                    Console.WriteLine("\nPress 1 to credit an amount from your account.");
                    Console.WriteLine("Press 2 to debit an amount from your account.");
                    Console.WriteLine("************************************************************************\n");
                    Console.Write("Input: ");
                    num = Convert.ToInt32(Console.ReadLine()); 
                    
                   // switch statement to pick credit or debit
                    switch (num)
                    {
                         case 1:
                              chek.Credit();
                              chek.CalculateIntrest();
                              break;
                         case 2:
                              chek.Debit();
                              chek.Fee();
                              break;
                         default: 
                              Console.WriteLine("Please make a valid input!!!");
                              break;
                    }
                    
                    Console.WriteLine("\nTo continue this program press (y/n)");
                    selectAction = Convert.ToChar(Console.ReadLine());

               } while (selectAction == 'y');
               Console.ReadKey();

        }
    }
}

// Account class with debit and credit methods
class Account
{
     public string depositorName;
     public double depositorAccount;
     public double total;
     public double depositorWithdraw;
     public double depositBalance;
     public double totalDeposit;

     double accountBalance = 1500.79; //Example number to represent the account balance
  
     public double ConstBalance //constructor with initial balance 
     {
         
          get { return accountBalance; }
          set { accountBalance = value; }
          
     }


     public void Credit()
     {
          Console.Write("\nPlease enter the Name of the depositor: ");
          depositorName = Console.ReadLine();

          Console.Write("Please enter your account number: ");
          depositorAccount = Convert.ToInt32(Console.ReadLine());
          
          Console.Write("Please enter the credit amount: ");
          depositBalance = Convert.ToDouble(Console.ReadLine());
          totalDeposit = ConstBalance + depositBalance;

          Console.WriteLine();
          Console.WriteLine("************************************************************************\n");
          Console.WriteLine("Hello: " + depositorName + "!");
          Console.WriteLine("Your account number is: " + depositorAccount);
          Console.WriteLine("Today the total balance in your account is: " + totalDeposit);
          Console.WriteLine();
          Console.WriteLine("************************************************************************\n");

     }
     
     public void Debit()
     {
          Console.Write("\nPlease enter the Name of the depositor: ");
          depositorName = Console.ReadLine();
          
          Console.Write("Please enter your account number: ");
          depositorAccount = Convert.ToInt32(Console.ReadLine());
          
          Console.Write("Please enter the withdrawl amount: ");
          depositorWithdraw = Convert.ToDouble(Console.ReadLine());

          if (depositorWithdraw <= ConstBalance)
          {
               totalDeposit = ConstBalance - depositorWithdraw;
               Console.WriteLine();
               Console.WriteLine("************************************************************************\n");
               Console.WriteLine("Hello: " + depositorName);
               Console.WriteLine("Your account number is: " + depositorAccount);
               Console.WriteLine("Today the total balance after withdrawl in your account is: " + totalDeposit);
               Console.WriteLine();
               Console.WriteLine("************************************************************************\n");
          }
          else
               Console.WriteLine("\n\nDebit amount exceeded account balance.");
     }

}

// SavingAccount class inheriting Account class, calculating interest
class SavingAccount : Account
{
     double interestRate;
     double totalRate;
     public void CalculateIntrest()
     {
          interestRate = 0.05;

          totalRate = totalDeposit * (interestRate / 100);
          total = totalDeposit + totalRate;
          Console.WriteLine("Today the total balance with interest in your account is: " + total);
     }

}

// SavingAccount class inheriting SavingsAccount class, applying transaction fees
class CheckingAccount : SavingAccount
{
     double TransactionFee = 3.99;
     public void Fee()
     {
          Console.WriteLine("Today the total balance with transaction charges in your account is: " + (totalDeposit - TransactionFee));
     }

}
