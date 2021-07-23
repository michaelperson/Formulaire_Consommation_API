using Formulaire_Consommation_API.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Client.Services.Interfaces
{
    public interface IAuthService
    {
        UtilisateurModel User { get; set; }
        Task  Initialize();
        Task Login(UtilisateurModel model);
        Task Logout();
    }
}
