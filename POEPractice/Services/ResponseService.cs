using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEPractice.Services
{
    public class ResponseService
    {
        private readonly Dictionary<string, string[]> _responsePatterns;

        public ResponseService()
        {
            // Initialize response patterns for more dynamic matching
            _responsePatterns = new Dictionary<string, string[]>
            {
                { "greeting", new[] { "hello", "hi", "hey", "good morning", "good afternoon", "good evening", "greetings" } },
                { "how_are_you", new[] { "how are you", "how do you do", "how's it going", "how are things" } },
                { "purpose", new[] { "what's your purpose", "what is your purpose", "what do you do", "why do you exist" } },
                { "help", new[] { "help", "what can i ask", "what questions", "what can you do" } },
                { "password", new[] { "password", "passphrase", "strong password", "create password", "password security" } },
                { "phishing", new[] { "phishing", "phish", "fake email", "fraudulent email" } },
                { "safe_browsing", new[] { "safe browsing", "browse safely", "browsing", "safe website", "secure website" } },
                { "suspicious_link", new[] { "suspicious link", "link", "url", "click link", "malicious link" } },
                { "scam", new[] { "scam", "fraud", "con artist", "deception", "trick" } },
                { "2fa", new[] { "2fa", "two factor", "multi factor", "mfa", "authentication" } },
                { "vpn", new[] { "vpn", "virtual private network", "encrypt connection" } },
                { "ransomware", new[] { "ransomware", "ransom", "malware", "virus", "trojan" } },
                { "social_media", new[] { "social media", "facebook", "instagram", "twitter", "privacy settings" } },
                { "public_wifi", new[] { "public wifi", "free wifi", "hotspot", "public network" } },
                { "backup", new[] { "backup", "data backup", "back up files" } },
                { "software_update", new[] { "update", "software update", "patch", "system update" } },
                { "identity_theft", new[] { "identity theft", "identity fraud", "stolen identity" } },
                { "email_security", new[] { "email security", "secure email", "email safety" } },
                { "banking", new[] { "banking", "online banking", "internet banking", "financial security" } },
                { "child_safety", new[] { "child safety", "kids online", "children internet", "parental control" } },
                { "data_privacy", new[] { "privacy", "data privacy", "personal data", "gdpr" } },
                { "iot", new[] { "iot", "smart home", "smart device", "internet of things" } }
            };
        }

        public string GetResponse(string userInput, string userName)
        {
            string input = userInput.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                return $"🔐 Hey {userName}, you didn't type anything! Ask me about cybersecurity, online safety, or digital protection. I'm here to help!";
            }

            // Greeting responses
            if (MatchesAnyPattern(input, "greeting"))
            {
                string[] greetings = {
                    $"👋 Hello {userName}! Ready to boost your cybersecurity knowledge?",
                    $"✨ Hi there {userName}! Let's make your digital life more secure today!",
                    $"🛡️ Greetings {userName}! How can I help you stay safe online?",
                    $"🌟 Hey {userName}! I'm your digital guardian. What would you like to learn about?"
                };
                return greetings[new Random().Next(greetings.Length)];
            }

            // How are you responses
            if (MatchesAnyPattern(input, "how_are_you"))
            {
                string[] responses = {
                    $"🤖 I'm functioning optimally, {userName}! Ready to protect and educate. How can I assist you?",
                    $"⚡ Fully charged and secure, {userName}! Thanks for asking. What cybersecurity topic interests you?",
                    $"🛡️ I'm in top digital form, {userName}! Always ready to help you stay safe online."
                };
                return responses[new Random().Next(responses.Length)];
            }

            // Purpose
            if (MatchesAnyPattern(input, "purpose"))
            {
                return $"🎯 My mission, {userName}, is to be your cybersecurity mentor! I'm here to educate, protect, and empower you against digital threats. From spotting scams to securing your data, I've got you covered!";
            }

            // Help / What can I ask
            if (MatchesAnyPattern(input, "help"))
            {
                return $"📚 Great question, {userName}! You can ask me about:\n\n" +
                       "• 🔐 **Password Security** - Creating unbreakable passwords\n" +
                       "• 🎣 **Phishing Attacks** - Spotting fake emails and messages\n" +
                       "• 🌐 **Safe Browsing** - Navigating the web securely\n" +
                       "• 🔑 **2FA/MFA** - Two-factor authentication explained\n" +
                       "• 🛡️ **VPN & Privacy** - Protecting your online identity\n" +
                       "• 💻 **Ransomware** - Preventing and responding to attacks\n" +
                       "• 📱 **Social Media Safety** - Privacy settings and sharing wisely\n" +
                       "• 📶 **Public WiFi** - Staying safe on public networks\n" +
                       "• 💾 **Data Backup** - Protecting your important files\n" +
                       "• 🏦 **Online Banking** - Secure financial transactions\n\n" +
                       "What would you like to learn about first?";
            }

            // Password Security
            if (MatchesAnyPattern(input, "password"))
            {
                return $"🔐 **Password Security Tips, {userName}:**\n\n" +
                       "✅ **Create strong passwords:**\n" +
                       "   • Use 12+ characters (longer = stronger)\n" +
                       "   • Mix uppercase, lowercase, numbers, and symbols\n" +
                       "   • Use passphrases like 'BlueSky$Coffee42!'\n\n" +
                       "❌ **Avoid:**\n" +
                       "   • Personal info (birthdays, names)\n" +
                       "   • Common words like 'password123'\n" +
                       "   • Using the same password everywhere\n\n" +
                       "🔑 **Pro tip:** Use a password manager to generate and store unique passwords for each account!";
            }

            // Phishing
            if (MatchesAnyPattern(input, "phishing"))
            {
                return $"🎣 **Phishing Red Flags, {userName}:**\n\n" +
                       "⚠️ **Watch out for:**\n" +
                       "• Urgent or threatening language ('Act now!')\n" +
                       "• Spelling and grammar mistakes\n" +
                       "• Suspicious sender email addresses\n" +
                       "• Requests for personal information\n" +
                       "• Unexpected attachments or links\n\n" +
                       "🛡️ **Always:**\n" +
                       "• Verify by contacting the organization directly\n" +
                       "• Hover over links to see real URL\n" +
                       "• Never share passwords, OTPs, or banking details\n\n" +
                       "Remember: Legitimate companies won't ask for sensitive info via email!";
            }

            // 2FA / MFA
            if (MatchesAnyPattern(input, "2fa"))
            {
                return $"🔑 **Two-Factor Authentication (2FA), {userName}:**\n\n" +
                       "✨ **Why it's essential:**\n" +
                       "• Adds an extra layer of security beyond just password\n" +
                       "• Even if password is stolen, accounts remain protected\n\n" +
                       "📱 **Types of 2FA:**\n" +
                       "• SMS codes (least secure but better than nothing)\n" +
                       "• Authentication apps (Google Authenticator, Authy) - RECOMMENDED\n" +
                       "• Hardware keys (YubiKey) - Most secure\n" +
                       "• Biometrics (fingerprint, face ID)\n\n" +
                       "🚀 **Enable 2FA everywhere possible!** It blocks 99.9% of account hacks.";
            }

            // VPN
            if (MatchesAnyPattern(input, "vpn"))
            {
                return $"🛡️ **VPN (Virtual Private Network), {userName}:**\n\n" +
                       "🌐 **What it does:**\n" +
                       "• Encrypts your internet connection\n" +
                       "• Hides your IP address and location\n" +
                       "• Protects privacy on public WiFi\n\n" +
                       "✅ **When to use VPN:**\n" +
                       "• On public WiFi (cafes, airports, hotels)\n" +
                       "• When accessing sensitive accounts\n" +
                       "• For bypassing geo-restrictions\n\n" +
                       "⚠️ **Remember:** VPNs protect privacy, but they're not a complete security solution!";
            }

            // Ransomware
            if (MatchesAnyPattern(input, "ransomware"))
            {
                return $"💀 **Ransomware Protection, {userName}:**\n\n" +
                       "⚠️ **What is ransomware?**\n" +
                       "Malware that encrypts your files and demands payment for decryption\n\n" +
                       "🛡️ **Prevention:**\n" +
                       "• Regular backups (3-2-1 rule: 3 copies, 2 media types, 1 offsite)\n" +
                       "• Keep software updated\n" +
                       "• Don't click suspicious links or attachments\n" +
                       "• Use reputable antivirus software\n\n" +
                       "🚨 **If attacked:** Don't pay the ransom! Contact cybersecurity professionals immediately.";
            }

            // Social Media Safety
            if (MatchesAnyPattern(input, "social_media"))
            {
                return $"📱 **Social Media Safety Tips, {userName}:**\n\n" +
                       "🔒 **Protect yourself:**\n" +
                       "• Review privacy settings regularly\n" +
                       "• Think before posting - it's permanent!\n" +
                       "• Don't share location in real-time\n" +
                       "• Be selective with friend/follower requests\n" +
                       "• Avoid posting vacation plans publicly\n\n" +
                       "⚠️ **Watch out for:**\n" +
                       "• Fake profiles and catfishing\n" +
                       "• Quizzes asking for personal info\n" +
                       "• Job offers that seem too good to be true\n\n" +
                       "Your digital footprint lasts forever - share wisely!";
            }

            // Public WiFi
            if (MatchesAnyPattern(input, "public_wifi"))
            {
                return $"📶 **Public WiFi Safety, {userName}:**\n\n" +
                       "⚠️ **Risks:**\n" +
                       "• Man-in-the-middle attacks\n" +
                       "• Evil twin hotspots (fake networks)\n" +
                       "• Unencrypted data transmission\n\n" +
                       "✅ **Safety Checklist:**\n" +
                       "• Use a VPN always on public networks\n" +
                       "• Verify network name with staff\n" +
                       "• Avoid accessing sensitive accounts\n" +
                       "• Turn off auto-connect to WiFi\n" +
                       "• Use HTTPS websites\n\n" +
                       "Free WiFi isn't worth compromising your security!";
            }

            // Data Backup
            if (MatchesAnyPattern(input, "backup"))
            {
                return $"💾 **Data Backup Strategy, {userName}:**\n\n" +
                       "📋 **The 3-2-1 Rule:**\n" +
                       "• **3** copies of your data\n" +
                       "• **2** different storage types (external drive + cloud)\n" +
                       "• **1** copy stored offsite\n\n" +
                       "🔄 **Backup Tips:**\n" +
                       "• Automate backups (set and forget)\n" +
                       "• Test restores periodically\n" +
                       "• Encrypt sensitive backups\n" +
                       "• Keep important documents in multiple locations\n\n" +
                       "Remember: It's not 'if' your data will be lost, but 'when'!";
            }

            // Identity Theft
            if (MatchesAnyPattern(input, "identity_theft"))
            {
                return $"🆔 **Identity Theft Protection, {userName}:**\n\n" +
                       "🚨 **Warning Signs:**\n" +
                       "• Unfamiliar accounts or charges\n" +
                       "• Missing mail\n" +
                       "• Denied credit unexpectedly\n\n" +
                       "🛡️ **Prevention:**\n" +
                       "• Freeze credit with major bureaus\n" +
                       "• Monitor accounts regularly\n" +
                       "• Use strong unique passwords\n" +
                       "• Shred sensitive documents\n" +
                       "• Don't overshare personal info online\n\n" +
                       "🔍 **If compromised:** Contact FTC, credit bureaus, and file police report immediately!";
            }

            // Email Security
            if (MatchesAnyPattern(input, "email_security"))
            {
                return $"📧 **Email Security Best Practices, {userName}:**\n\n" +
                       "⚠️ **Stay vigilant:**\n" +
                       "• Check sender address carefully (spoofing is common)\n" +
                       "• Don't click links - hover to preview\n" +
                       "• Verify unexpected attachments\n" +
                       "• Enable 2FA on email accounts\n\n" +
                       "✅ **Secure habits:**\n" +
                       "• Use separate email for important accounts\n" +
                       "• Delete spam without opening\n" +
                       "• Never reply to suspicious emails\n" +
                       "• Report phishing attempts\n\n" +
                       "Your email is the key to your digital identity - protect it!";
            }

            // Online Banking
            if (MatchesAnyPattern(input, "banking"))
            {
                return $"🏦 **Online Banking Security, {userName}:**\n\n" +
                       "🔒 **Safe practices:**\n" +
                       "• Use dedicated device for banking\n" +
                       "• Never use public WiFi for transactions\n" +
                       "• Enable transaction alerts\n" +
                       "• Use bank's official app when possible\n\n" +
                       "⚠️ **Red flags:**\n" +
                       "• Calls claiming 'fraud detected' asking for OTP\n" +
                       "• Emails with links to 'verify account'\n" +
                       "• Unexpected requests for credentials\n\n" +
                       "Banks will NEVER ask for passwords or OTPs via call/text/email!";
            }

            // IoT / Smart Devices
            if (MatchesAnyPattern(input, "iot"))
            {
                return $"🏠 **Smart Home Security, {userName}:**\n\n" +
                       "⚠️ **Risks:**\n" +
                       "• Default passwords are easily hacked\n" +
                       "• Unpatched vulnerabilities\n" +
                       "• Privacy concerns with voice assistants\n\n" +
                       "✅ **Secure your smart home:**\n" +
                       "• Change default passwords immediately\n" +
                       "• Use separate WiFi network for IoT devices\n" +
                       "• Keep firmware updated\n" +
                       "• Disable features you don't use\n" +
                       "• Review privacy settings regularly\n\n" +
                       "Your smart devices need smart security!";
            }

            // Data Privacy
            if (MatchesAnyPattern(input, "data_privacy"))
            {
                return $"🔏 **Data Privacy Essentials, {userName}:**\n\n" +
                       "📊 **Know your rights:**\n" +
                       "• You own your personal data\n" +
                       "• Companies must protect it\n" +
                       "• You can request data deletion\n\n" +
                       "✅ **Protect your privacy:**\n" +
                       "• Limit data shared on apps/websites\n" +
                       "• Read privacy policies (or at least skim!)\n" +
                       "• Use privacy-focused browsers\n" +
                       "• Opt out of data collection when possible\n\n" +
                       "If a service is free, YOU are the product!";
            }

            // Safe Browsing
            if (MatchesAnyPattern(input, "safe_browsing"))
            {
                return $"🌐 **Safe Browsing Guide, {userName}:**\n\n" +
                       "✅ **Do:**\n" +
                       "• Check for HTTPS and padlock icon\n" +
                       "• Use ad-blockers and privacy extensions\n" +
                       "• Clear cookies and cache regularly\n" +
                       "• Keep browser updated\n\n" +
                       "❌ **Don't:**\n" +
                       "• Ignore security warnings\n" +
                       "• Download from untrusted sources\n" +
                       "• Save passwords in browser\n" +
                       "• Click pop-up ads\n\n" +
                       "Think before you click!";
            }

            // Suspicious Links
            if (MatchesAnyPattern(input, "suspicious_link"))
            {
                return $"🔗 **Link Safety 101, {userName}:**\n\n" +
                       "🕵️ **Before clicking:**\n" +
                       "• Hover to reveal real URL\n" +
                       "• Watch for misspellings (faceb00k.com)\n" +
                       "• Be wary of shortened links (bit.ly, tinyurl)\n" +
                       "• Check if URL matches expected domain\n\n" +
                       "🚫 **Red flags:**\n" +
                       "• Urgent action required\n" +
                       "• Too-good-to-be-true offers\n" +
                       "• Unexpected messages from 'friends'\n\n" +
                       "When in doubt, don't click it out!";
            }

            // Scam
            if (MatchesAnyPattern(input, "scam"))
            {
                return $"🎭 **Common Scams to Avoid, {userName}:**\n\n" +
                       "⚠️ **Popular scams:**\n" +
                       "• **Tech support:** 'Your computer is infected'\n" +
                       "• **Romance:** Fake profiles asking for money\n" +
                       "• **Lottery:** 'You've won!' but need to pay fees\n" +
                       "• **CEO fraud:** Fake boss requesting transfers\n" +
                       "• **Job offers:** Pay to apply or receive checks\n\n" +
                       "🛡️ **Protection:**\n" +
                       "• If it sounds too good to be true, it is\n" +
                       "• Never send money to strangers\n" +
                       "• Verify independently before acting\n" +
                       "• Trust your gut instincts!";
            }

            // Exit
            if (input == "exit" || input == "quit" || input == "goodbye" || input == "bye")
            {
                string[] farewells = {
                    $"👋 Stay safe out there, {userName}! Remember - security is a habit, not a one-time thing!",
                    $"🛡️ Goodbye, {userName}! Keep your digital doors locked and your software updated!",
                    $"🔐 Until next time, {userName}! Stay vigilant and protect what matters!"
                };
                return farewells[new Random().Next(farewells.Length)];
            }

            // Default response with helpful suggestions
            return $"🤔 I'm not sure about '{userInput}', {userName}.\n\n" +
                   "Here are some topics I can help with:\n" +
                   "• 🔐 Passwords & Authentication\n" +
                   "• 🎣 Phishing & Scams\n" +
                   "• 🌐 Safe Browsing\n" +
                   "• 🔑 2FA/MFA\n" +
                   "• 🛡️ VPN & Privacy\n" +
                   "• 💻 Ransomware & Malware\n" +
                   "• 📱 Social Media Safety\n" +
                   "• 📶 Public WiFi\n" +
                   "• 💾 Data Backup\n" +
                   "• 🏦 Online Banking\n\n" +
                   "Try asking something like: 'How do I create a strong password?' or 'What is phishing?'";
        }

        private bool MatchesAnyPattern(string input, string patternKey)
        {
            if (_responsePatterns.ContainsKey(patternKey))
            {
                return _responsePatterns[patternKey].Any(pattern => input.Contains(pattern));
            }
            return false;
        }
    }
}