using Formulaire_Consommation_API.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Component.Api
{
    public class ListingBase:ComponentBase
    {
        
        [Inject]
        public HttpClient Http { get; set; }

        
        protected List<UtilisateurModel> Users;
        //public ListingBase(IFakeDataContext dataContext)
        //{
        //    ctx = dataContext;
        //}

        protected override async Task OnInitializedAsync()
        {
            Users= await Http.GetFromJsonAsync<List<UtilisateurModel>>("api/Users");
        }
    }
}
