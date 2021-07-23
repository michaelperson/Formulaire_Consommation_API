using Formulaire_Consommation_API.Client.Services.Interfaces;
using Formulaire_Consommation_API.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Pages.secure
{
    
    public class MemberBase: ComponentBase
    {
        private UtilisateurModel _model;
        [Inject]
        HttpClient http { get; set; }
        [Inject]
        ILocalStorageService localStorageService { get; set; }
        [Inject]
        IAlertService AlertService { get; set; }

        protected UtilisateurModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public MemberBase()
        {
            Model = new UtilisateurModel();
        }

        protected async override void OnInitialized()
        {
            _model=  await  localStorageService.GetItem<UtilisateurModel>("user");
            base.OnInitialized();
        }

        protected async Task OnValidSubmit()
        {
            string User = JsonSerializer.Serialize(Model);
            StringContent requestContent = new StringContent(User, Encoding.UTF8, "application/json");
            var response = await http.PutAsync("/api/Users",requestContent);
            if(response.IsSuccessStatusCode)
            {
                AlertService.Success("Mot de passe changé");
            }
            else
            {
                AlertService.Error("Impossible de changer le mot de passe");
            }
        }
    }
}
