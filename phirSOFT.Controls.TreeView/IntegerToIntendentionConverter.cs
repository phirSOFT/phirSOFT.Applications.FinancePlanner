using System;
using System.Globalization;
using System.Windows;
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="IntegerToIntendentionConverter.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package phirSOFT.Controls.TreeView
// 
// Created by:    Philemon Eichin
// Created:       05.08.2017 20:20
// Last Modified: 05.08.2017 20:20
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------

using System.Windows.Data;

namespace phirSOFT.Controls.TreeView
{
    public class IntegerToIntendentionConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var indent = new Thickness(0);

            if (value is int level)
                indent.Left = level * IndentMultiplier;

            return indent;
        }

        public int IndentMultiplier { get; set; } = 20;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}