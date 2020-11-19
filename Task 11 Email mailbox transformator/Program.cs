using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;


namespace Task_11_Email_mailbox_transformator
{
    class Program
    {
        static string ReadString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            } 
            while (result == "");
            return result;
        }
        static void Main()
        {
            string content = File.ReadAllText(@"C:\Temp\Misc\InfoForComms.txt"); //(ReadString("Please provide the path and file name: "));
            List<string> rows = new List<string>(content.Split('\n'));
            var data = new Dictionary<string, string>(); 
            //Console.WriteLine($"Result list: {JsonSerializer.Serialize(rows)}");

            foreach (var row in rows)
            {
                foreach (var col in row.Trim().Split('\t'))
                {
                    Console.WriteLine(col);
                }
            }
        }
    }
}