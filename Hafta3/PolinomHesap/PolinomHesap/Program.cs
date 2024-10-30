using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Polinom Hesaplayıcı - Çıkmak için 'exit' yazın.\n");

        while (true)
        {
            // Kullanıcıdan polinomları al
            Console.Write("Birinci polinomu girin: ");
            string polinom1 = Console.ReadLine();
            if (polinom1.ToLower() == "exit") break;

            Console.Write("İkinci polinomu girin: ");
            string polinom2 = Console.ReadLine();
            if (polinom2.ToLower() == "exit") break;

            // Polinomları ayrıştır
            Dictionary<int, int> terimler1 = PolinomuAyrıştır(polinom1);
            Dictionary<int, int> terimler2 = PolinomuAyrıştır(polinom2);

            // Toplama ve çıkarma işlemleri
            var toplam = PolinomTopla(terimler1, terimler2);
            var fark = PolinomCikar(terimler1, terimler2);

            // Sonuçları göster
            Console.WriteLine($"\nToplam: {PolinomToString(toplam)}");
            Console.WriteLine($"Fark: {PolinomToString(fark)}\n");
        }
    }

    // Polinomu terimlere ayırma
    static Dictionary<int, int> PolinomuAyrıştır(string polinom)
    {
        Dictionary<int, int> terimler = new Dictionary<int, int>();
        string pattern = @"([+-]?\s*\d*)x\^(\d+)|([+-]?\s*\d*)x|([+-]?\s*\d+)";
        var matches = Regex.Matches(polinom.Replace(" ", ""), pattern);

        foreach (Match match in matches)
        {
            int katsayi = 0;
            int derece = 0;

            if (match.Groups[1].Success) // x^n terimleri
            {
                katsayi = int.Parse(match.Groups[1].Value.Replace("x", "").Replace("^", ""));
                derece = int.Parse(match.Groups[2].Value);
            }
            else if (match.Groups[3].Success) // x terimi
            {
                katsayi = int.Parse(match.Groups[3].Value.Replace("x", ""));
                derece = 1;
            }
            else if (match.Groups[4].Success) // Sabit terim
            {
                katsayi = int.Parse(match.Groups[4].Value);
                derece = 0;
            }

            if (terimler.ContainsKey(derece))
                terimler[derece] += katsayi;
            else
                terimler[derece] = katsayi;
        }

        return terimler;
    }

    // Polinom toplama
    static Dictionary<int, int> PolinomTopla(Dictionary<int, int> p1, Dictionary<int, int> p2)
    {
        Dictionary<int, int> sonuc = new Dictionary<int, int>(p1);

        foreach (var kvp in p2)
        {
            if (sonuc.ContainsKey(kvp.Key))
                sonuc[kvp.Key] += kvp.Value;
            else
                sonuc[kvp.Key] = kvp.Value;
        }

        return sonuc;
    }

    // Polinom çıkarma
    static Dictionary<int, int> PolinomCikar(Dictionary<int, int> p1, Dictionary<int, int> p2)
    {
        Dictionary<int, int> sonuc = new Dictionary<int, int>(p1);

        foreach (var kvp in p2)
        {
            if (sonuc.ContainsKey(kvp.Key))
                sonuc[kvp.Key] -= kvp.Value;
            else
                sonuc[kvp.Key] = -kvp.Value;
        }

        return sonuc;
    }

    // Polinomu string formatında yazdırma
    static string PolinomToString(Dictionary<int, int> polinom)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var kvp in polinom)
        {
            if (kvp.Value == 0) continue;

            string terim = kvp.Value > 0 && sb.Length > 0 ? "+" : "";
            terim += kvp.Value != 1 || kvp.Key == 0 ? $"{kvp.Value}" : "";
            terim += kvp.Key > 0 ? "x" : "";
            terim += kvp.Key > 1 ? $"^{kvp.Key}" : "";

            sb.Append(terim);
        }

        return sb.Length > 0 ? sb.ToString() : "0";
    }
}
