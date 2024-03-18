using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;
using WBAuth.BLL.Manager;
using Microsoft.Build.Logging;
using System;

namespace WBAuth.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurApplicationController : ControllerBase
    {
        private readonly IUtilisateurApplicationManager _UtilisateurApplicationManager;
        public UtilisateurApplicationController(IUtilisateurApplicationManager UtilisateurApplicationManager)  { _UtilisateurApplicationManager = UtilisateurApplicationManager;  }


        //POST : api/Utilisateur/ajouter
        [HttpPost]
        [Route("ajouter")]
        public async Task<IActionResult> Ajouter([FromBody] UtilisateurApplication oUA)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var id = await _UtilisateurApplicationManager.Ajouter(oUA);
            if (id <= 0) return BadRequest($"Une erreur est survenue lors de l'ajout de l'ApplicationUtilisateur");
            return Ok(id);
        }


        //GET : api/UtilisateurApplication/List
        [HttpGet]
        [Route("ListByApplication/{IdApplication}")]
        public async Task<IActionResult> ChargerAllByApplication(int IdApplication)
        {
            var userlist = await _UtilisateurApplicationManager.ChargerAllByApplication(IdApplication);
            if (userlist == null)  return NoContent();
            return Ok(userlist);
        }


        //GET : api/UtilisateurApplication/List
        [HttpGet]
        [Route("ListByUtilisateur/{GuidUtilisateur}")]
        public async Task<IActionResult> ChargerAllByUtilisateur(string GuidUtilisateur)
        {
            var userlist = await _UtilisateurApplicationManager.ChargerAllByUtilisateur(GuidUtilisateur);
            if (userlist == null) return NoContent();
            return Ok(userlist);
        }



        //GET : api/UtilisateurApplication/Id
        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<IActionResult> Recherche(int Id)
        {
            var oUtilisateurApplication = await _UtilisateurApplicationManager.Recherche(Id);
            if (oUtilisateurApplication == null) return NoContent();
            return Ok(oUtilisateurApplication);
        }



        //PUT : api/UtilisateurApplication/modifier
        [HttpPut]
        [Route("modifierAccesRole")]
        public async Task<IActionResult> ModifierAccesRole([FromBody] UtilisateurApplication oUA)
        {
            if (!ModelState.IsValid)  {   return BadRequest(ModelState);  }
            var oUtilisateurApplication = await _UtilisateurApplicationManager.Recherche(oUA.Id);
            if (oUtilisateurApplication == null) return NotFound("Cet UtilisateurApplication est introuvable'");
            var id = await _UtilisateurApplicationManager.ModifierAccesRole(oUA);
            if (id <= 0)  return BadRequest($"Une erreur est survenue lors de la mise à jour de l'UtilisateurApplication avec l'id : {oUtilisateurApplication.Id}.");     
            return Ok(id);
        }











    }
}

