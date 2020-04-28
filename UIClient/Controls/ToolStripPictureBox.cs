using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace UIClient.Controls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip)]
    public class ToolStripPictureBox : ToolStripControlHost
    {
        private System.Windows.Forms.Timer _timer = new Timer();
        private Image _image = global::UIClient.Properties.Resources.sand_timer;

        public ToolStripPictureBox() : base(new PictureBox())
        {
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += Timer_Tick; ;
            _timer.Enabled = true;
        }

        public PictureBox PictureBox
        {
            get
            {
                return this.Control as PictureBox;
            }
        }

        private bool _enableAnimation = true;
        public bool EnableAnimation
        {
            get
            {
                return _enableAnimation;
            }
            set
            {
                if (_enableAnimation != value)
                {
                    _enableAnimation = value;

                    if (value)
                    {
                        _angle = 0;
                        _timer.Enabled = true;
                    }
                    else
                    {
                        _timer.Enabled = false;
                        PictureBox.Refresh();
                    }
                }
            }
        }

        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);

            PictureBox pictureBox = (PictureBox)control;
            pictureBox.Paint += new PaintEventHandler(PictureBox_Paint);
        }

        private Matrix _matrix = new Matrix();
        float _angle = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            int t = 1;
            if (this.IsDisposed)
                t = 20;
            _matrix = new Matrix();
            _matrix.RotateAt(_angle, new PointF(PictureBox.Width / 2, PictureBox.Height / 2), MatrixOrder.Append);

            _angle += 30;
            PictureBox.Refresh();

        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_enableAnimation)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Graphics g = e.Graphics;
                g.Transform = _matrix;
                g.DrawImage(_image, pictureBox.Width / 2 - _image.Width / 2,
                    pictureBox.Height / 2 - _image.Height / 2);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _timer.Enabled = false;
                _timer.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
