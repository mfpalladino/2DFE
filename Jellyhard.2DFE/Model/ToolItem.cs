using System.Drawing;

namespace TwoDFE
{
    public class ToolItem
    {
        public ToolItem(ToolCategory category, string name, Image image)
        {
            ToolCategory = category;
            Name = name;
            Image = image;
        }

        public ToolCategory ToolCategory { get; private set; }
        public string Name { get; private set; }
        public Image Image { get; private set; }
    }
}