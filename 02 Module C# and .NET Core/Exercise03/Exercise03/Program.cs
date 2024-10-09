// Practice loops and operators

using System;
// FizzBuzz
for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}


// Infinite loop

//int max = 500;
//for (byte i = 0; i < max; i++)
//{
//    Console.WriteLine(i);
//}
// Firstly, it would return an error: The name 'WriteLine' does not exist in the current context.
// After fixing this, it would loop infinitely. Because the byte type has an value range from 0 to 255.
// Once i reaches 255, the next increment will cause the byte value to wrap around to 0.
// Therefore, it is an infinite loop.

// To warn the problem:

int max = 500;
byte previousValue = 0;
for (byte i = 0; i < max; i++)
{
    Console.WriteLine(i);

    // Check if the byte has overflowed
    if (i < previousValue)
    {
        Console.WriteLine("Warning: Byte overflow occurred at i = " + i);
        break;
    }
    previousValue = i;
}


// Guess random number
int minNum = 1;
int maxNum = 3;
int correctNumber = new Random().Next(minNum, maxNum + 1);

bool correct = false;

while (!correct)
{
    Console.WriteLine("Guess a number between 1 and 3:");
    int guessedNumber = int.Parse(Console.ReadLine());

    if (guessedNumber < minNum ||  guessedNumber > maxNum)
    {
        Console.WriteLine("Out of range!");
    }
    else if (guessedNumber > correctNumber)
    {
        Console.WriteLine("Too high!");
    }
    else if (guessedNumber < correctNumber)
    {
        Console.WriteLine("Too low!");
    }
    else
    {
        Console.WriteLine("Correct! Good job!");
        correct = true;
    }
}


// print a pyramid
int n = 5;

for (int i = 1; i <= n; i++)
{
    for (int j = 0; j < n - i; j++)
    {
        Console.Write(" ");
    }
    for (int k = 0; k < (2 * i - 1); k++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}


// Age in days calculator

Console.Write("Enter your birth date (yyyy-mm-dd): ");
DateTime birthDate = DateTime.Parse(Console.ReadLine());

// Calculate how many days old the person is
DateTime currentDate = DateTime.Now;
int ageInDays = (currentDate - birthDate).Days;

Console.WriteLine($"You are {ageInDays} days old.");

// Calculate the next 10,000-day anniversary
int daysToNextAnniversary = 10000 - (ageInDays % 10000);
DateTime nextAnniversary = currentDate.AddDays(daysToNextAnniversary);

Console.WriteLine($"Your next 10,000-day anniversary will be on: {nextAnniversary.ToString("yyyy-MM-dd")}");


// greeting
DateTime currentTime = DateTime.Now;
int currentHour = currentTime.Hour;

if (currentHour >= 5 && currentHour < 12)
{
    Console.WriteLine("Good Morning");
}
if (currentHour >= 12 && currentHour < 17)
{
    Console.WriteLine("Good Afternoon");
}
if (currentHour >= 17 && currentHour < 21)
{
    Console.WriteLine("Good Evening");
}
if ((currentHour >= 21 && currentHour <= 23) || (currentHour >= 0 && currentHour < 5))
{
    Console.WriteLine("Good Night");
}


// counting 
int countNum = 24;
int outerNum = 4;
for (int outer = 1; outer <= outerNum; outer++)
{
    for (int inner = 0; inner <= countNum; inner += outer)
    {
        Console.Write(inner);

        if (inner + outer <= countNum)
        {
            Console.Write(",");
        }
    }
    Console.WriteLine();
}