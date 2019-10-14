﻿#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace TX.Framework.WindowUI.Controls
{
    [ToolboxItem(false)]
    public class MultiselectComboBoxListControl : ScrollableControl
    {
        private MultiselectComboBox _CheckBoxComboBox;
        private MultiselectComboBoxItemList _Items = new MultiselectComboBoxItemList();

        public MultiselectComboBoxListControl(MultiselectComboBox owner)
            : base()
        {
            DoubleBuffered = true;
            _CheckBoxComboBox = owner;
            BackColor = SystemColors.Window;
            AutoScroll = true;
            ResizeRedraw = true;
            MinimumSize = new Size(1, 1);
            MaximumSize = new Size(500, 500);
        }

        protected override void WndProc(ref Message m)
        {
            if ((Parent.Parent as Popup).ProcessResizing(ref m))
            {
                return;
            }
            base.WndProc(ref m);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            SynchroniseControlsWithComboBoxItems();
            base.OnVisibleChanged(e);
        }

        public void SynchroniseControlsWithComboBoxItems()
        {
            SuspendLayout();
            Controls.Clear();

            for (int Index = _Items.Count - 1; Index >= 0; Index--)
            {
                MultiselectComboBoxItem Item = _Items[Index];
                if (!_CheckBoxComboBox.Items.Contains(Item.ComboBoxItem))
                {
                    _Items.Remove(Item);
                    Item.Dispose();
                }
            }

            MultiselectComboBoxItemList NewList = new MultiselectComboBoxItemList();
            foreach (object obj in _CheckBoxComboBox.Items)
            {
                MultiselectComboBoxItem Item = _Items.Find(t => t.ComboBoxItem == obj);
                if (Item == null)
                {
                    Item = new MultiselectComboBoxItem(_CheckBoxComboBox, obj);
                    Item.ApplyProperties(_CheckBoxComboBox.CheckBoxProperties);
                }
                NewList.Add(Item);
                Item.Dock = DockStyle.Top;
            }
            _Items.Clear();
            _Items.AddRange(NewList);

            if (NewList.Count > 0)
            {
                NewList.Reverse();
                Controls.AddRange(NewList.ToArray());
            }

            ResumeLayout();
        }

        public MultiselectComboBoxItemList Items
        {
            get { return _Items; }
        }
    }

}
