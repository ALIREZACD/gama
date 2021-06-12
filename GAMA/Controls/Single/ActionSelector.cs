using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAMA.Interfaces;
using GAMA.Classes;
using MyClass;

namespace GAMA.Controls.Single
{
    public partial class ActionSelector : FlowLayoutPanel, IExpandable, IGAMAControl
    {
        public ActionSelector()
        {
            InitializeComponent();
            _timer.Elapsed += Timer_Elapsed;
            if (IsExpanded)
                Height = ExpandedHeight;
            else
                Height = 0;
        }

        #region Fields

        private System.Timers.Timer _timer = new System.Timers.Timer(30);
        private bool _isExpanded = false;
        private TransitionStep _transtion;
        private Color _actionBackColor = Color.Cyan;
        private Color _actionForeColor = Color.Black;
        private Size _actionSize = new Size(100, 60);

        #endregion


        #region Properties

        public int ExpandedHeight { get; protected set; } = 100;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded != value)
                    ToggleExpandState();
            }
        }
        public bool IsExpanding { get; protected set; } = false;
        public int TransitionDelay { get; set; } = 200;
        public Color ItemBackColor
        {
            get => _actionBackColor;
            set
            {
                _actionBackColor = value;
                InvokeAction(c => c.BackColor = value);
            }
        }
        public Color ItemForeColor
        {
            get => _actionForeColor;
            set
            {
                _actionForeColor = value;
                InvokeAction(c => c.ForeColor = value);
            }
        }
        public Size ItemSize
        {
            get => _actionSize;
            set
            {
                _actionSize = value;
                InvokeAction(c => c.Size = value);
            }
        }

        #endregion


        #region Event Implication

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _transtion.UpdateTransiotionPosition();
        }

        private void Transition_Finished(object sender, EventArgs e)
        {
            _timer.Stop();
            Invoke((MethodInvoker)delegate
           {
               _transtion = null;
               _isExpanded = !_isExpanded;
               IsExpanding = false;
               if (_isExpanded)
               {
                   Expanded?.Invoke(this, new EventArgs());
                   if (Height != ExpandedHeight)
                       Height = ExpandedHeight;
               }
               else
                   Collapsed?.Invoke(this, new EventArgs());
           });
        }

        #endregion


        #region Functions

        public void Expand()
        {
            IsExpanding = true;
            _transtion = CreateTransition(ExpandedHeight);
            _timer.Start();
        }

        public void Collapse()
        {
            IsExpanding = true;
            _transtion = CreateTransition(0);
            _timer.Start();
        }

        public void ToggleExpandState()
        {
            if (IsExpanding)
                return;
            else if (IsExpanded)
                Collapse();
            else
                Expand();
        }

        public void AlignMiddle(Control ctrl)
        {
            Locations.AlignMiddles(ctrl, this);
        }

        public void AlignCenter(Control ctrl)
        {
            Locations.AlignCenters(ctrl, this);
        }

        public BtnSimple AddItem(Action<object, EventArgs> action, string title)
        {
            BtnSimple btn = new BtnSimple()
            {
                Text = title,
                BackColor = ItemBackColor,
                ForeColor = ItemForeColor,
                Size = ItemSize
            };
            btn.Click += new EventHandler(action);
            AddItem(btn);
            return btn;
        }

        public void AddItem(BtnSimple action)
        {
            Controls.Add(action);
        }

        public void RemoveItem(BtnSimple action)
        {
            Controls.Remove(action);
        }

        public void InvokeAction(Action<Control> action)
        {
            for (int i = 0; i < Controls.Count; i++)
                action(Controls[i]);
        }

        private TransitionStep CreateTransition(int height)
        {
            TransitionStep result = new TransitionStep(this, "Height", height, TransitionDelay);
            result.TrantisionFinished += Transition_Finished;
            return result;
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!IsExpanding && IsExpanded)
                ExpandedHeight = height;
            if (IsExpanding || IsExpanded)
                base.SetBoundsCore(x, y, width, height, specified);
            else
                base.SetBoundsCore(x, y, width, 0, specified);
        }

        #endregion


        #region Events

        public event EventHandler Collapsed;
        public event EventHandler Expanded;

        #endregion
    }
}
