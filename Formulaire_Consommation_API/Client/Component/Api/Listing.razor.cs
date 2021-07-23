using Formulaire_Consommation_API.Client.Services.Interfaces;
using Formulaire_Consommation_API.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Component.Api
{
    public class ListingBase:ComponentBase
    {
        protected string Status = "";
        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private ILocalStorageService local { get; set; }
        
        protected List<UtilisateurModel> Users;

       
        protected override async Task OnInitializedAsync()
        {

             Users = await Http.GetFromJsonAsync<List<UtilisateurModel>>("api/Users");
             
            //try
            //{
            //    HttpResponseMessage mess = await Http.GetAsync("api/Userzs");
            //    if (mess.IsSuccessStatusCode)
            //    {
            //        Users = await mess.Content.ReadFromJsonAsync<List<UtilisateurModel>>();
            //    }
            //    else
            //    {
            //        Status = $"Erreur de connection : {mess.StatusCode}";
            //    }
            //}
            //catch (Exception ex)
            //{

            //    Status = $"Erreur de connection : {ex.Message}";
            //}
        }
    }
}
