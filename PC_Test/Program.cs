using System.Diagnostics;

Stopwatch sw = new();
Stopwatch testsw = new();
if (args != null && args.Length > 0) Console.WriteLine("test started: " + args.ToString());
else Console.WriteLine("test started...");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine();
sw.Start();
testsw.Start();
//..

Console.WriteLine("Rastgele sayı üretme ve dosyaya yazma testi başladı.");
List<string> filesName = new List<string>();
string test = "";
int count = 0;
for (int i = 0; i < 25000; i++)
{
    // Uzun süren bir işlem simülasyonu
    for (int a = 0; a < 50; a++)
    {
        double result = Math.Sqrt(i * a);
        test += (result * 4).ToString();
    }
    count++;
    if (count == 1000)
    {
        test += test + test + test + test;
        filesName.Add($"testfile{i / 1000}.txt");
        File.WriteAllText(filesName.Last(), test);
        for (int d = 0; d < 5; d++)
            File.AppendAllText(filesName.Last(), File.ReadAllText(filesName.Last()));
        count = 0;
        test = "";
    }
}

foreach (var fileName in filesName)
{
    File.Delete(fileName); // Dosyayı silme
}
testsw.Stop();
Console.WriteLine($"Dosya yazma Testi bitti Süre: {testsw.Elapsed}");

testsw.Start();
Console.WriteLine("Pi Sayısı Hesaplama Başladı.");

double pi = 0.0;
for (int i = 0; i < 200000; i++)
{
    pi += 4.0 * (1 - (i % 2) * 2) / (2 * i + 1);
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.WriteLine("pi sayısı :" + pi);
}

testsw.Stop();
Console.WriteLine($"Pi Sayısı Hesaplama Bitti Geçen Süre:{testsw.Elapsed}");

//..
sw.Stop();
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("test complated: " + sw.Elapsed);
Console.WriteLine("pres any key for exit!");
Console.ReadKey();