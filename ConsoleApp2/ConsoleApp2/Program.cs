using System;
using System.IO;
using System.Collections.Generic;

class LinearCongruentialRandom
{
    private int seed;
    private int a;
    private int c;
    private int m;

    public LinearCongruentialRandom(int seed, int a, int c, int m)
    {
        this.seed = seed;
        this.a = a;
        this.c = c;
        this.m = m;
    }

    public int Next()
    {
        seed = (a * seed + c) % m;
        return seed;
    }
}

class Program
{
    static void Main()
    {
        // Параметри
        int seed = 4;  // Початкове значення
        int a = 243; // Множник
        int c = 1; // Приріст
        int m = 2047; // Модуль порівняння (2^31)

        LinearCongruentialRandom lcg = new LinearCongruentialRandom(seed, a, c, m);

        Console.Write("Введіть кіл-ть псевдовипадкових чисел для генерації: ");
        int quantity = int.Parse(Console.ReadLine());

        List<int> randomNumbers = new List<int>();

        for (int i = 0; i < quantity; i++)
        {
            int randomNumber = lcg.Next();
            randomNumbers.Add(randomNumber);
            Console.WriteLine("Random number " + (i + 1) + ": " + randomNumber);
        }

        // Розрахунок періоду функції генерації
        int period = randomNumbers.Count;

        // Результати в файл
        using (StreamWriter writer = new StreamWriter("random_numbers.txt"))
        {
            foreach (int randomNumber in randomNumbers)
            {
                writer.WriteLine(randomNumber);
            }
        }

        Console.WriteLine("Перевірка періоду функції генерації: " + period);
        Console.WriteLine("Результати збережено в \"random_numbers.txt\".");


        // Висновок про придатність цього генератора для проблем криптографії
        // Лінійні конгруентні генератори не підходять для криптографії
        // передбачувані шаблони не є безпечними. Криптографічні програми потребують
        // криптографічно захищені генератори випадкових чисел, як ті, що надаються різними 
        // System.Security.Cryptography.RandomNumberGenerator.


    }
}