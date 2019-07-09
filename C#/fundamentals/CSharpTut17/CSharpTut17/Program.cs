using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

// Used for file and directory manipulation
using System.IO;
using System.Text;

namespace CSharpTut17
{
    class Program
    {
        static void Main(string[] args)
        {
            // ----- MESSING WITH DIRECTORIES -----

            // Get access to the current directory
            DirectoryInfo currentDir = new DirectoryInfo(".");

            // Get access to a directory with a path
            DirectoryInfo myDir = new DirectoryInfo(@"C:\Users\Kenny");

            // Get the directory path
            Console.WriteLine(myDir.FullName);

            // Get the directory name
            Console.WriteLine(myDir.Name);

            // Get the parent directory
            Console.WriteLine(myDir.Parent);

            // What type is it
            Console.WriteLine(myDir.Attributes);

            // When was it created
            Console.WriteLine(myDir.CreationTime);

            // Create a directory
            DirectoryInfo dataDir = new DirectoryInfo(@"C:\Users\Kenny\C#Data");
            dataDir.Create();

            // Delete a directory
            //Directory.Delete(@"C:\Users\Kenny\C#Data");

            // ----- SIMPLE FILE READING & WRITING -----

            // Write a string array to a text file
            string[] customers =
            {
                "Bob Smith",
                "Sally Smith",
                "Robert Smith"
            };

            string textFilePath = @"C:\Users\Kenny\C#Data\testfile1.txt";

            // Write the array
            File.WriteAllLines(textFilePath, customers);

            // Read strings from array
            foreach (string cust in File.ReadAllLines(textFilePath))
            {
                Console.WriteLine($"Customer : {cust}");
            }

            // ----- GETTING FILE DATA -----

            DirectoryInfo myDataDir = new DirectoryInfo(@"C:\Users\Kenny\C#Data");

            // Get all txt files
            FileInfo[] txtFiles = myDataDir.GetFiles("*.txt", SearchOption.AllDirectories);

            // Number of matches
            Console.WriteLine("Matches : {0}", txtFiles.Length);

            foreach (FileInfo file in txtFiles)
            {
                // Get the file name
                Console.WriteLine(file.Name);

                // Get bytes in file
                Console.WriteLine(file.Length);
            }

            // ----- FILESTREAMS -----
            // FileStream is used to read and write a byte or an array of bytes.

            string textFilePath2 = @"C:\Users\Kenny\C#Data\testfile2.txt";

            // Create and open a file
            FileStream fs = File.Open(textFilePath2, FileMode.Create);

            string randString = "This is a random string";

            // Convert to a byte array
            byte[] rsByteArray = Encoding.Default.GetBytes(randString);

            // Write to file by defining the byte array, the index to start writing from
            // and length
            fs.Write(rsByteArray, 0, rsByteArray.Length);

            // Move back to the beginning of the file
            fs.Position = 0;

            // Create byte array to hold file data
            byte[] fileByteArray = new byte[rsByteArray.Length];

            // Put bytes in array
            for (int i = 0; i < rsByteArray.Length; i++)
            {
                fileByteArray[i] = (byte)fs.ReadByte();
            }

            // Convert from bytes to string and output this
            Console.WriteLine(Encoding.Default.GetString(fileByteArray));

            // Close the filestream
            fs.Close();

            // ----- STREAMWRITER / STREAMREADER -----
            // These are best for reading and writing strings

            string textFilePath3 = @"C:\Users\Kenny\C#Data\testfile3.txt";

            // Create a text file
            StreamWriter sw = File.CreateText(textFilePath3);

            // Write to a file without a newline
            sw.Write("This is a random ");

            // Write to a file with a newline
            sw.WriteLine("sentence.");

            // Write another
            sw.WriteLine("This is another sentence.");

            // Close the streamWriter
            sw.Close();

            // Open the file for reading
            StreamReader sr = File.OpenText(textFilePath3);

            // Peek returns the next character as a unicode number.
            // Use convert to change to a character
            Console.WriteLine("Peek : {0}",
                Convert.ToChar(sr.Peek()));

            // Read to a newline
            Console.WriteLine("1st String : {0}",
                sr.ReadLine());

            // Read to the end of a file starting where you left off reading
            Console.WriteLine("Everything : {0}",
                sr.ReadToEnd());

            // Close the streamreader
            sr.Close();

            // ----- BINARYWRITER / BINARYREADER -----
            // Used to read and write data types
            string textFilePath4 = @"C:\Users\Kenny\C#Data\testfile4.dat";

            // Get the file
            FileInfo datFile = new FileInfo(textFilePath4);

            // Open the file
            BinaryWriter bw = new BinaryWriter(datFile.OpenWrite());

            // Data to save to the file
            string randText = "Random Text";
            int myAge = 42;
            double height = 6.25;

            // Write data to a file
            bw.Write(randText);
            bw.Write(myAge);
            bw.Write(height);

            bw.Close();

            // Open file for reading
            BinaryReader br = new BinaryReader(datFile.OpenRead());

            // Output data
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadDouble());

            br.Close();

            Console.ReadLine();
        }
    }
}
