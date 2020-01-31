﻿using System;
using System.IO;
using System.Collections;

namespace SavingsCalculator
{
    class Program
    {
        //function to calculate federal tax rate.
        static double FedTaxDeduction(double salary) {
            double govtCut = 0, rate = 0;

            if(salary > 0 && salary <= 9875)
            {
                rate = 0.10;
            }
            else if(salary > 9875 && salary <= 40125)
            {
                rate = 0.12;
            }
            else if(salary > 40125 && salary <= 85525)
            {
                rate = 0.22;
            }
            else if(salary > 85525 && salary <= 163300)
            {
                rate = 0.24;
            }
            else if(salary > 163300 && salary <= 207350)
            {
                rate = 0.32;
            }
            else if(salary > 207350 && salary <= 518400){
                rate = 0.35;
            }
            else if(salary > 518400)
            {
                rate = 0.37;
            }

            govtCut = salary * rate;

            return govtCut;
        }

        static double NJStatesCut(double salary)
        {
            double rate = 0, stateCut = 0;
            if (salary > 0 && salary <= 20000)
            {
                rate = 0.014;
            }
            else if (salary > 20000 && salary <= 35000)
            {
                rate = 0.0175;
            }
            else if (salary > 35000 && salary <= 40000)
            {
                rate = 0.035;
            }
            else if (salary > 40000 && salary <= 75000)
            {
                rate = 0.05525;
            }
            else if(salary > 75000 && salary <= 500000) 
            {
                rate = 0.0637;
            }
            else if(salary > 500000 && salary <= 50000000)
            {
                rate = 0.0897;
            }
            else if(salary > 5000000)
            {
                rate = 0.1075;
            }

            stateCut = salary * rate;
            return stateCut;
        }

        static double PAStateCut(double salary)
        {
            double statecut = salary * 0.0307;
            return statecut;
        }
        static void Main(string[] args)
        {
            Console.Write("Please enter your yearly salary: ");

            double salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Your yearly salary is:" + salary);

            Console.Write("What state do you live in?");

            String state = Console.ReadLine();

            double govCut=0, stateCut=0, adjsustedEarnings;

            govCut = FedTaxDeduction(salary);

            adjsustedEarnings = salary - govCut;
            Console.WriteLine("After federal taxes your income is " + adjsustedEarnings);

            if(state.Equals("NJ") || state.Equals("nj"))
            {
                stateCut = NJStatesCut(adjsustedEarnings);
            }
            else if(state.Equals("PA") || state.Equals("pa"))
            {
                stateCut = PAStateCut(adjsustedEarnings);
            }

            adjsustedEarnings -= stateCut;
            Console.Write("Your state taxes are " +stateCut +"so your adjusted earnings are " + adjsustedEarnings);

            double weeklyIncome = adjsustedEarnings / 52; 
            double monthlyIncome = adjsustedEarnings / 12;

            Console.WriteLine("Weekly Income: " + weeklyIncome);
            Console.WriteLine("Monthly Income: " + monthlyIncome);

            Console.Write("Do you pay any rent?");
            String isRent = Console.ReadLine();

            if(isRent.Contains("y") || isRent.Contains("Y")) {
                Console.Write("Enter your monthly rent payment: ");
                double rent = Convert.ToDouble(Console.Read());

                if(rent > monthlyIncome) {
                    Console.WriteLine("Your rent is more than your monthly income. You should re-evaluate your finances.");
                } else {
                    adjsustedEarnings -= (rent * 12); 
                    weeklyIncome = adjsustedEarnings / 52;
                    monthlyIncome = adjsustedEarnings / 12; 
                    
                    Console.Write("After the year of rent, income is adjusted to: " +adjsustedEarnings);
                    Console.WriteLine("Weekly Income: " + weeklyIncome);
                    Console.WriteLine("Monthly Income: " + monthlyIncome);

                }
            }

            Console.Write("Do you have any loan payments?");
            String isLoan = Console.ReadLine();

            if(isLoan.Contains("y") || isLoan.Contains("Y")) {

            }
        }
    }


}
