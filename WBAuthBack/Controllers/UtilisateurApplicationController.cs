using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;
using WBAuth.BLL.Manager;

namespace WBAuthBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurApplicationController : ControllerBase
    {
        private readonly IUtilisateurApplicationManager _UtilisateurApplicationManager;
        public UtilisateurApplicationController(IUtilisateurApplicationManager UtilisateurApplicationManager)  { _UtilisateurApplicationManager = UtilisateurApplicationManager;  }


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
        [Route("ListByApplication/{IdUtilisateur}")]
        public async Task<IActionResult> ChargerAllByUtilisateur(int IdUtilisateur)
        {
            var userlist = await _UtilisateurApplicationManager.ChargerAllByUtilisateur(IdUtilisateur);
            if (userlist == null) return NoContent();
            return Ok(userlist);
        }



        //GET : api/UtilisateurApplication/IdApplication/IdUtilisateur
        [HttpGet]
        [Route("{IdApplication}/{IdUtilisateur}")]
        public async Task<IActionResult> Recherche(int IdUtilisateur, int IdApplication)
        {
            var oUtilisateurApplication = await _UtilisateurApplicationManager.Recherche(IdUtilisateur , IdApplication);
            if (oUtilisateurApplication == null) return NoContent();
            return Ok(oUtilisateurApplication);
        }



        //PUT : api/UtilisateurApplication/modifier
        [HttpPut]
        [Route("modifierAccesRole")]
        public async Task<IActionResult> ModifierAccesRole(int IdUtilisateur, int IdApplication, bool Acces, string NomRole)
        {
            if (!ModelState.IsValid)  {   return BadRequest(ModelState);  }
            var oUtilisateurApplication = await _UtilisateurApplicationManager.Recherche(IdUtilisateur, IdApplication);
            if (oUtilisateurApplication == null)  return NotFound("Cet UtilisateurApplication est introuvable'");
            var id = await _UtilisateurApplicationManager.ModifierAccesRole(IdUtilisateur, IdApplication, Acces, NomRole);
            if (id <= 0)  return BadRequest($"Une erreur est survenue lors de la mise à jour de l'UtilisateurApplication {oUtilisateurApplication.Utilisateur.NomUtilisateur}.");     
            return Ok(id);
        }











    }
}

