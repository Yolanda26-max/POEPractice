using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POEPractice.UI
{
    public static class ConsoleUI
    {
        // ASCII Art Borders and Decorations
        private const string TOP_LEFT = "╔";
        private const string TOP_RIGHT = "╗";
        private const string BOTTOM_LEFT = "╚";
        private const string BOTTOM_RIGHT = "╝";
        private const string HORIZONTAL = "═";
        private const string VERTICAL = "║";
        private const string CORNER_TL = "┌";
        private const string CORNER_TR = "┐";
        private const string CORNER_BL = "└";
        private const string CORNER_BR = "┘";

        public static void DisplayHeader()
        {
            Console.Clear();

            // Animated gradient header
            ConsoleColor[] gradient = { ConsoleColor.DarkMagenta, ConsoleColor.Magenta, ConsoleColor.Cyan };

            Console.ForegroundColor = gradient[0];
            Console.WriteLine(TOP_LEFT + new string(HORIZONTAL[0], 60) + TOP_RIGHT);

            // Animated title with color cycling
            string title = "   CYBERSECURITY GUARDIAN   ";
            for (int i = 0; i < title.Length; i++)
            {
                Console.ForegroundColor = gradient[i % gradient.Length];
                Console.Write(title[i]);
                Thread.Sleep(5);
            }
            Console.WriteLine();

            Console.ForegroundColor = gradient[0];
            Console.WriteLine(BOTTOM_LEFT + new string(HORIZONTAL[0], 60) + BOTTOM_RIGHT);
            Console.ResetColor();
            // PROTECT ASCII art
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"
    ██████╗ ██████╗  ██████╗ ████████╗███████╗ ██████╗████████╗
    ██╔══██╗██╔══██╗██╔═══██╗╚══██╔══╝██╔════╝██╔════╝╚══██╔══╝
    ██████╔╝██████╔╝██║   ██║   ██║   █████╗  ██║        ██║
    ██╔═══╝ ██╔══██╗██║   ██║   ██║   ██╔══╝  ██║        ██║
    ██║     ██║  ██║╚██████╔╝   ██║   ███████╗╚██████╗   ██║
    ╚═╝     ╚═╝  ╚═╝ ╚═════╝    ╚═╝   ╚══════╝ ╚═════╝   ╚═╝");

            // Shield + tagline
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
         /\     CYBER
        /  \    GUARDIAN
       / /\ \   ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
      / /  \ \  [ ENCRYPT . DEFEND . PROTECT ]
     / /----\ \
    /_/  []  \_\  ""The lock on your digital door.""
    |   [  ]   |
    |___________|
");
            Console.ResetColor();
            Console.ResetColor();

            // Animated warning line
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 3; i++)
            {
                Console.Write("!  ");
                Thread.Sleep(100);
            }
            Console.Write(" SECURITY FIRST ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("  !");
                Thread.Sleep(100);
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        public static void WriteBotMessage(string message, string botName = "GUARDIAN")
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(CORNER_TL + new string('-', 4) + CORNER_TR + " ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[{botName}]");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" " + CORNER_BL + new string('-', 4) + CORNER_BR);
            Console.ResetColor();

            Console.Write(" ");
            TypeTextWithAnimation(message, ConsoleColor.White, 15);
            Console.WriteLine();

            // Decorative line after message
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  " + new string('.', 50));
            Console.ResetColor();
        }

        public static void WriteUserPrompt(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(CORNER_TL + new string('-', 4) + CORNER_TR + " ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[YOU]");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" " + CORNER_BL + new string('-', 4) + CORNER_BR + " ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[X] ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[ERROR] ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();

            // Visual alert effect
            for (int i = 0; i < 2; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("!  ");
                Thread.Sleep(50);
                Console.ResetColor();
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        public static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[OK] ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("[SUCCESS] ");
            Console.ForegroundColor = ConsoleColor.Green;

            // Animated success message
            foreach (char c in message)
            {
                Console.Write(c);
                if (c == '!' || c == '.')
                {
                    Thread.Sleep(100);
                }
                Thread.Sleep(10);
            }
            Console.ResetColor();
            Console.WriteLine("\n");
        }

        public static void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[!] ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[WARNING] ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteInfo(string message, string category = "INFO")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[i] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[{category}] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteSeparator(string title = "")
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("  " + new string('-', 55));
            }
            else
            {
                int padding = (55 - title.Length - 4) / 2;
                Console.WriteLine($"  -{new string('-', padding)}[ {title} ]{new string('-', 55 - padding - title.Length - 4)}-");
            }
            Console.ResetColor();
        }

        public static void DisplayMenu(string[] options, string title = "OPTIONS")
        {
            WriteSeparator(title);
            for (int i = 0; i < options.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  [{i + 1}] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
            WriteSeparator();
        }

        public static int GetMenuChoice(int min, int max)
        {
            int choice = -1;
            while (choice < min || choice > max)
            {
                WriteUserPrompt($"\n  > Enter your choice ({min}-{max}): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    if (choice < min || choice > max)
                    {
                        WriteError($"Please enter a number between {min} and {max}.");
                    }
                }
                else
                {
                    WriteError("Invalid input. Please enter a number.");
                    choice = -1;
                }
            }
            return choice;
        }

        public static void ShowLoading(string message, int duration = 1000)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);

            char[] animation = { '|', '/', '-', '\\' };
            int animationIndex = 0;

            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalMilliseconds < duration)
            {
                Console.Write(animation[animationIndex % animation.Length]);
                Thread.Sleep(100);
                Console.Write("\b");
                animationIndex++;
            }

            Console.Write("*");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ClearAndContinue()
        {
            WriteUserPrompt("\n  Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            DisplayHeader();
        }

        private static void TypeTextWithAnimation(string text, ConsoleColor color, int delay = 20)
        {
            Console.ForegroundColor = color;
            Random rnd = new Random();

            foreach (char c in text)
            {
                Console.Write(c);

                // Random slight delay variation for more natural typing
                int variation = rnd.Next(-5, 5);
                int actualDelay = Math.Max(5, delay + variation);

                // Add extra pause for punctuation
                if (c == '.' || c == '!' || c == '?' || c == ':')
                {
                    Thread.Sleep(actualDelay * 2);
                }
                else
                {
                    Thread.Sleep(actualDelay);
                }
            }
            Console.ResetColor();
        }
    }
}