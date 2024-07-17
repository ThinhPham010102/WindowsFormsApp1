using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int randomNumber = random.Next(100, 1000);
        int guess;
        int[] randomDigits = GetDigits(randomNumber);

        Console.WriteLine("Chào mừng bạn đến với trò chơi đoán số!");
        Console.WriteLine("Máy đã chọn một số có 3 chữ số. Hãy bắt đầu đoán!");

        for (int attempts = 1; attempts <= 7; attempts++)
        {
            Console.Write($"\nLần đoán thứ {attempts}: ");
            while (!int.TryParse(Console.ReadLine(), out guess) || guess < 100 || guess > 999)
            {
                Console.Write("Đầu vào không hợp lệ. Hãy nhập lại số có 3 chữ số: ");
            }

            int[] guessDigits = GetDigits(guess);
            bool[] matched = new bool[3];
            int plusCount = 0;
            int questionCount = 0;

            for (int i = 0; i < 3; i++)
            {
                if (guessDigits[i] == randomDigits[i])
                {
                    Console.Write("+");
                    plusCount++;
                    matched[i] = true;
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!matched[j] && guessDigits[i] == randomDigits[j])
                        {
                            Console.Write("?");
                            questionCount++;
                            break;
                        }
                    }
                }
            }

            if (plusCount == 3)
            {
                Console.WriteLine("\nChúc mừng! Bạn đã đoán đúng số!");
                break;
            }
            else
            {
                Console.WriteLine();
                if (attempts == 7)
                {
                    Console.WriteLine($"\nBạn đã hết số lần đoán. Số đúng là: {randomNumber}");
                }
                else
                {
                    Console.WriteLine($"Bạn đã đoán sai. Còn lại {7 - attempts} lần đoán.");
                }
            }
        }
    }

    static int[] GetDigits(int number)
    {
        int[] digits = new int[3];
        digits[0] = number / 100;
        digits[1] = (number / 10) % 10;
        digits[2] = number % 10;
        return digits;
    }
}
