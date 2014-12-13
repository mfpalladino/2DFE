using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TwoDFE
{
    public sealed class SectorArea : Panel
    {
        public event EventHandler<SectorAreaCreateElementRequestedEventArgs> CreateElementRequested;
        public event EventHandler SelectElementsChanged;

        private readonly IList<SectorElement> _selectedElements = new List<SectorElement>();
        private readonly IList<SectorElementToCopy> _selectedElementsToCopy = new List<SectorElementToCopy>();
        
        public SectorArea()
        {
            AllowDrop = true;
            _zIndexDefaults = ZIndexDefaultsReader.Read();
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);

            var pb = drgevent.Data.GetData(typeof(List<SectorElement>)) as List<SectorElement>;

            drgevent.Effect = pb != null ? DragDropEffects.Move : DragDropEffects.None;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);

            var pb = (List<SectorElement>)drgevent.Data.GetData(typeof(List<SectorElement>));

            var point = PointToClient(new Point(drgevent.X, drgevent.Y));

            foreach (SectorElement se in pb)
            {
                if (!ModifierKeys.HasFlag(Keys.Shift))
                    se.Left = point.X >= 0 ? point.X : 0;

                if (!ModifierKeys.HasFlag(Keys.Control))
                    se.Top = point.Y <= ClientRectangle.Height ? point.Y : ClientRectangle.Height;
            }

            OnSelectElementsChanged();
            
            if (pb.Count > 0)
                ScrollControlIntoView(pb[0]);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            var element = e.Control as SectorElement;
            if (element != null)
                element.ElementSelected += ElementSectorSelected;
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            var element = e.Control as SectorElement;
            if (element != null)
                element.ElementSelected -= ElementSectorSelected;

        }

        private bool _mouseDownToSelectRectangle;
        private Point _startOfSelectRectanglePoint;
        private Rectangle _selectRectangle;
        private readonly Dictionary<string, int> _zIndexDefaults;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != MouseButtons.Left)
                return;

            if (_selectedElements.Count > 0)
            {
                foreach (var element in _selectedElements)
                    element.Selected = false;

                _selectedElements.Clear();

                OnSelectElementsChanged();
            }
            else
            {
                if (!OnCreateElementRequested())
                {
                    _mouseDownToSelectRectangle = true;
                    _startOfSelectRectanglePoint = new Point(e.X, e.Y);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_mouseDownToSelectRectangle)
            {
                _selectRectangle = new Rectangle(_startOfSelectRectanglePoint.X, _startOfSelectRectanglePoint.Y,
                        Math.Abs(_startOfSelectRectanglePoint.X - e.X),
                        Math.Abs(_startOfSelectRectanglePoint.Y - e.Y));

                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button != MouseButtons.Left)
                return;

            if (_mouseDownToSelectRectangle)
            {
                foreach (Control element in Controls)
                {
                    if (_selectRectangle.IntersectsWith(element.Bounds))
                    {
                        var sectorElement = ((SectorElement)element);

                        if (ModifierKeys == Keys.Shift)
                        {
                            if (!sectorElement.Selected)
                            {

                                if (!_selectedElements.Contains(sectorElement))
                                    _selectedElements.Add(sectorElement);

                                sectorElement.Selected = true;
                            }
                            else
                            {
                                if (_selectedElements.Contains(sectorElement))
                                    _selectedElements.Remove(sectorElement);

                                sectorElement.Selected = false;
                            }
                        }
                        else
                        {
                            if (!_selectedElements.Contains(sectorElement))
                                _selectedElements.Add(sectorElement);

                            sectorElement.Selected = true;
                        }
                    }
                }

                OnSelectElementsChanged();
            }

            _mouseDownToSelectRectangle = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (_mouseDownToSelectRectangle)
            {
                using (var p = new Pen(Color.Gray, 0.1f))
                    pe.Graphics.DrawRectangle(p, _selectRectangle);
            }
        }

        public void DoKeyDown(KeyEventArgs e, int gridX, int gridY)
        {
            if (_selectedElements.Count > 0)
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    if (ModifierKeys.HasFlag(Keys.Shift))
                    {
                        gridX = 1;
                        gridY = 1;
                    }

                    foreach (var element in _selectedElements)
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Left:
                                if ((HorizontalScroll.Value + element.Left) - 1 >= 0)
                                    element.Left -= gridX;
                                else
                                    element.Left = 0;
                                break;
                            case Keys.Right:
                                element.Left += gridX;
                                break;
                            case Keys.Up:
                                element.Top -= gridY;
                                break;
                            case Keys.Down:

                                if (!e.Control)
                                {
                                    if (element.Top + element.Height + gridY <= ClientRectangle.Height)
                                        element.Top += gridY;
                                    else
                                        element.Top = ClientRectangle.Height - element.Height;
                                }
                                else
                                {
                                    element.Top += gridY;
                                }

                                break;
                        }
                    }

                    ScrollControlIntoView(_selectedElements[0]);
                    OnSelectElementsChanged();
                }
                else if (e.Control && e.KeyCode == Keys.C)
                    CopySelectedElements();
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    PastSelectedElements(gridY);
                    OnSelectElementsChanged();
                }
                else if (e.Control && e.KeyCode == Keys.A)
                {
                    foreach (var element in _selectedElements)
                        element.BringToFront();
                }
                else if (e.Control && e.KeyCode == Keys.Z)
                {
                    foreach (var element in _selectedElements)
                        element.SendToBack();
                }

                else if (e.KeyCode == Keys.Delete)
                    DeleteSelectedElements();
            }
            else
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (HorizontalScroll.Value - 32 > HorizontalScroll.Minimum)
                        HorizontalScroll.Value = HorizontalScroll.Value - 32;
                    else
                        HorizontalScroll.Value = HorizontalScroll.Minimum;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (HorizontalScroll.Value + 32 < HorizontalScroll.Maximum)
                        HorizontalScroll.Value = HorizontalScroll.Value + 32;
                    else
                        HorizontalScroll.Value = HorizontalScroll.Maximum;
                }
                else if (e.KeyCode == Keys.A)
                {
                    if (e.Control && e.Shift)
                    {
                        foreach (Control element in Controls)
                        {
                            var sectorElement = ((SectorElement)element);

                            if (!_selectedElements.Contains(sectorElement))
                                _selectedElements.Add(sectorElement);

                            sectorElement.Selected = true;
                        }
                    }
                }
            }
        }

        private void ElementSectorSelected(object sender, EventArgs e)
        {
            var selectedElement = sender as SectorElement;

            if (selectedElement != null && 
                !selectedElement.Selected &&
                ModifierKeys != Keys.Control && ModifierKeys != Keys.Shift)
            {
                foreach (var element in _selectedElements)
                    element.Selected = false;

                _selectedElements.Clear();
            }

            if (!_selectedElements.Contains(selectedElement))
                _selectedElements.Add(selectedElement);

            if (selectedElement != null)
            {
                selectedElement.Selected = true;
                OnSelectElementsChanged();
            }
        }

        private bool OnCreateElementRequested()
        {
            var args = new SectorAreaCreateElementRequestedEventArgs();

            if (CreateElementRequested != null)
                CreateElementRequested(this, args);

            if (args.IsValid())
            {
                var point = PointToClient(new Point(MousePosition.X, MousePosition.Y));

                var zIndex = 0;

                if (_zIndexDefaults.ContainsKey(args.Name))
                    zIndex = _zIndexDefaults[args.Name];

                CreateElement(Guid.NewGuid().ToString(), point.X, point.Y, args.Name, args.Image, null, zIndex);
                return true;
            }

            return false;
        }

        private void OnSelectElementsChanged()
        {
            if (SelectElementsChanged != null)
                SelectElementsChanged(this, EventArgs.Empty);
        }

        private SectorElement CreateElement(string name, int left, int top, string elementIdentifier, Image image, List<KeyValuePair<string, string>> parameters, int zindex)
        {
            var element = new SectorElement(this)
            {
                Name = name,
                Image = image,
                AutoSize = true,
                Tag = elementIdentifier,
                Left = left,
                Top = top,
                Parameters = parameters,
                ZIndex = zindex,
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom,
                ContextMenuStrip = ContextMenuStrip
            };

            element.BringToFront();
            Controls.Add(element);
            return element;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Focus();
        }

        public void AlignSelectedElementsToLeft()
        {
            if (_selectedElements.Count <= 1)
                return;

            var refValue = _selectedElements.First().Left;

            foreach (var element in _selectedElements)
                element.Left = refValue;
        }

        public void AlignSelectedElementsToTop()
        {
            if (_selectedElements.Count <= 1)
                return;

            var refValue = _selectedElements.First().Top;

            foreach (var element in _selectedElements)
                element.Top = refValue;
        }

        public void AlignSelectedElementsToBottom()
        {
            if (_selectedElements.Count <= 1)
                return;

            var topRefValue = _selectedElements.First().Top;
            var heightRefValue = _selectedElements.First().Height;

            foreach (var element in _selectedElements)
                element.Top = topRefValue + (heightRefValue - element.Height);
        }

        public void AlignSelectedElementsToRight()
        {
            if (_selectedElements.Count <= 1)
                return;

            var leftRefValue = _selectedElements.First().Left;
            var widthRefValue = _selectedElements.First().Width;

            foreach (var element in _selectedElements)
                element.Left = leftRefValue + (widthRefValue - element.Width);
        }

        public void MakeSelectedElementsHorizontalSpacingEqual()
        {
            if (_selectedElements.Count <= 2)
                return;
            
            var list = _selectedElements.OrderBy(x => x.Left).ToList();

            var delta = list[1].Left - list[0].Right;

            for (var i = 2; i < list.Count; i++)
                list[i].Left = list[i - 1].Right + delta;
        }

        public void MakeSelectedElementsVerticalSpacingEqual()
        {
            if (_selectedElements.Count <= 2)
                return;

            var list = _selectedElements.OrderBy(x => x.Top).ToList();

            var delta = list[1].Top - list[0].Bottom;

            for (var i = 2; i < list.Count; i++)
                list[i].Top = list[i - 1].Bottom + delta;
        }

        public void SendSelectedElementsToBack()
        {
            if (_selectedElements.Count <= 0)
                return;

            foreach (var t in _selectedElements)
                t.SendToBack();
        }

        public void BringSelectedElementsToFront()
        {
            if (_selectedElements.Count <= 0)
                return;

            foreach (var t in _selectedElements)
                t.BringToFront();
        }

        public void CopySelectedElements()
        {
            if (_selectedElements.Count == 0)
                return;

            _selectedElementsToCopy.Clear();

            foreach (var element in _selectedElements)
                _selectedElementsToCopy.Add(new SectorElementToCopy(element.Left, element.Top, element.Tag.ToString(), element.Image, element.Parameters, element.ZIndex));
        }

        public void PastSelectedElements(int gridY)
        {
            if (_selectedElementsToCopy.Count == 0)
                return;

            foreach (var element in _selectedElements)
                element.Selected = false;

            _selectedElements.Clear();

            foreach (var element in _selectedElementsToCopy)
            {
                var createdElement = CreateElement(Guid.NewGuid().ToString(), element.Left, element.Top - gridY*2, element.ElementIdentifier, element.Image, element.Parameters, element.ZIndex);
                createdElement.Selected = true;
                _selectedElements.Add(createdElement);
            }

            ScrollControlIntoView(_selectedElements[0]);
        }

        private int GetMinHeightOnSelectedElements()
        {
            return _selectedElements.Select(e => e.Image.Height).Concat(new[] {0}).Max();
        }

        public void DeleteSelectedElements()
        {
            if (_selectedElements.Count == 0)
                return;

            foreach (var element in _selectedElements)
                Controls.Remove(element);
        }

        public IEnumerable<SectorElement> SelectedElements
        {
            get
            {
                return _selectedElements;
            }
        }

        public void WriteSector(out IEnumerable<string> editor, out IEnumerable<string> libgdx)
        {
            var elementList = Controls.OfType<SectorElement>().Select(control => control).ToList();

            editor = new List<string>();
            libgdx = new List<string>();
            foreach (var element in elementList)
                ((IList) editor).Add(element.ToString(ClientRectangle.Height));

            foreach (var element in elementList.OrderBy(x => x.ZIndex))
                ((IList)libgdx).Add(element.ToString(ClientRectangle.Height));
        }

        public void ReadSector(IEnumerable<string> sectorLines, IEnumerable<ToolCategory> toolCategories)
        {
            _selectedElements.Clear();
            _selectedElementsToCopy.Clear();
            Controls.Clear();

            foreach(var line in sectorLines){
                var lineParts = line.Split(' ');

                var type = lineParts[0];
                var name = lineParts[1];
                var left = Convert.ToInt32(lineParts[2]);
                var fileTop = Convert.ToInt32(lineParts[3]);
                var zindex = Convert.ToInt32(lineParts[6]);
                var parameters = lineParts.Length >= 8 ? lineParts[7] : string.Empty;

                var listParameters = new List<KeyValuePair<string, string>>();
                foreach(var lineParameter in parameters.Split('|')){
                    if (string.IsNullOrWhiteSpace(lineParameter))
                        continue;

                    var columnParameter = lineParameter.Split('=');
                    listParameters.Add(new KeyValuePair<string, string>(columnParameter[0], columnParameter[1]));
                }

                var item = GetToolItemFromTypeName(type, toolCategories.ToList());
                var top = ClientRectangle.Height - fileTop - item.Image.Height;

                CreateElement(name, left, top, item.Name, item.Image, listParameters, zindex);
            }
        }

        private ToolItem GetToolItemFromTypeName(string elementTypeName, IEnumerable<ToolCategory> toolCategories)
        {
            foreach (var category in toolCategories)
            {
                foreach (var item in category.Items)
                {
                    if (item.Name.Equals(elementTypeName, StringComparison.InvariantCultureIgnoreCase))
                        return item;
                }
            }

            return null;
        }
    }
}
