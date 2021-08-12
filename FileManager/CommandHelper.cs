using System;

namespace FileManager
{
    public class CommandHelper
    {
        
        public static string helpText = @"
            <...> - required parameters, [...] - optional parameters.
            Optional parameters need to be covered by [...].

        [!] Attention
            If you want to read\create\move file or folder which contains spaces, 
            like File Name.txt, then you should cover your query in [].
            Example:
                cd [Folder Name With Spaces]
                create_f [File Name With Spaces.txt]
                
        [>] read <file_name> [encoding]
            Read and print file's content in specified encoding. By default encoding = UTF-8.
            Example: 
                read example.txt
                read ../example.txt [UTF-8]

        [>] copy <file_name> <to_file_name> [encoding]
            Copy chosen file to another file in specified encoding. By default encoding = UTF-8.
            Example:
                copy example.txt copied.txt [UTF-8]
                copy ../example.txt copied.txt

        [>] move <file_name> <path/file_name>
        [!] You have to specify file's name.
            Move chosen file to another place. 
            Example:
                move example.txt ../example.txt

        [>] create_f <file_name> [text] [encoding]
            Create new empty file or with specified text and encoding. By default encoding = UTF-8.
            Example:
                create_f example.txt [Here's the example text] [UTF-8]
                create_f example.txt [Here's the example text]
                 
        [>] rf <file_name>
            Remove chosen file.
            Example:
                rf example.txt

        [>] join <file_name> <file_name> <output_file_name> [encoding]
            Join two files and create new file with their content. By default encoding = UTF-8.
            Example:
                join example.txt another_example.txt output.txt
                join example.txt another_example.txt output.txt [UTF-8]

            ----------------------------------

        [>] get_all [path]
            Get all content in specified path.
            Example:
                get_all C:/Users
                get_all

        [>] get_files [path]
            Get all files in specified path.
            Example:
                get_files C:/Users
                get_files

        [>] get_dirs [path]
            Get all directories in specified path.
            Example:
                get_dirs C:/Users
                get_dirs

        [>] create_d <directory_name>
            Create new directory in specified path.
            Example:
                create_d C:/new_directory
                create_d new_directory

        [>] rd <directory_name>
            Remove chosen directory.
            Example: 
                rd C:/new_directory
                rd new_directory
            
            ----------------------------------

        [>] cd <path>
            Get in specified directory.
            Example: 
                cd C:/Users
                cd ../

            ----------------------------------

        [>] clear 
            Clear the console.

        [>] exit
            Exit from console.

        [>] drives
            Print all drives in current system.
";
        public static void GetHelp()
        {

            Console.WriteLine(helpText);
        }
    }
}