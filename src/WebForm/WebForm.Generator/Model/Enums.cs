using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebForm.Generator.Model
{
    internal enum AlignmentEnum
    {
        Left = 1,
        Right = 2,
        Center = 3,
    }

    internal enum FontTypeEnum
    {
        Normal = 1,
        Bold = 2,
        Italic = 3,
        BoldItalic = 4,
    }

    internal enum PageSizeEnum
    {
        A3 = 1,
        A4 = 2,
        A5 = 3,
    }

    internal enum PageOrientationEnum
    {
        Portrait = 1,
        Landscape = 2,
    }

    [Flags]
    internal enum BorderSideEnum
    {
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8,
    }

    [Flags]
    internal enum MetaFieldType
    {
        String = 1,
        Number = 2,
        Logic = 4,
    }

    internal enum MsgLevelEnum
    {
        Info = 1,
        Warning = 2,
        Error = 3,
        FatalError = 4,
    }

    internal enum ControlTypeEnum
    {
        Undef = 0,
        Text = 1,
        Check = 2,
        Combo = 3,
        Date = 4,
        TText = 5,
        FText = 6,
        ScroolTAText = 7,
    }

    internal enum FieldTypeBaseEnum
    {
        Undef = 0,
        Text = 1,
        Bool = 2,
        Date = 3,
        Number = 4,
    }

    internal enum LabelRotationEnum
    {
        None = 0,
        Angle90 = 1,
        Angle270 = 3,
    }
}
