class DayOneTrebuchet
{
    static void Main()
    {
        Console.WriteLine("Provide your calibration document (press Enter twice to finish):");

        var inputLines = new List<string>();
        string inputLine;

        while (true)
        {
            inputLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                break;
            }

            inputLines.Add(inputLine);
        }

        int sum = inputLines.AsParallel().Sum(line => ExtractAndSumDigits(line));

        Console.WriteLine($"The sum of all calibration values is: {sum}");
    }

    static int ExtractAndSumDigits(string line)
    {
        int? firstDigit = null;
        int lastDigit = 0;
        bool isFirstDigitFound = false;

        foreach (var ch in line)
        {
            if (char.IsDigit(ch))
            {
                if (!isFirstDigitFound)
                {
                    firstDigit = ch - '0';
                    isFirstDigitFound = true;
                }
                lastDigit = ch - '0';
            }
        }

        return firstDigit.HasValue ? firstDigit.Value * 10 + lastDigit : 0;
    }
}