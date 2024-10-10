using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment03;

class Program
{
    static void Main(string[] args)
    {
        // Working with methods

        // 1. reverse array
        int[] numbers = GenerateNumbers();
        Reverse(numbers);
        PrintNumbers(numbers);

        // 2. Fibonacci
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Fibonacci({i}) = {Fibonacci(i)}");
        }


        // Designing and Building Classes using object-oriented principles

        // Create a department
        Department csDepartment = new Department("Computer Science", null, 1000000, new DateTime(2024, 1, 1), new DateTime(2024, 12, 31));

        // Create an instructor and set as head of department
        Instructor instructor1 = new Instructor("Jane Smith", new DateTime(1980, 8, 12), 50000, new DateTime(2010, 7, 1), csDepartment);
        csDepartment.SetHeadOfDepartment(instructor1);

        Console.WriteLine($"Instructor: {instructor1.GetName()}, Age: {instructor1.CalculateAge()}, Salary: {instructor1.CalculateSalary()}, Department: {csDepartment.GetDepartmentName()}");

        // Create a course and add it to the department
        Course course1 = new Course("Math 101");
        csDepartment.AddCourse(course1);

        // Create a student and enroll them in the course
        Student student1 = new Student("John Doe", new DateTime(2000, 5, 15), csDepartment);
        course1.EnrollStudent(student1);
        student1.AddCourse(course1, 'A');

        // Display student information
        Console.WriteLine($"Student: {student1.GetName()}, Age: {student1.CalculateAge()}, GPA: {student1.CalculateGPA()}, Department: {csDepartment.GetDepartmentName()}");

        // Display course information and enrolled students
        Console.WriteLine($"Course: {course1.GetCourseName()}, Enrolled Students: {course1.GetEnrolledStudents().Count}");
        foreach (var student in course1.GetEnrolledStudents())
        {
            Console.WriteLine($"  - {student.GetName()}");
        }

        // Display department information
        Console.WriteLine($"Department: {csDepartment.GetDepartmentName()}, Budget: {csDepartment.GetBudget()}");
        Console.WriteLine($"Head of Department: {csDepartment.GetHeadOfDepartment().GetName()}");
        Console.WriteLine($"Courses Offered: {csDepartment.GetCourses().Count}");


        // Create Color instances
        Color redColor = new Color(255, 0, 0);
        Color greenColor = new Color(0, 255, 0);
        Color blueColor = new Color(0, 0, 255);

        // Create Ball instances
        Ball redBall = new Ball(10, redColor);
        Ball greenBall = new Ball(15, greenColor);
        Ball blueBall = new Ball(12, blueColor);

        // Throw the balls
        redBall.Throw();
        redBall.Throw();
        greenBall.Throw();
        greenBall.Throw();
        greenBall.Throw();
        blueBall.Throw();

        // Pop the red ball and try to throw it again
        redBall.Pop();
        Console.WriteLine("Red ball size: " + redBall.GetSize());
        redBall.Throw();  // This should not increase the throw count

        // Display the throw counts
        Console.WriteLine("Red ball throw count: " + redBall.GetThrowCount());
        Console.WriteLine("Green ball throw count: " + greenBall.GetThrowCount());
        Console.WriteLine("Blue ball throw count: " + blueBall.GetThrowCount());

        // Display the grayscale values of the ball colors
        Console.WriteLine("Red ball grayscale: " + redColor.GetGrayscale());
        Console.WriteLine("Green ball grayscale: " + greenColor.GetGrayscale());
        Console.WriteLine("Blue ball grayscale: " + blueColor.GetGrayscale());
    }

    // Reverse array
    static int[] GenerateNumbers(int length = 10)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = i + 1;
        }
        return numbers;
    }
    static void Reverse(int[] array)
    {
        int arrayLength = array.Length;
        for (int i = 0; i < arrayLength / 2; i++)
        {
            //int temp = array[i];
            //array[i] = array[arrayLength - i - 1];
            //array[arrayLength - i - 1] = temp;
            (array[i], array[arrayLength - i - 1]) = (array[arrayLength - i - 1], array[i]);
        }
    }
    static void PrintNumbers(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    static int Fibonacci(int n)
    {
        if (n == 1 || n == 2)
        {
            return 1;
        }
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}





