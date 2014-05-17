using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gamon.ForeignWords
{
    public partial class chk:System.Windows.Forms.CheckBox
    {
        public chk()
        {
            InitializeComponent();
        }

        public chk(Control.ControlCollection container, string Name)
        {
            container.Add(this);

            InitializeComponent();
            this.Name = Name;
        }
    }
}
