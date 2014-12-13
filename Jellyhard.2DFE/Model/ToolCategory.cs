using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TwoDFE
{
    public class ToolCategory
    {
        public ToolCategory(string name, IEnumerable<ToolItem> items)
        {
            Name = name;
            Items = items;
        }

        public string Name { get; private set; }
        public IEnumerable<ToolItem> Items { get; private set; }

        public static IEnumerable<ToolCategory> ReadFromAppDirectory()
        {
            try
            {
                var inputDirectory = Application.StartupPath + "\\Elements";

                var categories = new List<ToolCategory>();

                var subDirectories = Directory.GetDirectories(inputDirectory);

                foreach (var directory in subDirectories)
                {
                    var items = new List<ToolItem>();

                    var directoryName = new DirectoryInfo(directory).Name;

                    if (!directoryName.Equals("Images", System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        var category = new ToolCategory(directoryName, items);

                        var files = Directory.GetFiles(directory, "*.png");

                        items.AddRange(files.Select(file => new ToolItem(category, Path.GetFileNameWithoutExtension(file), Image.FromFile(file))));

                        categories.Add(category);
                    }
                    else
                    {
                        var imagesSubDirectories = Directory.GetDirectories(directory);

                        foreach (var imageDirectory in imagesSubDirectories)
                        {
                            var imageItems = new List<ToolItem>();

                            var imageDirectoryName = new DirectoryInfo(imageDirectory).Name;

                            var category = new ToolCategory("images\\" + imageDirectoryName, imageItems);

                            var files = Directory.GetFiles(imageDirectory, "*.png");

                            imageItems.AddRange(files.Select(file => new ToolItem(category, "images\\" + imageDirectoryName + "\\" + Path.GetFileNameWithoutExtension(file), Image.FromFile(file))));

                            categories.Add(category);
                        }
                    }
                }

                return categories;
            }
            catch
            {
                MessageBox.Show("Elements directory not found.");
            }

            return new List<ToolCategory>();
        }
    }
}