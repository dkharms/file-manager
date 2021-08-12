using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    public class DirectoryChanger
    {
        
        /// <summary>
        /// This method is for changing directory in current path.
        /// </summary>
        /// <param name="parameters"></param>
        public static void ChangeDirectory(List<string> parameters)
        {
            List<dynamic> defaultParameters = new List<dynamic> {Directory.GetCurrentDirectory()};
            int endIndex = Math.Min(defaultParameters.Count, parameters.Count);

            try
            {
                for (int i = 0; i < endIndex; i++) defaultParameters[i] = parameters[i];

                string directoryPath = defaultParameters[0];
                
                Directory.SetCurrentDirectory(Path.GetFullPath(directoryPath));
            }
            catch (Exception e)
            {
                CommandLine.PrintErrorMessage("[!] Wrong path");
            }
        }
    }
}