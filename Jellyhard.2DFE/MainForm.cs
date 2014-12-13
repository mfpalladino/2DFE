using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;

namespace TwoDFE
{
    public sealed partial class MainForm : Form
    {
        private readonly Font _regularToolFont;
        private readonly Font _boldToolFont;
        private ToolItem _selectedToolItem;
        private readonly IEnumerable<ToolCategory> _toolCategories;
        private readonly Preferences _preferences;
        private string _currentOpenFileName;
        private UnselectableButton _buttonUnselect;

        public MainForm()
        {
            InitializeComponent();

            saSector.CreateElementRequested += SectorAreaElementCreateRequested;
            saSector.SelectElementsChanged += SectorAreaElementSelectElementsChanged;

            _regularToolFont = new Font(Font, FontStyle.Regular);
            _boldToolFont = new Font(Font, FontStyle.Bold);

            _toolCategories = ToolCategory.ReadFromAppDirectory();
            MakeToolBarFromToolCategories(_toolCategories);

            SetSelectedElementInformations();

            _preferences = Preferences.Read();
            nudGridX.Value = _preferences.GridX;
            nudGridY.Value = _preferences.GridY;

            txtFocus.Focus();
        }

        private void MakeToolBarFromToolCategories(IEnumerable<ToolCategory> toolCategories)
        {
            const int controlWidth = 130;

            var buttonSave = new UnselectableButton { Text = @"Save sector", Width = controlWidth };
            buttonSave.Click += SaveClick;

            flpTools.Controls.Add(buttonSave);

            var buttonLoad = new UnselectableButton { Text = @"Load sector", Width = controlWidth };
            buttonLoad.Click += LoadClick;
            buttonLoad.Margin = new Padding(buttonLoad.Margin.Left, buttonLoad.Margin.Top, buttonLoad.Margin.Right, 20);
            flpTools.Controls.Add(buttonLoad);

            _buttonUnselect = new UnselectableButton { Text = @"Unselect", Width = controlWidth };
            _buttonUnselect.Click += ToolItemClick;
            flpTools.Controls.Add(_buttonUnselect);

            //Categorias
            foreach (var category in toolCategories)
            {
                flpTools.Controls.Add(new Label { Text = category.Name, Margin = new Padding(10), Font = _boldToolFont, Width = controlWidth });

                foreach (var button in category.Items.Select(item => new UnselectableButton { Text = !item.Name.StartsWith("images\\") ? item.Name : item.Name.Split('\\')[2], Tag = item, Width = controlWidth }))
                {
                    button.Click += ToolItemClick;
                    button.MouseMove += ToolItemMouseMove;
                    button.MouseLeave += ToolItemMouseLeave;
                    flpTools.Controls.Add(button);
                }
            }

            if (flpTools.Controls.Count > 0)
                flpTools.Controls[flpTools.Controls.Count-1].Margin = new Padding(3, 3, 3, 100);
        }

        private void ToolItemClick(object sender, EventArgs e)
        {
            var senderControl = ((Control)sender);

            if (senderControl.Tag != null)
            {
                senderControl.Font = _boldToolFont;

                _selectedToolItem = senderControl.Tag as ToolItem;
            }
            else
                _selectedToolItem = null;

            foreach (var control in flpTools.Controls.OfType<Button>().Where(control => control != sender))
                control.Font = _regularToolFont;
        }

        private void ToolItemMouseMove(object sender, MouseEventArgs e)
        {
            var control = (Control)sender;

            pcToolItemPreview.Left = control.Right;
            pcToolItemPreview.Top = control.Top;
            pcToolItemPreview.Image = ((ToolItem)control.Tag).Image;
            pcToolItemPreview.SizeMode = PictureBoxSizeMode.AutoSize;
            pcToolItemPreview.Visible = true;
        }

        private void ToolItemMouseLeave(object sender, EventArgs e)
        {
            pcToolItemPreview.Visible = false;
        }

