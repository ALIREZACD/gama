﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace WindowsFormsApp9
{
    public class Calendar : DateTimePicker
    {
        #region fields
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.PaleVioletRed;
        private int borderSize = 0;
        private bool droppedDown = false;
        private Image calendarIcon = Image.FromFile(@"G:\calendar_color.png");
        //
        private RectangleF iconButtonArea;
        private const int calendarIconWidth = 34;
        private const int arrowIconWidth = 17;
        #endregion
        #region property
        public Color SkinColor
        {
            get => skinColor;
            set
            {
                skinColor = value;
                if (skinColor.GetBrightness() <= 0.8f)
                    calendarIcon = Image.FromFile(@"G:\calendar.png");
                else
                    calendarIcon = Image.FromFile(@"G:\calendar_color.png");
                this.Invalidate();
            }
        }
        public Color TextColor { get => textColor; set { textColor = value; this.Invalidate(); } }
        public Color BorderColor { get => borderColor; set {borderColor = value;this.Invalidate();} }
        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }
        #endregion
        #region methods
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;

        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics graphics = this.CreateGraphics())
            using (Pen borderPen = new Pen(borderColor, borderSize))
            using (SolidBrush skinBrush = new SolidBrush(skinColor))
            using (SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat textFormat=new StringFormat())
            {
                RectangleF clientArea = new RectangleF(0, 0, this.Width - 0.5f, this.Height - 0.5f);
                RectangleF iconArea = new RectangleF(clientArea.Width - calendarIconWidth, 0,calendarIconWidth,clientArea.Height);
                borderPen.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;
                graphics.FillRectangle(skinBrush, clientArea);
                graphics.DrawString("   "+this.Text, this.Font, textBrush, clientArea, textFormat);
                if (droppedDown) graphics.FillRectangle(openIconBrush, iconArea);
                if (borderSize >= 1) graphics.DrawRectangle(borderPen, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
                graphics.DrawImage(calendarIcon, this.Width - 39, (this.Height-30)/2,30,30);

            }    
        }
        private int GetIconButtonWidth()
        {
            int textWidth = TextRenderer.MeasureText(this.Text, this.Font).Width;
            if (textWidth <= this.Width - (calendarIconWidth + 20))
                return calendarIconWidth;
            else return arrowIconWidth;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(this.Width - iconWidth, 0, iconWidth, this.Height);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (iconButtonArea.Contains(e.Location))
                this.Cursor = Cursors.Hand;
            else this.Cursor = Cursors.Default;
        }
        #endregion
        #region Event

        #endregion
        #region Constructor
        public Calendar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new Size(0, 35);
            this.Font = new Font(this.Font.Name, 9.5f);
        }
        #endregion
    }
}
