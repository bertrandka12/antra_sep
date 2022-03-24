/*
01 Introduction to C# and Data Types
Understanding Data Types
Test your Knowledge 

1.What type would you choose for the following “numbers”? 
A person’s telephone number -->int
A person’s height --> float
A person’s age--> int
A person’s gender (Male, Female, Prefer Not To Answer) --> sring
A person’s salary  --> decimal
A book’s ISBN -->string
A book’s price --> decimal
A book’s shipping weight --> float
A country’s population --> double 
The number of stars in the universe --> decimal
The number of employees in each of the small or medium businesses in the 
United Kingdom (up to about 50,000 employees per business) --> double

2. What are the difference between value type and reference type variables? What is boxing and unboxing?

--> Value type variables directly hold the value WHILE Reference types hold the memory address for this value

3. What is meant by the terms managed resource and unmanaged resource in .NET
--> Managed resources are those that are pure .NET code and managed by the runtime and are under its direct control

WHILE
--> Unmanaged resources are those that run outside the .NET runtime

4. Whats the purpose of Garbage Collector in .NET? 
-->Garbage collector manages the allocation and release of memory for your application.


**Playing with Console App

Modify your console application to display a different message. Go ahead and 
intentionally add some mistakes to your program, so you can see what kinds of error messages you get from the compiler.
The more familiar you are with these messages, and what causes them, the better you'll be at diagnosing problems in your
programs that you /didn't/ intend to add!

Using just the ReadLine and WriteLine methods and your current knowledge of variables,
you can have the user pass in quite a few bits of information. Using this approach, create a
console application that asks the user a few questions and then generates some custom 
output for them. For instance, your program could generate their "hacker name" by asking
them their favorite color, their astrology sign, and their street address number. The result
might be something like "Your hacker name is RedGemini480."
Practice number sizes and ranges

1.Create a console application project named /02UnderstandingTypes/ that outputs the
number of bytes in memory that each of the following number types uses, and the minimum and
maximum values they can have: sbyte, byte, short, ushort, int, uint, long, ulong, float, double, and decimal.

using System;

namespace _02UnderstandingTypes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"sbyte bytes memory:"+ sizeof(sbyte) +", MIN:"+ sbyte.MinValue+", MAX:"+ sbyte.MaxValue );
            Console.WriteLine($"byte bytes memory:" + sizeof(byte) + ", MIN:" + byte.MinValue + ", MAX:" + byte.MaxValue);
            Console.WriteLine($"short bytes memory:" + sizeof(short) + ", MIN:" + short.MinValue + ", MAX:" + short.MaxValue);
            Console.WriteLine($"ushort bytes memory:" + sizeof(ushort) + ", MIN:" + ushort.MinValue + ", MAX:" + ushort.MaxValue);
            Console.WriteLine($"int bytes memory:" + sizeof(int) + ", MIN:" + int.MinValue + ", MAX:" + int.MaxValue);
            Console.WriteLine($"uint bytes memory:" + sizeof(uint) + ", MIN:" + uint.MinValue + ", MAX:" + uint.MaxValue);
            Console.WriteLine($"long bytes memory:" + sizeof(long) + ", MIN:" + long.MinValue + ", MAX:" + long.MaxValue);
            Console.WriteLine($"ulong bytes memory:" + sizeof(ulong) + ", MIN:" + ulong.MinValue + ", MAX:" + ulong.MaxValue);
            Console.WriteLine($"float bytes memory:" + sizeof(float) + ", MIN:" + float.MinValue + ", MAX:" + float.MaxValue);
            Console.WriteLine($"double bytes memory:" + sizeof(double) + ", MIN:" + double.MinValue + ", MAX:" + double.MaxValue);
            Console.WriteLine($"decimal bytes memory:" + sizeof(decimal) + ", MIN:" + decimal.MinValue + ", MAX:" + decimal.MaxValue);

        }
    }
}


2.Write program to enter an integer number of centuries and convert it to years, days, hours,
minutes, seconds, milliseconds, microseconds, nanoseconds.  Use an appropriate data type for every data conversion.
Beware of overflows!

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer number of centuries:");
            double centuries = Convert.ToInt64(Console.ReadLine());

            double years = centuries * 100;
            double days = years * 365.24;
            double hours = days * 24;
            double minutes = hours * 60;
            double seconds = minutes * 60;
            double milliseconds = seconds * 1000;
            double microseconds = milliseconds * 1000;
            double nanoseconds = microseconds * 1000;

            Console.Write(centuries + " centuries =");
            Console.Write(years + " years = ");
            Console.Write(days + " days = ");
            Console.Write(hours + " hours = ");
            Console.Write(minutes + " minutes = ");
            Console.Write(seconds + " seconds = ");
            Console.Write(milliseconds + " milliseconds = ");
            Console.Write(microseconds + " microseconds = ");
            Console.Write(nanoseconds + " nanoseconds ");

        }
    }
}


**Controlling Flow and Converting Types
Test your Knowledge
1.What happens when you divide an int variable by 0? --> it gives an error message warning you about division by 0 and the program fails to run 
2.What happens when you divide a double variable by 0? --> it gives an output of infinity
3.What happens when you overflow an int variable, that is, set it to a value beyond its
range? --> the memory will overflow and the value will get negative
4.What is the difference between x = y++; and x = ++y;? --> y++ is incremmenting the value of y by one while x= ++y is like adding x to y then storing the result in x
5.What is the difference between break, continue, and return when used inside a loop
statement?
-->break: is for leaving a scope/ getting out of a scope/method/function
-->continue: is for getting back into a scope and continuing where it was left at
--> return: is for ending a scope with a value or result stored in it 
6.What are the three parts of a for statement and which of them are required?
--> the 3 parts are initialization, condition and iteration
-->in a for loop they are all required

7.What is the difference between the = and == operators?
--> =: is an assignment operator
--> ==: is for comparison
8.Does the following statement compile? for ( ; true; ) ;
--> it does not compile because clearly there are some varibles/statements missing in the for loop 
9.What does the underscore _ represent in a switch expression?
--> the (_) replaces the default keyword to mean that it should match anything if reached

10.What interface must an object implement to be enumerated over by using the foreach
statement?
--> the IEnumerable interface


**Practice loops and operators
1. FizzBuzz is a group word game for children to teach them about division. Players take turns
to count incrementally, replacing any number divisible by three with the word /fizz/, any
number divisible by five with the word /buzz/, and any number divisible by both with /fizzbuzz/.
Create a console application in Chapter03 named Exercise03 that outputs a simulated
FizzBuzz game counting up to 100. The output should look something like the following
screenshot:
What will happen if this code executes?

int max =500;
for(byte i =0; i < max; i++){
WriteLine(i);
}

-->the above code if run, it would add up the variable i from 1 up to the max = 500 


Create a console application  and enter the preceding code. Run the console application
and view the output. What happens?
-->it gives an error becasue it just says WriteLine instead of Console.WriteLine so hence the application doesn't recognise the line
What code could you add (don’t change any of the preceding code) to warn us about the
problem? -->you just have to add the Console. infront of the WriteLine
Your program can create a random number between 1 and 3 with the following code:

int correctNumber =newRandom().Next(3)+1;



1. Write a program that generates a random number between 1 and 3 and asks the user to
guess what the number is. Tell the user if they guess low, high, or get the correct answer.
Also, tell the user if their answer is outside of the range of numbers that are valid guesses
(less than 1 or more than 3). You can convert the user's typed answer from a string to an int
using this code:

int guessedNumber =int.Parse(Console.ReadLine());
Note that the above code will crash the program if the user doesn't type an integer value.
For this exercise, assume the user will only enter valid guesses.

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int correctNumber = newRandom().Next(3) + 1;

            Console.WriteLine("Enter a guess of the next random number:");
            int guessedNumber = int.Parse(Console.ReadLine());
            if(guessedNumber > 3 || guessedNumber < 1)
            {
                Console.WriteLine("the number is out of range should be 1-3");
            }
            if(guessedNumber == correctNumber)
            {
                Console.WriteLine("congrats you guessed it right the number is " + correctNumber);
            }
            else
            {
                Console.WriteLine("the number is " + correctNumber);

            }
        }

    }
}


2.Print-a-Pyramid.Like the star pattern examples that we saw earlier, create a program that
will print the following pattern: If you find yourself getting stuck, try recreating the two
examples that we just talked about in this chapter first. They’re simpler, and you can compare
your results with the code included above. This can actually be a pretty challenging problem, so
here is a hint to get you going. I used three total loops. One big one contains two smaller loops.
The bigger loop goes from line to line. The first of the two inner loops prints the correct
number of spaces, while the second inner loop prints out the correct number of stars.

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i< 5; i++)
            {
                for (int k = 5-1; k >0; k-- )
                {
                    Console.WriteLine(" ");
                }
                for(int j = 1; j<i; j++)
                {
                    Console.WriteLine("* ");
                }
                Console.WriteLine("\n");

            }
        }

    }
}



3.Write a program that generates a random number between 1 and 3 and asks the user
to guess what the number is. Tell the user if they guess low, high, or get the correct answer.
Also, tell the user if their answer is outside of the range of numbers that are valid guesses
(less than 1 or more than 3). You can convert the user's typed answer from astring to anint using this code:

int guessedNumber =int.Parse(Console.ReadLine());

Note that the above code will crash the program if the user doesn't type an integer value.
For this exercise, assume the user will only enter valid guesses.

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int correctNumber = newRandom().Next(3) + 1;

            Console.WriteLine("Enter a guess of the next random number:");
            int guessedNumber = int.Parse(Console.ReadLine());

            if(guessedNumber == correctNumber)
            {
                Console.WriteLine("congrats you guessed it right the number is " + correctNumber);
            }
            else
            {
                Console.WriteLine("the number is " + correctNumber);

            }
        }

    }
}


4. Write a simple program that defines a variable representing a birth date and calculates
how many days old the person with that birth date is currently.
For extra credit, output the date of their next 10,000 day (about 27 years) anniversary.
Note: once you figure out their age in days, you can calculate the days until the next
anniversary using
int daysToNextAnniversary = 10000 - (days % 10000);





5. Write a program that greets the user using the appropriate greeting for the time of day. Use only
if, not else or switch, statements to do so. Be sure to include the following
greetings:
"Good Morning"
"Good Afternoon"
"Good Evening"
"Good Night"
It's up to you which times should serve as the starting and ending ranges for each of the
greetings. If you need a refresher on how to get the current time, see
DateTime
Formatting. When testing your program, you'll probably want to use a
DateTime variable you define, rather than the current time. Once you're confident the program works correctly, you can substitute DateTime.Now
for your variable (or keep your variable and just assign DateTime.Now
as its value, which is often a better approach).



using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currDateTime = DateTime.Now;
            //DateTime currentDateTime = new DateTime(2017, 9, 3, 8, 4, 0); //Test data
            int currentHour = currDateTime.Hour;
            int startMorningHour = 6;
            int startAfternoonHour = 12;
            int startEveningHour = 17;
            int startNightHour = 22;

            if (startMorningHour <= currentHour && currentHour < startAfternoonHour)
            {
                Console.WriteLine("Good morning!");
            }

            if (startAfternoonHour <= currentHour && currentHour < startEveningHour)
            {
                Console.WriteLine("Good Afternoon!");
            }

            
            if (startEveningHour <= currentHour && currentHour < startNightHour)
            {
                Console.WriteLine("Good Evening!");
            }

            
            if (startNightHour <= currentHour || currentHour < startMorningHour)
            {
                Console.WriteLine("Good Night!");
            }

            

            Console.WriteLine("ASof now it's {0}:{1} o'clock.", currDateTime.Hour, currDateTime.Minute);
        }

    }
}





6. Write a program that prints the result of counting up to 24 using four different increments.
First, count by 1s, then by 2s, by 3s, and finally by 4s.
Use nested for loops with your outer loop counting from 1 to 4. You inner loop should count from 0 to 24,
but increase the value of its /loop control variable/ by the value of the /loop control variable/ from the outer loop.
This means the incrementing in the / afterthought/ expression will be based on a variable.
Your output should look something like this:
0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24
0,2,4,6,8,10,12,14,16,18,20,22,24
0,3,6,9,12,15,18,21,24
0,4,8,12,16,20,24



using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int countBase = 1; countBase <= 24; countBase += 1)
            {
                Console.Write(countBase.ToString().PadLeft(4) + "|");
                for (int countUp = 0; countUp <= 24; countUp += countBase)
                {
                    Console.Write(countUp.ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }

    }
}


*/




