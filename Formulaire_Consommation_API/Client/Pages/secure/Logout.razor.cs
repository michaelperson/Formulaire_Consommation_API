using Formulaire_Consommation_API.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Pages.secure
{
    public class LogoutBase: ComponentBase
    {
        [Inject]
        IAuthService AuthService { get; set; }
        protected override async void OnInitialized()
        {
            await AuthService.Logout();
        }
    }
}
