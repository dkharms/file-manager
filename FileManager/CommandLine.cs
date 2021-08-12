using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    
    /*
     Here's the main class.
     - CommandLine - class with handling user queries, and some console stuff.
     - CommandHelper - class with suggestions, introductory information, nothing interesting.
     - CommandProcessor - class which class need method with parameters, which user gave.
     - FileProcessor - class with methods, which need for work with files.
     - DirectoryProcessor - class with methods, which need for work with directories and content inside them.
     - DirectoryChanger - class with method, which change directory for specified path.
    */

    public class CommandLine
    {
        /// <summary>
        /// This method prints error message in red color.
        /// </summary>
        /// <param name="errorText"></param>
        public static void PrintErrorMessage(string errorText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorText);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// This method prints done message in green color.
        /// </summary>
        /// <param name="doneText"></param>
        public static void PrintDoneMessage(string doneText)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(doneText);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// This method stops console, is user entered "exit".
        /// </summary>
        public static void ExitCommandLine()
        {
            Environment.Exit(0);
        }
        
        /// <summary>
        /// This method cleans console, if user entered "clear".
        /// </summary>
        public static void ClearCommandLine()
        {
            try
            {
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("[!] Your OS is not compatible");
            }
        }
        
        /// <summary>
        /// This method receive user's query and split it in two parameters.
        /// For example: read 1.txt [ascii] -> [read, 1.txt [ascii]].
        /// I do it, because second parameter needs to be processed,
        /// because there can be important information, like text, encoding etc.
        /// </summary>
        /// <returns>List<string> queryArguments</returns>
        public static List<string> GetQuery()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{Path.GetFullPath(Directory.GetCurrentDirectory())}~$ ");
            Console.ForegroundColor = ConsoleColor.White;
            
            string userQuery = Console.ReadLine().Trim();
            List<string> queryArguments = new List<string> {userQuery};
            if (userQuery.Split(" ").Length >= 2)
            {
                queryArguments = new List<string>
                {
                    userQuery.Substring(0, userQuery.IndexOf(" ")),
                    userQuery.Substring(userQuery.IndexOf(" ") + 1, userQuery.Length - userQuery.IndexOf(" ") - 1)
                };
            }
            
            return queryArguments;
        }
        
        /// <summary>
        /// This method is asking user for command and call command processor.
        /// </summary>
        public static void ProcessQuery()
        {
            List<string> query = GetQuery();
            CommandProcessor.RunCommand(query);
        }
        
        /// <summary>
        /// Here I change console's size and asking user for input.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CommandLine.PrintDoneMessage("[?] To get help type \"help\"");
            Directory.SetCurrentDirectory(DriveInfo.GetDrives()[0].RootDirectory.ToString());
            Console.SetWindowSize((int) (Console.LargestWindowWidth * 0.9), Console.LargestWindowHeight / 2);
            while (true)
            {         
                ProcessQuery();
            }
        }
    }
}