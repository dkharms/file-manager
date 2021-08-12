using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileManager
{
    public class FileProcessor
    {
        /// <summary>
        /// This method read file's content and print it.
        /// I receive <strong> parameters </strong>, which contains all optional parameters.
        /// I'm processing all of them and passing into <strong> filePath, encoding </strong>.
        /// </summary>
        /// <param name="parameters"></param>
        public static void ReadFile(List<string> parameters)
        {
            // Here I want to understand how many optional arguments user gave.
            List<dynamic> defaultParameters = new List<dynamic> {"path", Encoding.UTF8};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);

            try
            {
                // Checking user's optional arguments.
                for (int i = 0; i < endIndex; i++)
                {
                    if (i != defaultParameters.Count - 1) defaultParameters[i] = parameters[i];
                    else defaultParameters[i] = Encoding.GetEncoding(parameters[i]);
                }

                string filePath = defaultParameters[0];
                Encoding encoding = defaultParameters[1];

                Console.OutputEncoding = encoding;
                string[] lines = File.ReadAllLines(Path.GetFullPath(filePath), encoding);
                foreach (string line in lines)
                    Console.WriteLine(line);
                Console.OutputEncoding = Encoding.UTF8;
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }

        /// <summary>
        /// This method copies file into another file.
        /// Same algorithm like in ReadFile(), I'm checking how many optional parameters
        /// user gave and then apply them.
        /// </summary>
        /// <param name="parameters"></param>
        public static void CopyFile(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic> {"path", "copyPath"};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);

            try
            {
                for (int i = 0; i < endIndex; i++) defaultParameters[i] = parameters[i];

                string filePath = defaultParameters[0];
                string copyFilePath = defaultParameters[1];

                File.Copy(Path.GetFullPath(filePath), Path.GetFullPath(copyFilePath), true);
                CommandLine.PrintDoneMessage("[+] File copied");
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }

        /// <summary>
        /// This method moves file from one directory to another.
        /// Same algorithm like in ReadFile().
        /// </summary>
        /// <param name="parameters"></param>
        public static void MoveFile(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic> {"path", "destPath"};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);

            try
            {
                for (int i = 0; i < endIndex; i++) defaultParameters[i] = parameters[i];

                string filePath = defaultParameters[0];
                string destPath = defaultParameters[1];
                
                File.Move(Path.GetFullPath(filePath), Path.GetFullPath(destPath), true);
                CommandLine.PrintDoneMessage("[+] File moved");
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }

        /// <summary>
        /// This method creates file with specified text [by default it's empty],
        /// with specified encoding [by default it's UTF-8].
        /// Same algorithm like in ReadFile()
        /// </summary>
        /// <param name="parameters"></param>
        public static void CreateFile(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic> {"path", "", Encoding.UTF8};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);

            try
            {
                for (int i = 0; i < endIndex; i++)
                {
                    if (i != defaultParameters.Count - 1) defaultParameters[i] = parameters[i];
                    else defaultParameters[i] = Encoding.GetEncoding(parameters[i]);
                }

                string filePath = defaultParameters[0];
                string text = defaultParameters[1];
                Encoding encoding = defaultParameters[2];

                File.WriteAllText(Path.GetFullPath(filePath), text, encoding);
                CommandLine.PrintDoneMessage("[+] File created");
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }

        /// <summary>
        /// This method removes file in specified path.
        /// Same algorithm like in ReadFile().
        /// </summary>
        /// <param name="parameters"></param>
        public static void RemoveFile(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic> {"path"};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);

            try
            {
                for (int i = 0; i < endIndex; i++) defaultParameters[i] = parameters[i];

                string filePath = defaultParameters[0];

                File.Delete(Path.GetFullPath(filePath));
                CommandLine.PrintDoneMessage("[+] File deleted");
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }

        /// <summary>
        /// This method concatenates two files into one file in specified encoding [by default it's UTF-8]
        /// and prints it to console in specified encoding [by default it's UTF-8].
        /// </summary>
        /// <param name="parameters"></param>
        public static void JoinFiles(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic>
                {"filePathOne", "filePathTwo", "outFilePath", Encoding.UTF8};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);

            try
            {
                for (int i = 0; i < endIndex; i++)
                {
                    if (i != defaultParameters.Count - 1) defaultParameters[i] = parameters[i];
                    else defaultParameters[i] = Encoding.GetEncoding(parameters[i]);
                }

                string filePathOne = defaultParameters[0];
                string filePathTwo = defaultParameters[1];
                string outFilePath = defaultParameters[2];
                Encoding encoding = defaultParameters[3];

                string[] linesOne = File.ReadAllLines(Path.GetFullPath(filePathOne), encoding);
                string[] linesTwo = File.ReadAllLines(Path.GetFullPath(filePathTwo), encoding);

                Console.OutputEncoding = encoding;
                File.WriteAllLines(Path.GetFullPath(outFilePath), linesOne.ToList().Concat(linesTwo).ToArray(),
                    encoding);
                ReadFile(new List<string> {outFilePath});
                Console.OutputEncoding = Encoding.UTF8;
                CommandLine.PrintDoneMessage("[+] Files concatenated");
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong query");
            }
        }
    }
}