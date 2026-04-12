using POEPractice.Models;
using POEPractice.Services;
using POEPractice.UI;
using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBot.Services
{
    public class ChatbotService
    {
        private readonly ResponseService _responseService;
        private readonly List<string> _chatHistory;
        private int _messageCount;

        public ChatbotService()
        {
            _responseService = new ResponseService();
            _chatHistory = new List<string>();
            _messageCount = 0;
        }

        public void StartChat(UserProfile user)
        {
            ShowWelcomeBanner(user);
            ShowHelpMenu();

            while (true)
            {
                Console.WriteLine();
                ConsoleUI.WriteUserPrompt($"{user.Name}: ");
                string? userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ConsoleUI.WriteError("Please type something — I'm here to help!");
                    continue;
                }

                string trimmed = userInput.Trim();

                // --- Special commands ---
                if (trimmed.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    ShowGoodbye(user);
                    break;
                }

                if (trimmed.Equals("help", StringComparison.OrdinalIgnoreCase))
                {
                    ShowHelpMenu();
                    continue;
                }

                if (trimmed.Equals("history", StringComparison.OrdinalIgnoreCase))
                {
                    ShowHistory();
                    continue;
                }

                if (trimmed.Equals("clear", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    ConsoleUI.DisplayHeader();
                    ShowWelcomeBanner(user);
                    continue;
                }

                if (trimmed.Equals("quiz", StringComparison.OrdinalIgnoreCase))
                {
                    RunQuickQuiz();
                    continue;
                }

                // --- Normal chat ---
                _messageCount++;
                ConsoleUI.ShowLoading(" Guardian is thinking", 800);

                string response = _responseService.GetResponse(trimmed, user.Name);
                ConsoleUI.WriteBotMessage(response);

                // Save to history
                _chatHistory.Add($"[{_messageCount}] You: {trimmed}");
                _chatHistory.Add($"[{_messageCount}] Guardian: {response}");

                // Milestone messages
                if (_messageCount == 5)
                    ConsoleUI.WriteInfo("You're asking great questions! Keep going.", "TIP");

                if (_messageCount == 10)
                    ConsoleUI.WriteSuccess("10 questions down! You're becoming a cybersecurity pro!");
            }
        }

        // ── Private Helpers ──────────────────────────────────────────

        private void ShowWelcomeBanner(UserProfile user)
        {
            ConsoleUI.WriteSeparator("WELCOME");
            ConsoleUI.WriteBotMessage($"Hello, {user.Name}! I am your Cybersecurity Guardian.");
            ConsoleUI.WriteBotMessage("I can help you stay safe online. Ask me anything about:");
            ConsoleUI.WriteInfo("Phishing  |  Passwords  |  Malware  |  Safe Browsing  |  Privacy", "TOPICS");
            ConsoleUI.WriteSeparator();
        }

        private void ShowHelpMenu()
        {
            string[] options =
            {
                "Ask any cybersecurity question",
                "Type 'quiz'    - Take a quick security quiz",
                "Type 'history' - View your chat history",
                "Type 'clear'   - Clear the screen",
                "Type 'help'    - Show this menu again",
                "Type 'exit'    - Exit the chatbot"
            };
            ConsoleUI.DisplayMenu(options, "COMMANDS");
        }

        private void ShowHistory()
        {
            ConsoleUI.WriteSeparator("CHAT HISTORY");
            if (_chatHistory.Count == 0)
            {
                ConsoleUI.WriteWarning("No chat history yet. Start asking questions!");
                return;
            }
            foreach (string entry in _chatHistory)
            {
                Console.ForegroundColor = entry.Contains("You:")
                    ? ConsoleColor.Yellow
                    : ConsoleColor.Cyan;
                Console.WriteLine("  " + entry);
                Console.ResetColor();
            }
            ConsoleUI.WriteSeparator();
        }

        private void ShowGoodbye(UserProfile user)
        {
            ConsoleUI.WriteSeparator("GOODBYE");
            ConsoleUI.WriteBotMessage($"Stay safe out there, {user.Name}!");
            ConsoleUI.WriteBotMessage($"You asked {_messageCount} question(s) today. Keep learning!");
            ConsoleUI.WriteSuccess("Session ended. Remember: Think before you click!");
            ConsoleUI.WriteSeparator();
        }

        private void RunQuickQuiz()
        {
            ConsoleUI.WriteSeparator("QUICK SECURITY QUIZ");

            var questions = new List<(string question, string[] options, int answer, string explanation)>
            {
                (
                    "What should you do if you receive a suspicious email?",
                    new[] { "1. Click all links to check them", "2. Delete it and report it as phishing", "3. Forward it to friends" },
                    2,
                    "Never click links in suspicious emails. Report and delete them."
                ),
                (
                    "Which is the strongest password?",
                    new[] { "1. password123", "2. MyDog2020", "3. #Kx9!mP2@wL" },
                    3,
                    "Strong passwords use a mix of uppercase, lowercase, numbers and symbols."
                ),
                (
                    "What does HTTPS mean in a website URL?",
                    new[] { "1. The site is fast", "2. The connection is encrypted and secure", "3. The site is government-owned" },
                    2,
                    "HTTPS means the data between you and the website is encrypted."
                )
            };

            int score = 0;

            foreach (var (question, options, answer, explanation) in questions)
            {
                Console.WriteLine();
                ConsoleUI.WriteBotMessage(question);
                foreach (string option in options)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("   " + option);
                    Console.ResetColor();
                }

                ConsoleUI.WriteUserPrompt("Your answer (enter number): ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice == answer)
                {
                    ConsoleUI.WriteSuccess("Correct!");
                    score++;
                }
                else
                {
                    ConsoleUI.WriteError($"Not quite. Correct answer was option {answer}.");
                }
                ConsoleUI.WriteInfo(explanation, "EXPLANATION");
            }

            Console.WriteLine();
            ConsoleUI.WriteSeparator("QUIZ RESULTS");
            ConsoleUI.WriteBotMessage($"You scored {score} out of {questions.Count}!");

            if (score == questions.Count)
                ConsoleUI.WriteSuccess("Perfect score! You're a cybersecurity champion!");
            else if (score >= 2)
                ConsoleUI.WriteInfo("Good effort! Keep learning to stay safe online.", "RESULT");
            else
                ConsoleUI.WriteWarning("Keep practising — cybersecurity knowledge saves you online!");

            ConsoleUI.WriteSeparator();
        }
    }
}