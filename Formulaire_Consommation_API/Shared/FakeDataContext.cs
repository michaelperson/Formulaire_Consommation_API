using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Shared
{
    public class FakeDataContext : IFakeDataContext
    {
        List<UtilisateurModel> _utilisateurs;
        public List<UtilisateurModel> Utilisateurs
        {
            get { return _utilisateurs = _utilisateurs ?? LoadUsers(); }
            private set { _utilisateurs = value; }
        }


        public bool RegisterUser(UtilisateurModel um)
        {
            Utilisateurs.Add(um);
            return true;
        }

        public UtilisateurModel AuthUser(string email, string password)
        {
            return Utilisateurs.FirstOrDefault(m => m.Email == email && m.Password == password);
        }

        private List<UtilisateurModel> LoadUsers()
        {
            return new List<UtilisateurModel>()
            {
              new UtilisateurModel(){ Email="User1@gmail.com", Password="Test1234=" },
              new UtilisateurModel(){ Email="User2@gmail.com", Password="User@test" },
              new UtilisateurModel(){ Email="User3@gmail.com", Password="Admin" },
            };
        }



    }
}
