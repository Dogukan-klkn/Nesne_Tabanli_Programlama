using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Örnek sayı dizisi
        List<int> numbers = new List<int> { 5, 3, 2 };
        List<char> operators = new List<char> { '+', '-', '*', '/' };

        List<string> solutions = new List<string>();
        FindCombinations(numbers, operators, "", solutions);

        // Uygun çözümleri yazdırma
        Console.WriteLine("Geçerli çözümler:");
        foreach (var solution in solutions)
        {
            Console.WriteLine(solution);
        }
    }

    static void FindCombinations(List<int> numbers, List<char> operators, string currentExpression, List<string> solutions)
    {
        // Eğer sayı dizisi boşsa, çözümü kontrol et
        if (numbers.Count == 0)
        {
            // Sonucu hesapla ve kontrol et
            if (EvaluateExpression(currentExpression) > 0)
            {
                solutions.Add(currentExpression);
            }
            return;
        }

        // Tüm sayı kombinasyonlarını ve operatörleri deneyin
        for (int i = 0; i < numbers.Count; i++)
        {
            int number = numbers[i];
            List<int> remainingNumbers = new List<int>(numbers);
            remainingNumbers.RemoveAt(i);

            // Operatörleri ekle
            foreach (var op in operators)
            {
                // Geçerli bir ifadeye operatör ekle
                string newExpression = currentExpression.Length == 0 ? number.ToString() : $"{currentExpression}{op}{number}";

                // Recursive olarak yeni kombinasyonları bul
                FindCombinations(remainingNumbers, operators, newExpression, solutions);
            }
        }
    }

    static double EvaluateExpression(string expression)
    {
        // Basit bir ifade değerlendirme metodu
        try
        {
            var dataTable = new System.Data.DataTable();
            return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
        }
        catch
        {
            return double.NegativeInfinity; // Hatalı bir ifade için -∞ döndür
        }
    }
}
