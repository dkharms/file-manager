using System;
using System.IO;

namespace FileManager
{
    public class DriveProcessor
    {
        
        /// <summary>
        /// This method print all computers's drives and their free space.
        /// </summary>
        public static void GetAllDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                Console.WriteLine($"Drive Name | {drive.Name,-20}");
                Console.WriteLine($"Drive Free Space | {drive.TotalFreeSpace,-20}");
                Console.WriteLine();
            }
        }
    }
}