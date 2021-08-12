using System;
using System.Collections.Generic;

namespace FileManager
{
    public class CommandProcessor
    {
        /// <summary>
        /// This method calls need method, which is asked by user.
        /// And here I call method, which process arguments passed by user.
        /// </summary>
        /// <param name="query"></param>
        public static void RunCommand(List<string> query)
        {
            string command = query[0];
            List<string> parameters = new List<string> {};
            if (query.Count >= 2) parameters = GetParametersFromQuery(query); 
            
            if (command == "read") FileProcessor.ReadFile(parameters);
            else if (command == "copy") FileProcessor.CopyFile(parameters);
            else if (command == "move") FileProcessor.MoveFile(parameters);
            else if (command == "create_f") FileProcessor.CreateFile(parameters);
            else if (command == "rf") FileProcessor.RemoveFile(parameters);
            else if (command == "join") FileProcessor.JoinFiles(parameters);
            
            else if (command == "get_all") DirectoryProcessor.GetContentInDirectory(parameters);
            else if (command == "get_dirs") DirectoryProcessor.GetDirectoriesInDirectory(parameters);
            else if (command == "get_files") DirectoryProcessor.GetFilesInDirectory(parameters);
            else if (command == "create_d") DirectoryProcessor.CreateDirectory(parameters);
            else if (command == "rd") DirectoryProcessor.DeleteDirectory(parameters);

            else if (command == "drives") DriveProcessor.GetAllDrives();
            else if (command == "cd") DirectoryChanger.ChangeDirectory(parameters);
            else if (command == "help") CommandHelper.GetHelp();
            else if (command == "clear") CommandLine.ClearCommandLine();
            else if (command == "exit") CommandLine.ExitCommandLine();
            else CommandLine.PrintErrorMessage("[!] Wrong query");
            
            
        }

        /// <summary>
        /// Here I process arguments, optional arguments.
        /// Example result of this argument:
        ///     user query: create_f 1.txt [example text] [ascii]
        ///     result: ["1.txt", "example text", "ascii"]
        /// So as you can see, I just separate all the arguments, that's why I can handle
        /// file\directory's names with spaces.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<string> GetParametersFromQuery(List<string> query)
        {
            List<string> parameters = new List<string>();
            string additionalParameters = query[1];

            bool startedOptional = false;
            string currentParameter = "";
            for (int i = 0; i < additionalParameters.Length; i++)
            {
                if (additionalParameters[i] == '[') startedOptional = true;
                else if (additionalParameters[i] == ']') startedOptional = false;
                else if (additionalParameters[i] != ' ' || startedOptional) currentParameter += additionalParameters[i];
                else if (additionalParameters[i] == ' ' && !startedOptional)
                {
                    parameters.Add(currentParameter);
                    currentParameter = "";
                }
            }
            parameters.Add(currentParameter);

            return parameters;
        }
    }
}