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
    }
}
