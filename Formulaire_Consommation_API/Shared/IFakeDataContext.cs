using System.Collections.Generic;

namespace Formulaire_Consommation_API.Shared
{
    public interface IFakeDataContext
    {
        List<UtilisateurModel> Utilisateurs { get; }

        UtilisateurModel AuthUser(string email, string password);
        bool RegisterUser(UtilisateurModel um);
    }
}