using System;
using System.Drawing;
using System.Windows.Forms;

namespace TwoDFE
{
    public class UnselectableButton : Button
    {
        public UnselectableButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
