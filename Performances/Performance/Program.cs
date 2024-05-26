// See https://aka.ms/new-console-template for more information


var sw = new System.Diagnostics.Stopwatch();
while (true)
{
    sw.Restart();
    for (int trial = 0; trial < 10_000; trial++)
    {
        int count = 0;
        for (int i = 0; i < char.MaxValue; i++)
            if (IsAsciiDigit((char)i))
                count++;
    }
    sw.Stop();
    Console.WriteLine(sw.Elapsed);
}

static bool IsAsciiDigit(char c) => (uint)(c - '0') <= 9;



/*
00:00:02.5276476
00:00:02.2514229
00:00:02.2787182
00:00:02.2380407
00:00:02.2049953
00:00:02.1950801
00:00:02.2057371
00:00:02.2037792
00:00:02.2274304
00:00:02.2269368
00:00:02.2180498
00:00:02.2171777
00:00:02.2042055
00:00:02.2233806
 */

/*
00:00:02.3905582
00:00:02.2234117
00:00:02.2073591
00:00:02.1966155
00:00:02.1890389
00:00:02.1965154
00:00:02.1908495
00:00:02.1938569
00:00:02.2049788
00:00:02.1995402
00:00:02.1971699
00:00:02.1915086
 */