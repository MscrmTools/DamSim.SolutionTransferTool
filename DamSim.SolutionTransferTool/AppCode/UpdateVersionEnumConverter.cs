﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace DamSim.SolutionTransferTool.AppCode
{
    internal class UpdateVersionEnumConverter : EnumConverter
    {
        private readonly Type enumType;

        public UpdateVersionEnumConverter(Type type) : base(type)
        {
            enumType = type;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
        {
            return srcType == typeof(string);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture,
            object value)
        {
            foreach (FieldInfo fi in enumType.GetFields())
            {
                DescriptionAttribute dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi,
                    typeof(DescriptionAttribute));
                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(enumType, fi.Name);
            }
            return Enum.Parse(enumType, (string)value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture,
                    object value, Type destType)
        {
            FieldInfo fi = enumType.GetField(Enum.GetName(enumType, value));
            DescriptionAttribute dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi,
                typeof(DescriptionAttribute));
            if (dna != null)
                return dna.Description;
            else
                return value.ToString();
        }
    }
}