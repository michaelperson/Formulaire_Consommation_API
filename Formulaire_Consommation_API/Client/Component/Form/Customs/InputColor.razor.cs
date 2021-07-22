using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Component.Form.Customs
{
    public class CustomInputColor : InputBase<Color>
    {
        static Regex Regex = new Regex("^#([0-9a-f]{2}){3}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        [Parameter] 
        public string ParsingErrorMessage { get; set; }
        public static string ColorToString(Color value)
        { 
            return $"#{value.R:x2}{value.G:x2}{value.B:x2}"; 
        }
        protected override string FormatValueAsString(Color value)
        {
            return ColorToString(value);
        }
        protected override bool TryParseValueFromString(string value, [MaybeNullWhen(false)] out Color result, [NotNullWhen(false)] out string validationErrorMessage)
        {
            Match match = Regex.Match(value);
            if (!match.Success)
            {
                validationErrorMessage = "Not a valid color code";
                result = Color.Red;
                return false;
            }
            byte r = HexStringToByte(match.Groups[1].Captures[0].Value);
            byte g = HexStringToByte(match.Groups[1].Captures[1].Value);
            byte b = HexStringToByte(match.Groups[1].Captures[2].Value);
            validationErrorMessage = null;
            result = Color.FromArgb(r, g, b);
            return true;
        }

        private byte HexStringToByte(string hex)
        {
            const string HexChars = "0123456789abcdef";
            hex = hex.ToLowerInvariant();
            int result = (HexChars.IndexOf(hex[0]) * 16) + HexChars.IndexOf(hex[1]);
            return (byte)result;
        }
    }
}
