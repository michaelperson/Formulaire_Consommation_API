using Formulaire_Consommation_API.Client.Services.Interfaces;
using Formulaire_Consommation_API.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Services
{
    public class AuthService : IAuthService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";
        public UtilisateurModel User
        {
            get;

            set;
        }

        public AuthService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<UtilisateurModel>(_userKey);
        }

        public async Task Login(UtilisateurModel model)
        {
            User = await _httpService.Post<UtilisateurModel>("api/Users/Login", model);
            await _localStorageService.SetItem(_userKey, User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("secure/login");
        }
    }
}
