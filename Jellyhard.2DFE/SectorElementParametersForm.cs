using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoDFE
{
    public partial class SectorElementParametersForm : Form
    {
        public SectorElementParametersForm(List<KeyValuePair<string, string>> parameters)
        {
            InitializeComponent();
            this.dgvParameters.SetParameters(parameters);
        }

        public List<KeyValuePair<string, string>> GetParameters()
        {
            return this.dgvParameters.GetParameters();
        }
    }
}
