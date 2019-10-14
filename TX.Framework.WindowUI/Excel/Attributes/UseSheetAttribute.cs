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
using System.Linq;
using System.Text;

namespace System.Office.Excel
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UseSheetAttribute : Attribute
    {
        private string _SheetName;
        public string SheetName
        {
            get { return _SheetName; }
            set { _SheetName = value; }
        }

        public UseSheetAttribute()
        {
        }

        public UseSheetAttribute(string sheetName)
        {
            _SheetName = sheetName;
        }
    }
}

