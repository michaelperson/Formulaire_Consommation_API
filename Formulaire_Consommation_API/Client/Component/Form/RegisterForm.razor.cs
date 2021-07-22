using Formulaire_Consommation_API.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms; 
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
namespace Formulaire_Consommation_API.Client.Component.Form
{
    public class RegisterFormBase: ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        protected string Status = "";
        
        private EditContext editContext;

        protected EditContext EditContext
        {
            get
            {
                return editContext;
            }

            set
            {
                editContext = value;
            }
        }

        private UtilisateurModel _utilisateur;
        private UtilisateurModel _utilisateur2;
        private UtilisateurModel _utilisateur3;
        protected UtilisateurModel Utilisateur
        {
            get
            {
                return _utilisateur;
            }

            set
            {
                _utilisateur = value;
            }
        }
        protected UtilisateurModel Utilisateur2
        {
            get
            {
                return _utilisateur2;
            }

            set
            {
                _utilisateur2 = value;
            }
        }
        protected UtilisateurModel Utilisateur3
        {
            get
            {
                return _utilisateur3;
            }

            set
            {
                _utilisateur3 = value;
            }
        }

        public RegisterFormBase()
        {
            _utilisateur = new UtilisateurModel();
            _utilisateur2 = new UtilisateurModel();
            _utilisateur3 = new UtilisateurModel();
        }
    
        protected void SubmitForm(EditContext ctx)
        {
            Status = "Formulaire Submit";
            // Post data to the server, etc
        }

        protected async Task SubmitValidForm(EditContext ctx)
        {
            if(ctx.Validate())
            {
                Status = "Formulaire ValidSubmit";
                // Post data to the server, etc
                using HttpResponseMessage response =   await Http.PostAsJsonAsync<UtilisateurModel>("/api/Users", Utilisateur2);
                UtilisateurModel article = await response.Content.ReadFromJsonAsync<UtilisateurModel>();
            }
            else
            {
                Status = "Erreur de validation";
            }
        }
            

        protected void SubmitInValidForm(EditContext ctx)
        {
            Status = "Formulaire InvalidSubmit";
            // Post data to the server, etc
        }



    }
}
