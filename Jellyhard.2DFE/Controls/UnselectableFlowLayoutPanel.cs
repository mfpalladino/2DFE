using System.Windows.Forms;

namespace TwoDFE
{
    public class UnselectableFlowLayoutPanel : FlowLayoutPanel
    {
        public UnselectableFlowLayoutPanel()
        {
            SetStyle(ControlStyles.Selectable, false);
        }

        internal void UnselectCurrentTool()
        {
        }
    }
}
