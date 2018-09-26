using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common
{
    public partial class ButtonGroupBoxControl : UserControl
    {
        public event EventHandler<ValueSelectedEventArgs> ValueSelected;

        private ButtonsCollection _buttons = new ButtonsCollection();
        public ButtonsCollection Buttons { get => _buttons; }

        public int DefaultButtonWidth { get; set; } = 110;

        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get => groupBox.Text;
            set => groupBox.Text = value;
        }

        public ButtonGroupBoxControl()
        {
            InitializeComponent();

            _buttons.CollectionChanged += ButtonsCollection_CollectionChanged;
        }

        private void ButtonsCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // TODO: process different actions (add, remove, etc.) in differnt way
            // how to get action: e.Action = System.Collections.Specialized.NotifyCollectionChangedAction.Add

            flowLayoutPanel.Controls.Clear();

            foreach (var btn in _buttons)
            {
                btn.Click -= Btn_Click;
                btn.Click += Btn_Click;
                btn.Width = DefaultButtonWidth;
                flowLayoutPanel.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (RadButton)sender;

            var arg = new ValueSelectedEventArgs(btn, btn.Tag);

            ValueSelected?.Invoke(this, arg);
        }
    }

    public class ButtonsCollection : ObservableCollection<RadButton>
    {
        public ButtonsCollection() : base()
        {
        }

        public void AddButton(string text, object value)
        {
            var btn = new RadButton();
            btn.Text = text;
            btn.Tag = value;
            Add(btn);
        }
    }

    public class ValueSelectedEventArgs : EventArgs
    {
        public RadButton Button { get; private set; }
        public object Value { get; private set; }

        public ValueSelectedEventArgs(RadButton button, object value)
        {
            Button = button;
            Value = value;
        }
    }
}
