# ACME

The solution was made in a C# console application using Visual Studio 2019 with netframework 4.7.2

To open the project it is only needed to open the ACME PAYROLL.sln file in visual Studio
The tests uses the Unit Test Project (.NetFramework)

The .txt file with the data set is in the root of the project


To run the project just open the solution in visual studio an push the "Start" button at the top of Visual Studio.
To test the project push the "Test" button in the menu bar of Visual Studio, then select the "Run all tests" option.


Explanation of the solution:

The solution was made using Multitier architecture where de Data tier is in charge of connecting to the .txt file. The Logic tier is where all the calculations are made. The Presentation tier shows the data in the console.  

1. The way it works is by first reading the .txt file with the raw data of the employees.
2. Then with each line of the file creates an object Employee with the name and an array of all the days and hours the employee worked.
3. Then saves all the employees that were created in a list.
4. For each employee that exists calculates the amount to pay.
5. the amount to pay is calculated by first spliting all the days in an array.
6. Then it obtains the day and the range of hours the employee worked that day. 
7. it verifies if the day is weekend or weekday and obtain the type of pay corresponding to the day.
8. Checks where the start and the end of the shift of the employee lands in the schedule(00:01 - 09:00, 09:01 - 18:00, 18:01 - 00:00).  
9. Calculate the amount to pay each day by multiplying the amount of hours the employee worked and the pay corresponding to the type of day and the type of schedule. 
10. Repeat for all the days the employee worked and adds up the pay for each day. 
