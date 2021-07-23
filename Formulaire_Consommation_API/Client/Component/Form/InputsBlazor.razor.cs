using Formulaire_Consommation_API.Client.Component.Form.Customs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Component.Form
{
    public class InputsBlazorBase : ComponentBase
    {
        protected SomeModel FormData = new SomeModel();
        protected string ColorHEx { get { return InputColor.ColorToString(FormData.SomeColor); } }
    }

    public class SomeModel
    {
        public bool SomeBooleanProperty { get; set; }
        public DateTime? SomeDateTimeProperty { get; set; }
        public int SomeIntegerProperty { get; set; }
        public decimal SomeDecimalProperty { get; set; }
        public string SomeStringProperty { get; set; } = "#78AAF5";
        public string SomeMultiLineStringProperty { get; set; }
        public SomeStateEnum SomeSelectProperty { get; set; } = SomeStateEnum.Suspended;

        public Color SomeColor { get; set; } = Color.White;
    }
    public enum SomeStateEnum
    {
        Pending,
        Active,
        Suspended
    }
}
