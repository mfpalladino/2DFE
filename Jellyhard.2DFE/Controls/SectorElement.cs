using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TwoDFE
{

    public class SectorElementToCopy
    {
        public SectorElementToCopy(int left, int top, string elementIdentifier, Image image, List<KeyValuePair<string, string>> parameters, int zindex)
        {
            Left = left;
            Top = top;
            ElementIdentifier = elementIdentifier;
            Image = image;
            Parameters = parameters;
            ZIndex = zindex;
        }

        public int Left { get; private set; }
        public int Top { get; private set; }
        public Image Image { get; private set; }
        public string ElementIdentifier { get; private set; }
        public List<KeyValuePair<string, string>> Parameters { get; private set; }

        public int ZIndex { get; set; }
    }

    public sealed class SectorElement : PictureBox
    {
        private readonly SectorArea _sectorArea;
        private bool _selected;

        public EventHandler<EventArgs> ElementSelected;

        public SectorElement(SectorArea sectorArea)
        {
            _sectorArea = sectorArea;
            AllowDrop = true;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            OnElementSelected();
            DoDragDrop(_sectorArea.SelectedElements, DragDropEffects.Move);
        }

        private void OnElementSelected()
        {
            if (ElementSelected != null)
                ElementSelected(this, EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (!Selected) 
                return;

            using (var p = new Pen(Color.Red, 0.1f))
                pe.Graphics.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
        }


        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if (value != _selected)
                    Invalidate();

                _selected = value;

            }
        }

        public string ElementIdentifier
        {
            get;
            set;
        }

        public List<KeyValuePair<string, string>> Parameters { get; set; }

        public int ZIndex { get; set; }

        public string ToString(int clientRectangleHeight)
        {
            var key = Tag.ToString();

            var parameters = String.Empty;

            if (Parameters != null)
            {
                parameters =
                    Parameters.Where(p => !String.IsNullOrWhiteSpace(p.Key) && !String.IsNullOrWhiteSpace(p.Value))
                        .Aggregate(parameters,
                            (current, p) =>
                                current +
                                (p.Key.Replace(' ', '_').Replace('=', '_').Replace('|', '_') + '=' +
                                 p.Value.Replace(' ', '_').Replace('=', '_').Replace('|', '_') + '|'));
            }

            return key + " " +
                   Name + " " +
                   Left + " " +
                   (clientRectangleHeight - Top - Height) + " " +
                   Width + " " +
                   Height + " " +
                   ZIndex + " " +
                   parameters;
        }
    }
}
