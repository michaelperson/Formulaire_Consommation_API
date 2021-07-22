using Formulaire_Consommation_API.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Component.Scripts
{
    public class StorageBase : ComponentBase
    {
        protected string Message { get; set; }
        protected Sample Data { get; set; } = new Sample();

        protected string InfoStorage { get; set; }
        [Inject]
        private ILocalStorageService _service { get; set; }
        

        public async Task AddToStorage()
        {
           await _service.SetItem<string>(Data.Key, Data.Value);
            Message = $"{Data.Key} ajouté";
        }

        public async Task GetData(string key)
        {
            InfoStorage = await _service.GetItem<string>(Data.Key);
            Message = $"{Data.Key} récupérée";
            StateHasChanged();
        }
    }

    public class Sample
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }


}