        private void SectorAreaElementCreateRequested(object sender, SectorAreaCreateElementRequestedEventArgs e)
        {
            if (_selectedToolItem == null)
                return;

            e.Image = _selectedToolItem.Image;
            e.Name = _selectedToolItem.Name;
        }

        private void SectorAreaElementSelectElementsChanged(object sender, EventArgs e)
        {
            SetSelectedElementInformations();
        }

        private void SetSelectedElementInformations()
        {
            if (saSector.SelectedElements != null && saSector.SelectedElements.Count() == 1)
            {
                var selectedElement = saSector.SelectedElements.ElementAt(0);
                gdvParameters.SetParameters(selectedElement.Parameters);
                lblLeft.Text = @"Left: " + selectedElement.Left;
                lblTop.Text = @"Top: " + selectedElement.Top;
                lblName.Text = @"Name: " + selectedElement.Name;
                lblType.Text = @"Type: " + (selectedElement.Tag != null ? selectedElement.Tag.ToString() : String.Empty);
                lblZIndex.Text = @"ZIndex: " + selectedElement.ZIndex;
            }
            else
            {
                gdvParameters.ClearParameters();
                lblLeft.Text = @"Left: -";
                lblTop.Text = @"Top: -";
                lblName.Text = @"Name: -";
                lblType.Text = @"Type: -";
                lblZIndex.Text = @"ZIndex: -";
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            var valueBeforeSave = saSector.HorizontalScroll.Value;

            saSector.HorizontalScroll.Value = 0;
            saSector.HorizontalScroll.Value = 0;

            try
            {
                _currentOpenFileName = ofdOpen.FileName;

                if (String.IsNullOrWhiteSpace(_currentOpenFileName))
                {
                    lblStatus.Text = "Salvando...";
                    lblStatus.Update();

                    if (sfdSave.ShowDialog(this) == DialogResult.OK)
                    {
                        var selectedFileName = sfdSave.FileName.Replace(@"-editor", "").Replace(@"-libgdx", "");
                        var fileNameToEditor = Path.GetDirectoryName(selectedFileName) + "\\" +
                                               Path.GetFileNameWithoutExtension(selectedFileName) + "-editor" + @".txt";
                        var fileNameToLibgdx = Path.GetDirectoryName(selectedFileName) + "\\" +
                                               Path.GetFileNameWithoutExtension(fileNameToEditor.Replace(@"-editor",
                                                   @"-libgdx")) + @".txt";

                        _currentOpenFileName = fileNameToEditor;

                        IEnumerable<string> editor;
                        IEnumerable<string> libgdx;
                        saSector.WriteSector(out editor, out libgdx);
                        File.WriteAllLines(fileNameToEditor, editor);
                        File.WriteAllLines(fileNameToLibgdx, libgdx);

                        lblStatus.Text = "Setor salvo pela última vez em " + DateTime.Now;
                    }
                }
                else
                {
                    lblStatus.Text = "Salvando...";
                    lblStatus.Update();

                    var selectedFileName = _currentOpenFileName.Replace(@"-editor", "").Replace(@"-libgdx", "");
                    var fileNameToEditor = Path.GetDirectoryName(selectedFileName) + "\\" + Path.GetFileNameWithoutExtension(selectedFileName) + "-editor" + @".txt";
                    var fileNameToLibgdx = Path.GetDirectoryName(selectedFileName) + "\\" + Path.GetFileNameWithoutExtension(fileNameToEditor.Replace(@"-editor", @"-libgdx")) + @".txt";

                    IEnumerable<string> editor;
                    IEnumerable<string> libgdx;
                    saSector.WriteSector(out editor, out libgdx);
                    File.WriteAllLines(fileNameToEditor, editor);
                    File.WriteAllLines(fileNameToLibgdx, libgdx);

                    lblStatus.Text = "Setor salvo pela última vez em " + DateTime.Now;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(@"Error on trying to save this sector: " + x.Message);
            }


            saSector.HorizontalScroll.Value = saSector.HorizontalScroll.Maximum;
            saSector.HorizontalScroll.Value = valueBeforeSave;
        }

        private void LoadClick(object sender, EventArgs e)
        {
            try
            {
                if (ofdOpen.ShowDialog(this) == DialogResult.OK)
                {
                    lblStatus.Text = "Carregando...";
                    lblStatus.Update();

                    saSector.ReadSector(File.ReadAllLines(ofdOpen.FileName), _toolCategories);
                    SetSelectedElementInformations();
                    _currentOpenFileName = ofdOpen.FileName;
                    lblStatus.Text = "Setor carregado: " + _currentOpenFileName;
                    MessageBox.Show(@"Sector successfully loaded!");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(@"Error on trying to load sector: " + x.Message);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                ToolItemClick(_buttonUnselect, EventArgs.Empty);
            }

            if (saSector.SelectedElements.Count() == 1 && e.KeyCode == Keys.W && e.Shift && e.Control)
                nudGridX.Value = saSector.SelectedElements.ElementAt(0).Width;

            if (saSector.SelectedElements.Count() == 1 && e.KeyCode == Keys.H && e.Shift && e.Control)
                nudGridY.Value = saSector.SelectedElements.ElementAt(0).Height;

            if (e.KeyCode == Keys.S && e.Control)
                SaveClick(this, EventArgs.Empty);

            saSector.DoKeyDown(e, Convert.ToInt32(nudGridX.Value), Convert.ToInt32(nudGridY.Value));
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            flpTools.Focus();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _regularToolFont.Dispose();
            _boldToolFont.Dispose();
        }

        private void btnAlignToLeft_Click(object sender, EventArgs e)
        {
            saSector.AlignSelectedElementsToLeft();
        }

        private void btnAlignToTop_Click(object sender, EventArgs e)
        {
            saSector.AlignSelectedElementsToTop();
        }

        private void btnAlignToBottom_Click(object sender, EventArgs e)
        {
            saSector.AlignSelectedElementsToBottom();
        }

        private void btnAlignToRight_Click(object sender, EventArgs e)
        {
            saSector.AlignSelectedElementsToRight();
        }

        private void btnHorizontalSpacing_Click(object sender, EventArgs e)
        {
            saSector.MakeSelectedElementsHorizontalSpacingEqual();
        }

        private void btnVerticalSpacing_Click(object sender, EventArgs e)
        {
            saSector.MakeSelectedElementsVerticalSpacingEqual();
        }

        private void btnSendToBack_Click(object sender, EventArgs e)
        {
            saSector.SendSelectedElementsToBack();
        }

        private void btnBringToFront_Click(object sender, EventArgs e)
        {
            saSector.BringSelectedElementsToFront();
        }

        private void miParameters_Click(object sender, EventArgs e)
        {
            var parameters = saSector.SelectedElements.Count() == 1 ? saSector.SelectedElements.ElementAt(0).Parameters : new List<KeyValuePair<string, string>>();

            using (var form = new SectorElementParametersForm(parameters))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach(var selected in saSector.SelectedElements)
                        selected.Parameters = form.GetParameters();
                }
            }
        }

        private void cmsSectorElementOptions_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            miParameters.Enabled = saSector.SelectedElements.Any();
        }

        private void txtFocus_Leave(object sender, EventArgs e)
        {
        }

        private void nudGridX_Leave(object sender, EventArgs e)
        {
            txtFocus.Focus();
        }

        private void nudGridY_Leave(object sender, EventArgs e)
        {
            txtFocus.Focus();
        }

        private void nudGridX_ValueChanged(object sender, EventArgs e)
        {
            _preferences.GridX = Convert.ToInt32(nudGridX.Value);
            _preferences.Save();                
        }

        private void nudGridY_ValueChanged(object sender, EventArgs e)
        {
            _preferences.GridY = Convert.ToInt32(nudGridY.Value);
            _preferences.Save();                
        }
    }
}
