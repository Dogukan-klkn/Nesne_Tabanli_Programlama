using System;
using System.Collections.Generic;
using System.Data;

class Program
{
    static void Main()
    {
        Console.Write("Matematiksel ifadeyi girin: ");
        string ifade = Console.ReadLine();

        try
        {
            string cozum = AdimAdimCozumle(ifade);
            Console.WriteLine("Çözüm Süreci:");
            Console.WriteLine(cozum);

            double sonuc = Değerlendir(ifade);
            Console.WriteLine($"\nSonuç: {sonuc}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Hata: " + e.Message);
        }
    }

    // İşlem sırasını adım adım gösteren çözüm fonksiyonu
    static string AdimAdimCozumle(string ifade)
    {
        // İşlem önceliklerine göre çözüm sürecini tutar
        List<string> adimlar = new List<string>();

        while (ifade.Contains("(") || ifade.Contains("^") || ifade.Contains("*") || ifade.Contains("/") || ifade.Contains("+") || ifade.Contains("-"))
        {
            if (ifade.Contains("("))
            {
                int ilkParantez = ifade.LastIndexOf("(");
                int sonParantez = ifade.IndexOf(")", ilkParantez);
                string parantezIci = ifade.Substring(ilkParantez + 1, sonParantez - ilkParantez - 1);
                double sonuc = Değerlendir(parantezIci);
                ifade = ifade.Substring(0, ilkParantez) + sonuc.ToString() + ifade.Substring(sonParantez + 1);
                adimlar.Add($"Parantez içi çözüm: {parantezIci} = {sonuc}");
            }
            else if (ifade.Contains("^"))
            {
                ifade = IslemiUygula(ifade, "^", adimlar);
            }
            else if (ifade.Contains("*") || ifade.Contains("/"))
            {
                ifade = IslemiUygula(ifade, "*", adimlar);
                ifade = IslemiUygula(ifade, "/", adimlar);
            }
            else if (ifade.Contains("+") || ifade.Contains("-"))
            {
                ifade = IslemiUygula(ifade, "+", adimlar);
                ifade = IslemiUygula(ifade, "-", adimlar);
            }
        }

        return string.Join("\n", adimlar);
    }

    // Belirli bir işlemi ifadeye uygular ve adımları günceller
    static string IslemiUygula(string ifade, string islem, List<string> adimlar)
    {
        int index = ifade.IndexOf(islem);
        int basla = index - 1;
        int bitir = index + 1;

        while (basla >= 0 && (char.IsDigit(ifade[basla]) || ifade[basla] == '.'))
            basla--;

        while (bitir < ifade.Length && (char.IsDigit(ifade[bitir]) || ifade[bitir] == '.'))
            bitir++;

        double sol = double.Parse(ifade.Substring(basla + 1, index - basla - 1));
        double sag = double.Parse(ifade.Substring(index + 1, bitir - index - 1));

        double sonuc = islem == "^" ? Math.Pow(sol, sag)
                     : islem == "*" ? sol * sag
                     : islem == "/" ? sol / sag
                     : islem == "+" ? sol + sag
                     : sol - sag;

        string islemAciklama = $"{sol} {islem} {sag} = {sonuc}";
        adimlar.Add(islemAciklama);

        ifade = ifade.Substring(0, basla + 1) + sonuc.ToString() + ifade.Substring(bitir);

        return ifade;
    }

    // İfade değerlendirme fonksiyonu
    static double Değerlendir(string ifade)
    {
        DataTable dt = new DataTable();
        return Convert.ToDouble(dt.Compute(ifade.Replace("^", "Math.Pow"), ""));
    }
}
