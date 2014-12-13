using System;
using System.Drawing;

namespace TwoDFE
{
    public class SectorAreaCreateElementRequestedEventArgs : EventArgs
    {
        public Image Image { get; set; }
        public string Name { get; set; }

        public bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(Name) && Image != null;
        }
    }
}