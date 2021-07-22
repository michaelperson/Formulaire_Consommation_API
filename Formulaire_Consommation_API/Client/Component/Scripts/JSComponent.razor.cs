using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Component.Scripts
{
    public class JSComponentBase : ComponentBase
    {
        [Inject]
        private IJSRuntime jSRuntime { get; set; }
        protected DotNetObjectReference<JSComponentBase> dotNetReference; 
        protected List<string> Messages = new List<string>();
        protected async Task SendInfo()
        {
           await jSRuntime.InvokeAsync<string>("Info", "Bonjour");
        }

        public JSComponentBase()
        {
            dotNetReference = DotNetObjectReference.Create(this);
        }

        [JSInvokable("AjouterInfo")]
        public void Ajouter(string text)
        {
            Messages.Add(text.ToString());
            while (Messages.Count > 10)
                Messages.RemoveAt(0);
            StateHasChanged(); //Notifie le composant qu'une mise à jour a été faite
            System.Diagnostics.Debug.WriteLine("DotNet: Received " + text);
        }
    }
}
