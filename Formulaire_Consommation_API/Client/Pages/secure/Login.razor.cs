using Formulaire_Consommation_API.Client.Helper;
using Formulaire_Consommation_API.Client.Services.Interfaces;
using Formulaire_Consommation_API.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Pages.secure
{
    public class LoginBase:ComponentBase
    {
        [Inject] 
        IAuthService AuthService { get; set; }
        [Inject]
        IAlertService AlertService { get; set; }
        [Inject]
        NavigationManager NavigationManager{ get; set; }

        protected UtilisateurModel model = new UtilisateurModel();
        protected bool loading;

        protected async void OnValidSubmit()
        {
            // reset alerts on submit
            AlertService.Clear();

            loading = true;
            try
            {
                await AuthService.Login(model);
                var returnUrl = NavigationManager.QueryString("returnUrl") ?? "";
                NavigationManager.NavigateTo(returnUrl);
            }
            catch (Exception ex)
            {
                AlertService.Error(ex.Message);
                loading = false;
                StateHasChanged();
            }
        }
    }
}
