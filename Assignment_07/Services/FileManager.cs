using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07.Services
{
    public class FileManager
    {
        //Spara innehållet 
        public static void SaveToFile(string filePath, string content)
        {
            try
            {
                using var sw=new StreamWriter(filePath);
                sw.WriteLine(content);

            }catch (Exception ex) { Debug.WriteLine(ex.Message); }

        }

        // läser in innehållet 
        public static string ReadFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath);
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

    }
}
