using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TwoDFE
{
    public static class ZIndexDefaultsReader
    {
        public static Dictionary<string, int> Read()
        {
            try
            {
                const string fileName = "Config\\ZIndexDefaults.txt";

                if (File.Exists(fileName))
                {
                    var rows = File.ReadAllLines(fileName);
                    return rows.Select(row => row.Split('='))
                        .Where(x=>x.Length == 2)
                        .ToDictionary(rowParts => rowParts[0], rowParts => Convert.ToInt32(rowParts[1]));
                }
            }
            catch
            {
                //Silenciado propositalmente
            }

            return new Dictionary<string, int>();
        }
    }
}