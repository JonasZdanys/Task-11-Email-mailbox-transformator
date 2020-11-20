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
            for (int i = 0; i < rows.Capacity; i++)
            {
                var col = rows[i].Trim().Split('\t');
                if (col[1] != null)
                {
                    if (col[1].Contains(","))
                    {
                        foreach (var email in col[1].Split(','))
                        {
                            //Console.WriteLine(email);
                            try
                            {
                                data.Add(email, col[0]);
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("An element with Key = \"email\" already exists.");
                            }
                        }
                    }
                }
                else
                {
                    col[1] = "Mailbox col[0] does not have an owner";
                    data.Add(col[1], col[0]);
                }
            }
            Console.WriteLine($"Result list: {JsonSerializer.Serialize(data)}");
            /*{
                foreach (var col in row.Trim().Split('\t'))
                {
                    //Console.WriteLine(col);
                    if (col.Contains ("SEC-DL-"))
                    {
                        test.Add(x, col);
                        x++;
                    }
                }
            }*/
        }
    }
}