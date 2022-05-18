using System;

namespace Multi_Dimension_Arrays
{
    internal class Program
    {
        const int num_of_students = 5;
        const int num_of_grades = 12;

        static void Main(string[] args)
        {
            int[,] students = new int[num_of_students, num_of_grades];
            int counter = 0;
            Random rnd = new Random();

            for (int i = 0; i < num_of_students; i++)
            {
                int sum = 0;
                Console.WriteLine($"The grades of student #{i + 1}:");
                for (int j = 0; j < num_of_grades; j++)
                {
                    students[i,j] = rnd.Next(60, 101);
                    Console.Write(students[i, j] + ", ");
                    sum += students[i, j];

                    if (students[i, j] > 90 && counter < 3)
                        counter++;
                    else if (counter == 3 && j == num_of_grades - 1)
                        Console.WriteLine($"\nStudent {i + 1} got above 90 at least 3 times!");
                }
                Console.WriteLine($"\nThe avarage of student #{i + 1} is:  {sum / num_of_grades}\n");
            }
        }
    }
}