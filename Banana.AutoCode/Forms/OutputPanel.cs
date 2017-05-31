﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Banana.AutoCode.Forms
{
    public partial class OutputPanel : DockContent
    {
        delegate void AppendTextAction(string msg, Color foreColor);

        public OutputPanel()
        {
            InitializeComponent();
        }

        public void AppendText(string message, Color foreColor)
        {
            if (richTextBox.IsDisposed)
            {
                return;
            }

            if (richTextBox.InvokeRequired)
            {
                var action = new AppendTextAction(AppendText);
                richTextBox.Invoke(action, message, foreColor);
            }
            else
            {
                richTextBox.ForeColor = foreColor;
                richTextBox.AppendText(message);
            }
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            this.richTextBox.Copy();
        }

        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            this.richTextBox.SelectAll();
        }

        private void tsmiClearAll_Click(object sender, EventArgs e)
        {
            this.richTextBox.Clear();
        }
    }
}