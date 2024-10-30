using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Labirentin boyutları (M x N)
        int M = 5;
        int N = 5;

        // Labirentte yol bulma
        List<string> path = new List<string>();
        if (FindPath(0, 0, M, N, path))
        {
            Console.WriteLine("Şehre ulaşma yolu:");
            foreach (var step in path)
            {
                Console.WriteLine(step);
            }
        }
        else
        {
            Console.WriteLine("Şehir kayboldu!");
        }
    }

    static bool FindPath(int x, int y, int M, int N, List<string> path)
    {
        // Hedef koordinatı kontrol et
        if (x == M - 1 && y == N - 1)
        {
            path.Add($"({x}, {y})");
            return true;
        }

        // Geçerli bir hücre olup olmadığını kontrol et
        if (!IsValidCell(x, y, M, N))
            return false;

        // Ziyaret edilen hücreleri takip et
        path.Add($"({x}, {y})");

        // Aşağıya git
        if (FindPath(x + 1, y, M, N, path))
            return true;

        // Sağa git
        if (FindPath(x, y + 1, M, N, path))
            return true;

        // Çapraz aşağı sağa git
        if (FindPath(x + 1, y + 1, M, N, path))
            return true;

        // Hiçbir yönle ulaşamıyorsak geri dön
        path.RemoveAt(path.Count - 1);
        return false;
    }

    static bool IsValidCell(int x, int y, int M, int N)
    {
        // Koordinatların sınırlar içinde olup olmadığını kontrol et
        if (x < 0 || y < 0 || x >= M || y >= N)
            return false;

        // Koordinatların asal sayı olup olmadığını kontrol et
        if (!IsPrime(x) || !IsPrime(y))
            return false;

        // x ve y toplamının, x ve y çarpımına bölünüp bölünemediğini kontrol et
        return (x + y) % (x * y) == 0;
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
