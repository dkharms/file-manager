using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    public class DirectoryProcessor
    {
        
        /// <summary>
        /// This method gets all content in specified directory, like files and other directories.
        /// [by default it's current directory].
        /// </summary>
        /// <param name="parameters"></param>
        public static void GetContentInDirectory(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic> {Directory.GetCurrentDirectory()};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);
            
            try
            {
                for (int i = 0; i < endIndex; i++) defaultParameters[i] = parameters[i];

                string directoryPath = defaultParameters[0];
                string[] directories = Directory.GetDirectories(Path.GetFullPath(directoryPath));
                string[] files = Directory.GetFiles(Path.GetFullPath(directoryPath));

                for (int i = 0; i < directories.Length; i++)
                {
                    if (i % 3 == 0 && i != 0) Console.WriteLine();
                    DirectoryInfo directoryInfo = new DirectoryInfo(directories[i]);
                    Console.Write($"Directory | {directoryInfo.Name,-40}");
                }

                Console.WriteLine();
                for (int i = 0; i < files.Length; i++)
                {
                    if (i % 3 == 0 && i != 0) Console.WriteLine();
                    DirectoryInfo fileInfo = new DirectoryInfo(files[i]);
                    Console.Write($"File | {fileInfo.Name,-40}");
                }

                Console.WriteLine();
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }
        
        /// <summary>
        /// This method gets only files in specified path.
        /// [by default it's current directory]
        /// </summary>
        /// <param name="parameters"></param>
        public static void GetFilesInDirectory(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic> {Directory.GetCurrentDirectory()};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);
            
            try
            {
                for (int i = 0; i < endIndex; i++) defaultParameters[i] = parameters[i];

                string directoryPath = defaultParameters[0];
                string[] files = Directory.GetFiles(Path.GetFullPath(directoryPath));
                
                for (int i = 0; i < files.Length; i++)
                {
                    if (i % 3 == 0 && i != 0) Console.WriteLine();
                    DirectoryInfo fileInfo = new DirectoryInfo(files[i]);
                    Console.Write($"File | {fileInfo.Name,-40}");
                }

                Console.WriteLine();
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }
        
        /// <summary>
        /// This method prints all directories in specified path.
        /// [by default it's current directory]
        /// </summary>
        /// <param name="parameters"></param>
        public static void GetDirectoriesInDirectory(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic> {Directory.GetCurrentDirectory()};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);
            
            try
            {
                for (int i = 0; i < endIndex; i++) defaultParameters[i] = parameters[i];

                string directoryPath = defaultParameters[0];
                string[] directories = Directory.GetDirectories(Path.GetFullPath(directoryPath));
                
                for (int i = 0; i < directories.Length; i++)
                {
                    if (i % 3 == 0 && i != 0) Console.WriteLine();
                    DirectoryInfo directoryInfo = new DirectoryInfo(directories[i]);
                    Console.Write($"Directory | {directoryInfo.Name,-40}");
                }

                Console.WriteLine();
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }
        
        /// <summary>
        /// This method creates directory in specified path.
        /// {by default it's current directory]
        /// </summary>
        /// <param name="parameters"></param>
        public static void CreateDirectory(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic> {Directory.GetCurrentDirectory()};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);
            
            try
            {
                for (int i = 0; i < endIndex; i++) defaultParameters[i] = parameters[i];

                string directoryPath = defaultParameters[0];
                Directory.CreateDirectory(Path.GetFullPath(directoryPath));
                CommandLine.PrintDoneMessage("[+] Directory created");
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }

        /// <summary>
        /// This method deletes directory in specified path.
        /// </summary>
        /// <param name="parameters"></param>
        public static void DeleteDirectory(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic> {Directory.GetCurrentDirectory()};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);
            
            try
            {
                for (int i = 0; i < endIndex; i++) defaultParameters[i] = parameters[i];

                string directoryPath = defaultParameters[0];
                Directory.Delete(Path.GetFullPath(directoryPath));
                CommandLine.PrintDoneMessage("[+] Directory deleted");
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }
        
    }
}