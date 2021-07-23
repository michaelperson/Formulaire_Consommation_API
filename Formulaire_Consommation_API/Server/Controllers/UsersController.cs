using Formulaire_Consommation_API.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulaire_Consommation_API.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IFakeDataContext ctx;

        public UsersController(IFakeDataContext DtCtx)
        {
            ctx = DtCtx;
        }
        [HttpGet]
        public IActionResult  Get()
        {
            try
            {
                return Ok(ctx.Utilisateurs);
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(UtilisateurModel um)
        {
            try
            {
                ctx.Utilisateurs.Add(um);
                return Ok(um);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public IActionResult Put(UtilisateurModel um)
        {
            try
            {
                UtilisateurModel mod = ctx.Utilisateurs.FirstOrDefault(m => m.Email == um.Email);
                mod.Password = um.Password;
                mod.Token = "";
                return Ok(um);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        [Route("/api/Users/Login")]
        [HttpPost]
        public IActionResult Login(UtilisateurModel um)
        {
            UtilisateurModel retour = ctx.AuthUser(um.Email, um.Password);
            if (retour == null) return NotFound(um);
             
            retour.Token = retour.Token??genToken();
            return Ok(retour);
                
        }

        /// <summary>
        /// FakeToken
        /// </summary>
        /// <returns></returns>
        private string genToken ()
        {
            string allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return   new string(
               Enumerable.Repeat(allChar, 58)
               .Select(token => token[random.Next(token.Length)]).ToArray());
            
        }
    }
}
