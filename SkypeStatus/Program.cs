using SKYPE4COMLib;
using System;
using System.IO;
using System.Threading;

namespace SkypeStatus
{
    class Program
    {
        static void Main()
        {
            Console.Title = "SkypeStatus";
            Skype skype = new Skype();
            string type = String.Empty;
            skype.Attach(7, true);
            skype.CurrentUserStatus = TUserStatus.cusOnline;
            string text = "2";
            try { text = File.ReadAllText("morze.txt"); }
            catch {}
            
            while (true)
            {
                int length = text.Length;
                for (int num = 0; num != length; num++) 
                {
                    switch (text[num])
                    {
                        case '0':
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            skype.CurrentUserStatus = 
                                TUserStatus.cusInvisible;
                            type = "0 - Невидимка";
                            break;
                        case '1':
                            Console.ForegroundColor = ConsoleColor.Green;
                            skype.CurrentUserStatus = 
                                TUserStatus.cusOnline;
                            type = "1 - В сети";
                            break;
                        case '2':
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            skype.CurrentUserStatus = 
                                TUserStatus.cusSkypeMe;
                            type = "2 - SkypeMe";
                            break;
                        case '3': 
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            skype.CurrentUserStatus = 
                                TUserStatus.cusAway;
                            type = "3 - Нет на месте";
                            break;
                        case '4':
                            Console.ForegroundColor = ConsoleColor.Red;
                            skype.CurrentUserStatus = 
                                TUserStatus.cusDoNotDisturb;
                            type = "4 - Не беспокоить";
                            break;
                    }
                    Console.Title = "SkypeStatus " + type;
                    Console.WriteLine("[{0}] {1}", 
                        DateTime.Now.ToString("HH:mm:ss"), type);
                    Console.ResetColor();
                    Thread.Sleep(500);
                }
            }
        }
    }
}
