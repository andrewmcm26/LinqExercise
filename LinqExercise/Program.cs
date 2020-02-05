using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());

            Console.WriteLine();
            //Order numbers in ascending order and decsending order. Print each to console.
            var ascendingNumbers = numbers.OrderBy(item => item);
            Console.WriteLine("Ascending Numbers:");
            foreach (int i in ascendingNumbers)
                Console.WriteLine(i);

            var decsendingNumbers = numbers.OrderByDescending(item => item);
            Console.WriteLine("Descending Numbers");
            foreach (int i in decsendingNumbers)
                Console.WriteLine(i);
            Console.WriteLine();
            //Print to the console only the numbers greater than 6
            var greaterThan6 = numbers.Where(item => item>6);
            Console.WriteLine("Retruning numbers in array greater than 6:");
            foreach (int i in greaterThan6)
                Console.WriteLine(i);

            Console.WriteLine();
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var newNumbers = numbers.OrderBy(item => item).Take(4);
            Console.WriteLine("Printing first 4 digits:");
            foreach (var i in newNumbers)
                Console.WriteLine(i);

            Console.WriteLine();
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(23, 4);
            var numbersWithAge = numbers.OrderByDescending(item => item);
            Console.WriteLine("Writing numbers with my age:");
            foreach (var i in numbersWithAge)
                Console.WriteLine(i);

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            Console.WriteLine();
            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var employeesCOrS = employees.Where(item => item.FirstName.ToLower().StartsWith('c')
            || item.FirstName.ToLower().StartsWith('s')).OrderBy(item => item.FirstName);
            Console.WriteLine("Writing Employees with first name starting with" +
                " 'C' or 'S':");
            foreach (var i in employeesCOrS)
                Console.WriteLine(i.FullName);

            Console.WriteLine();
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var employeesOver26 = employees.Where(item => item.Age > 26).OrderBy(item => item.Age)
                .ThenBy(item => item.FirstName);
            Console.WriteLine("Employees over 26:");
            foreach (var i in employeesOver26)
                Console.WriteLine($"{i.Age} {i.FullName} ");

            Console.WriteLine();
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var employeesA = employees.Where(item => item.YearsOfExperience <= 10
            && item.Age > 35);
            var employeesASumYOE = employeesA.Sum(item => item.YearsOfExperience);
            var employeesAAvgYOE = employeesA.Average(item => item.YearsOfExperience);
            Console.WriteLine("Sum and average of employees YOE " +
                "with less than 10 YOE and over 35");
            Console.WriteLine(employeesASumYOE);
            Console.WriteLine(employeesAAvgYOE);

            Console.WriteLine();
            //Add an employee to the end of the list without using employees.Add()
            var newEmployee = new Employee("Andrew", "McMahon", 23, 100);
            employees.Insert(employees.Count, newEmployee);
            Console.WriteLine("Full name of employees with new employee:");
            foreach(var i in employees)
            Console.WriteLine(i.FullName);

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 32, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
