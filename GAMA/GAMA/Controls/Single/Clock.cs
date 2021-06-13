using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GAMA
{
    public partial class Clock : UserControl, IDisposable
    {
        public Clock()
        {
            AdjustText();
            if (CutRegion)
                SetRegion();
        }

        //Variables****************************
        #region

        // Booleans
        private bool _cutRegion = false;

        // Floats
        private float _clockValue = 0;
        private float _reachedWidth = 5;
        private float _unreachedWidth = 5;
        private float _outLineWidth = 1;

        // Colors
        private Color _insideColor = Color.White;
        private Color _reachedColor = Color.Blue;
        private Color _outLineColor = Color.White;
        private Color _unreachedColor = Color.Gray;

        // Images
        private Image _insideImage;
        private Image _cropedInsideImage;

        // Sizes
        private SizeF _textLableSize;

        // Points
        private PointF _textPoint;

        #endregion
        //*************************************

        //Properties***************************
        #region
        public Image InsideImage
        {
            get => _insideImage;
            set
            {
                _insideImage = value;
                if (value != null)
                {
                    AdjustBackgroundImage();
                    DrawClock();
                }
            }
        }
        public override ImageLayout BackgroundImageLayout
        {
            get => base.BackgroundImageLayout;
            set
            {
                base.BackgroundImageLayout = value;
                if (InsideImage != null)
                {
                    AdjustBackgroundImage();
                    DrawClock();
                }
            }
        }
        public Color InsideColor
        {
            get => _insideColor;
            set
            {
                _insideColor = value;
                DrawClock();
            }
        }
        public Color OutLineColor
        {
            get => _outLineColor;
            set
            {
                _outLineColor = value;
                DrawClock();
            }
        }
        public float OutLineWidth
        {
            get => _outLineWidth;
            set
            {
                _outLineWidth = value;
                AdjustBackgroundImage();
                DrawClock();
            }
        }
        public Color ReachedColor
        {
            get => _reachedColor;
            set
            {
                _reachedColor = value;
                DrawClock();
            }
        }
        public Color UnreachedColor
        {
            get => _unreachedColor;
            set
            {
                _unreachedColor = value;
                DrawClock();
            }
        }
        /// <summary>
        /// value should be between 0 and 59
        /// </summary>
        public float ClockValue
        {
            get => _clockValue;
            set
            {
                CheckSecondValue(value);
                _clockValue = value;
                DrawClock();
            }
        }
        public float ReachedWidth
        {
            get => _reachedWidth;
            set
            {
                _reachedWidth = value;
                AdjustText();
                AdjustBackgroundImage();
                DrawClock();
            }
        }
        public float UnreachedWidth
        {
            get => _unreachedWidth;
            set
            {
                _unreachedWidth = value;
                AdjustText();
                AdjustBackgroundImage();
                DrawClock();
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                SetLabelSize();
                AdjustText();
                DrawClock();
            }
        }

        [Browsable(true)]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                SetLabelSize();
                AdjustText();
                DrawClock();
            }
        }

        public bool CutRegion
        {
            get
            {
                return _cutRegion;
            }
            set
            {
                _cutRegion = value;

                SetRegion();
            }
        }

        #endregion
        //*************************************

        //Events*******************************
        #region 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawClock();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            AdjustText();
            DrawClock();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AdjustBackgroundImage();
            AdjustText();
            DrawClock();
            SetRegion();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        #endregion
        //*************************************

        //Methods******************************
        #region 

        private void DrawClock()
        {
            // Creating Graphic
            using (Bitmap image = new Bitmap(Width, Height))
            using (Graphics gr = Graphics.FromImage(image))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.CompositingQuality = CompositingQuality.HighQuality;

                // Painting
                gr.Clear(BackColor);
                PaintInsideColor(gr);
                DrawBackgroundImage(gr);
                DrawText(gr);
                DrawProgressbar(gr, ClockValue);
                SetLabelSize();

                using (Graphics gr2 = CreateGraphics())
                    gr2.DrawImage(image, Point.Empty);
            }
        }
        private void SetRegion()
        {
            if (Region != null)
                DisposeObjects(Region);
            Rectangle rect = ClientRectangle;
            rect.Inflate(1, 1);
            if (CutRegion)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(rect);
                    Region = new Region(path);
                }
            }
            else
                Region = new Region(ClientRectangle);
        }
        // Text ----------------------------------------↓↓↓
        public void SetLabelSize()
        {
            using (Graphics gr = CreateGraphics())
                _textLableSize = gr.MeasureString(Text, Font);
        }
        public void AdjustText()
        {
            AdjustTextFont();
            SetLabelSize();
            AdjustTextPoint();
        }
        private void AdjustTextFont()
        {
            const float rate = 0.3f;
            SizeF tempTextSize = _textLableSize;
            Font tempFont = new Font(Font.Name, Font.Size, Font.Style);
            while (IsSizeOut(tempTextSize))
            {
                tempTextSize = TextRenderer.MeasureText(Text, tempFont);
                float fontSize = tempFont.Size - rate;
                tempFont = new Font(tempFont.FontFamily, tempFont.Size - rate < 0 ? 0 : fontSize, Font.Style);
            }
            if (Font.Size != tempFont.Size)
                Font = new Font(tempFont.FontFamily, tempFont.Size, Font.Style);
            DisposeObjects(tempFont);
        }
        private bool IsSizeOut(SizeF size)
        {
            if (size.Width + 2 * (Math.Max(ReachedWidth, UnreachedWidth) + OutLineWidth) > Width ||
                size.Height + 2 * (Math.Max(ReachedWidth, UnreachedWidth) + OutLineWidth) > Height)
                return true;
            return false;
        }
        private void AdjustTextPoint()
        {
            _textPoint = new PointF(Width / 2F - _textLableSize.Width / 2F, Height / 2F - _textLableSize.Height / 2F);
        }
        private void DrawText(Graphics gr)
        {
            gr.DrawString(Text, Font, new SolidBrush(ForeColor), new RectangleF(_textPoint, _textLableSize));
        }
        // -----------------------------------------------
        private void CheckSecondValue(float value)
        {
            if (value > 59 || value < 0)
                throw new ArgumentException("Argument Should be between 0 and 59");
        }
        private void PaintInsideColor(Graphics gr)
        {
            Rectangle rect = ClientRectangle;
            int maxWidth = -(int)Math.Max(ReachedWidth, UnreachedWidth);
            rect.Inflate(maxWidth, maxWidth);
            gr.FillEllipse(new SolidBrush(InsideColor), rect);
        }
        // Background Image ------------------------------
        private void DrawBackgroundImage(Graphics gr)
        {
            if (InsideImage == null) return;
            gr.DrawImage(_cropedInsideImage, Width / 2 - _cropedInsideImage.Width / 2, Height / 2 - _cropedInsideImage.Height / 2);
        }
        private void AdjustBackgroundImage()
        {
            if (InsideImage != null)
            {
                float maxWidth = Math.Max(ReachedWidth, UnreachedWidth);
                _cropedInsideImage = CropImageEllipsis(ResizeImage(new Bitmap(InsideImage), (int)((maxWidth + OutLineWidth) * 2)), maxWidth);
            }
        }
        private Bitmap ResizeImage(Bitmap bitmap, int subtract)
        {
            switch (BackgroundImageLayout)
            {
                case ImageLayout.Stretch:
                    return new Bitmap(bitmap, Width - subtract, Height - subtract);
                case ImageLayout.Zoom:
                    int maxWidth = Math.Max(Height, Width);
                    return new Bitmap(bitmap, maxWidth - subtract, maxWidth - subtract);
                default:
                    float maxBarWidth = Math.Max(ReachedWidth, UnreachedWidth);
                    float width = bitmap.Width > Width - maxBarWidth ? Width - maxBarWidth : bitmap.Width;
                    float height = bitmap.Height > Height - maxBarWidth ? Height - maxBarWidth : bitmap.Height;
                    return bitmap.Clone(new RectangleF(width / 2, height / 2, width - 50, height - 50), System.Drawing.Imaging.PixelFormat.Format64bppArgb);
            }
        }
        private Bitmap CropImageEllipsis(Bitmap bitmap, float subtract)
        {
            Bitmap bt = new Bitmap(bitmap.Width, bitmap.Height);
            using (Graphics g = Graphics.FromImage(bt))
            using (GraphicsPath gp = new GraphicsPath())
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                gp.AddEllipse(0, 0, bitmap.Width, bitmap.Height);
                g.Clear(Color.Magenta);
                g.SetClip(gp);
                g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
            }
            bt.MakeTransparent(Color.Magenta);
            return bt;
        }
        // ----------------------------------------------------
        private void DrawProgressbar(Graphics gr, float value)
        {
            if (UnreachedWidth > 0)
                DrawUnreachedProgress(gr, value == 0 ? 0.0001f : value, UnreachedWidth);
            if (value > 0 && ReachedWidth > 0)
                DrawReachedProgress(gr, value, ReachedWidth);
            if (OutLineWidth > 0)
                DrawOutLine(gr, OutLineWidth);
        }
        private void DrawUnreachedProgress(Graphics gr, float value, float width)
        {
            float startAngle = (value) * 6 - 90;
            Pen pen = new Pen(UnreachedColor, width)
            {
                Alignment = PenAlignment.Inset,
                EndCap = LineCap.Round,
                StartCap = LineCap.Round
            };
            Rectangle rect = ClientRectangle;
            float maxWidth = Math.Max(ReachedWidth, UnreachedWidth);
            rect.Inflate(-(int)(maxWidth / 2 + 1), -(int)(maxWidth / 2 + 1));
            gr.DrawArc(pen, rect, startAngle, 360 - (value * 6));
        }
        private void DrawReachedProgress(Graphics gr, float value, float width)
        {
            float sweepAngle = (value) * 6;
            Pen pen = new Pen(ReachedColor, width)
            {
                Alignment = PenAlignment.Inset,
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };
            Rectangle rect = ClientRectangle;
            float maxWidth = Math.Max(ReachedWidth, UnreachedWidth);
            rect.Inflate(-(int)(maxWidth / 2 + 1), -(int)(maxWidth / 2 + 1));
            gr.DrawArc(pen, rect, 270, sweepAngle);
        }
        private void DrawOutLine(Graphics gr, float width)
        {
            Pen pen = new Pen(OutLineColor, OutLineWidth)
            {
                Alignment = PenAlignment.Inset
            };
            Rectangle rect = ClientRectangle;
            int maxWidth = -(int)Math.Max(ReachedWidth, UnreachedWidth);
            rect.Inflate(maxWidth, maxWidth);
            gr.DrawEllipse(pen, rect);
        }
        private void DisposeObjects(params IDisposable[] objects)
        {
            for (int i = 0; i < objects.Length; i++)
                objects[i].Dispose();
        }

        #endregion
        //*************************************
    }
}
