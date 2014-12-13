
using System;
using System.Collections.Generic;
using System.IO;

namespace TwoDFE
{
    public class Preferences
    {
        private const string FileName = "Config\\Preferences.txt";

        public int GridX { get; set; }
        public int GridY { get; set; }

        public static Preferences Read()
        {
            var result = new Preferences {GridX = 10, GridY = 10};

            try
            {
                if (File.Exists(FileName))
                {
                    var rows = File.ReadAllLines(FileName);

                    foreach (var row in rows)
                    {
                        var property = row.Split('=');

                        if (property[0].Equals("GridX", StringComparison.CurrentCultureIgnoreCase))
                            result.GridX = Convert.ToInt32(property[1]);
                        
                        if (property[0].Equals("GridY", StringComparison.CurrentCultureIgnoreCase))
                            result.GridY = Convert.ToInt32(property[1]);
                    }
                }
            }
            catch
            {
            }

            return result;
        }

        public void Save()
        {
            try
            {
                File.WriteAllLines(FileName, 
                    new List<string>
                    {
                        "GridX=" + GridX,
                        "GridY=" + GridY,
                    });
            }
            catch
            {
            }
        }
    }
}