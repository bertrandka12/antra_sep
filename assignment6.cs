/*

02  Arrays and Strings
Test your Knowledge
1.When to use String vs. StringBuilder in C# ?
--> String is in System namespace while
-->StringBuilder is in System.Text namespace

2.What is the base class for all arrays in C#?
--> Array class

3.How do you sort an array in C#?
--> to sort an array , we use Array.Sort()

4.What property of an array object can be used to get the total number of elements in an array?
--> it's the length property

5.Can you store multiple data types in System.Array?
--> yes you can store multiple data types in it

6.What’s the difference between the System.Array.CopyTo() and System.Array.Clone()?
--> the clone() returns a new array object containing all the elements in the original array.
--> the copy() method just copies the elements into another existing array.

Practice Arrays

1. Copying an Array

Write code to create a copy of an array.
First, start by creating an initial array. (You can use whatever type of data you want.)
Let’s start with 10 items. Declare an array variable and assign it a new array with 10 items in it.
Use the things we’ve discussed to put some values in the array.
Now create a second array variable.
Give it a new array with the same length as the first. Instead of using a number for this length,
use the Lengthproperty to get the size of the original array. Use a loop to read values from the original
array and place them in the new array. Also print out the contents of both arrays, to be sure everything
copied correctly.
*/

//using System;

//namespace _02UnderstandingTypes
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr1 = new int[10] { 1,2,3,5,6,7,4,8,0,9};
//            int[] arr2 = new int[arr1.Length];

//            for(int i=0; i< arr1.Length; i++)
//            {
//                arr2[i] = arr1[i];

//            }
//            Console.Write("arr1: ");
//            foreach (int i in arr1)
//            {
//                Console.Write(arr1[i]+", ");
//            }
//            Console.Write("\n arr2: ");
//            foreach (int i in arr2)
//            {
//                Console.Write(arr2[i] + ", ");
//            }

//        }
//    }
//}


/*
2.Write a simple program that lets the user manage a list of elements. It can be a grocery list, "to do" list, etc.
Refer to Looping Based on a Logical Expression if necessary to see how to implement an infinite loop. Each time
through the loop, ask the user to perform an operation, and then show the current contents of their list. The operations
available should be Add, Remove, and Clear. The syntax should be as follows:

+ some item
- some item
--

Your program should read in the user's input and determine if it begins with a  “+” or “-“ or
if it is simply  “—-“ . In the first two cases, your program should add or remove the string given
("some item" in the example). If the user enters just “—“ then the program should clear the current list.
Your program can start each iteration through its loop with the following instruction:

Console.WriteLine("Enter command (+ item, - item, or -- to clear)):")
*/
//using System;

//namespace _02UnderstandingTypes
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Welcome to your packlist. You can add items, remove items or clear");
//            //Console.WriteLine("Do you want to continue?  Press 1 for yes or 2 for exit");
//            //int userChoice = Convert.ToInt16(Console.ReadLine());
//            String[] arr1 = new string[10];

//            String[] userInput;
//            for (int i = 0; i < arr1.Length; i++)
//            {
//                Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
//                userInput = Console.ReadLine();

//                switch (userInput[0])
//                {
//                    case "+ ":
//                        {
//                            arr1.CopyTo(userInput, 0);
//                            break;
//                        }

//                    case "- ":
//                        {
//                            arr1[i] = "";
//                            break;
//                        }

//                    case "--":
//                        {
//                            Array.Clear(arr1, 0, arr1.Length);
//                            break;
//                        }

//                }
//            }



//        }
//    }
//}


/*
3.Write a method that calculates all prime numbers in given range and returns them as array of integers

static int[] FindPrimesInRange(startNum, endNum)
{
}
*/



//static int[] FindPrimesInRange(int startNum, int endNum)
//{
//    startNum = 0;
//    endNum = 9;
//    int total = 0;
//    int[] arr1 = new int[5];
//    for (int i = startNum; i <= endNum; i++)
//    {
//        int count = 0;
//        for (int j = 2; j <= Math.Sqrt(i); j++)
//        {
//            if (i % j == 0)
//            { count++; break; }

//        }
//        if (count == 0 && i > 1)
//        {
//            total++;
//            Console.WriteLine("Prime Number -> %d\n", i);

//        }
//    }

//}



/*
4.Write a program to read an array of n integers (space separated on a single line) and an integer k,
rotate the array right ktimes and sum the obtained arrays after each rotation as shown below.
After r rotations the element at position I goes to position (I + r) % n.
The sum[] array can be calculated by two nested loops: for r = 1 ... k; for I = 0 ... n-1.
*/



/*
5. Write a program that finds the longest sequence of equal elements in an array of integers.
If several longest sequences exist, print the leftmost one.

*/

//public class MaxSequenceOfEqualElements
//{
//    public static void Main()
//    {
//        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
//        int maxLength = -1;
//        int endIndex = 0;
//        int length = 0;

//        for (int i = 0; i < numbers.Length - 1; i++)
//        {
//            if (numbers[i] == numbers[i + 1])
//            {
//                length++;
//                if (i + 1 == numbers.Length - 1 && maxLength < length)
//                {
//                    maxLength = length;
//                    endIndex = i + 1;
//                }
//            }
//            else
//            {
//                if (maxLength < length)
//                {
//                    maxLength = length;
//                    endIndex = i;
//                }
//                length = 0;
//            }
//        }

//        PrintMaxSeqOfEqualElements(maxLength, endIndex, numbers);
//    }

//    private static void PrintMaxSeqOfEqualElements(int maxLength, int endIndex, int[] numbers)
//    {
//        for (int i = 0; i < maxLength + 1; i++)
//        {
//            Console.Write(numbers[endIndex] + " ");
//        }
//    }
//}


/*
7. Write a program that finds the most frequent number in a given sequence of numbers.
In case of multiple numbers with the same maximal frequency, print the leftmost of them

public class MostFrequentNumber
{
    public static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int maxCount = 0;
        int mostFrequentNum = 0;

        foreach (var num in numbers)
        {
            int count = numbers.Count(x => x == num);
            if (count > maxCount)
            {
                maxCount = count;
                mostFrequentNum = num;
            }
        }

        Console.WriteLine(mostFrequentNum);
    }
}

*/
