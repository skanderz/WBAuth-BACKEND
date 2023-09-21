using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;

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
        [Route("List")]
        public async Task<IActionResult> ChargerAll()
        {
            var oUtilisateurApplication = await _UtilisateurApplicationManager.ChargerAll();
            if (oUtilisateurApplication == null)  return NoContent();
            return Ok(oUtilisateurApplication);
        }


        //GET : api/UtilisateurApplication/idUtilisateurApplication
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ChargerUtilisateurApplication(int id)
        {
            var oUtilisateurApplication = await _UtilisateurApplicationManager.Recherche(id);
            if (oUtilisateurApplication == null)  return NoContent();
            return Ok(oUtilisateurApplication);
        }


        //POST : api/UtilisateurApplication/ajouter
        [HttpPost]
        [Route("ajouter")]
        public async Task<IActionResult> Ajouter([FromBody] UtilisateurApplication oUtilisateurApplication)
        {
            if (!ModelState.IsValid)  {  return BadRequest(ModelState);  }
            var id = await _UtilisateurApplicationManager.Ajouter(oUtilisateurApplication);
            if (id <= 0)   return BadRequest($"Une erreur est survenue lors de la création de l'UtilisateurApplication {oUtilisateurApplication.Nom}.");
            return Ok(id);
        }


        //PUT : api/UtilisateurApplication/modifier
        [HttpPut]
        [Route("modifier")]
        public async Task<IActionResult> Modifier([FromBody] UtilisateurApplication oUtilisateurApplication)
        {
            if (!ModelState.IsValid)  {   return BadRequest(ModelState);  }
            var ticketType = await _UtilisateurApplicationManager.Recherche(oUtilisateurApplication.Id);
            if (ticketType == null)  return NotFound("Cet UtilisateurApplication est introuvable'");
            var id = await _UtilisateurApplicationManager.Modifier(oUtilisateurApplication);
            if (id <= 0)  return BadRequest($"Une erreur est survenue lors de la mise à jour de l'UtilisateurApplication {oUtilisateurApplication.Nom}.");     
            return Ok(id);
        }


        //DELETE : api/UtilisateurApplication/supprimer
        [HttpDelete]
        [Route("supprimer")]
        public async Task<IActionResult> Supprimer(int id)
        {
            if (id <= 0) {   return BadRequest("UtilisateurApplication introuvable");  }
            var UtilisateurApplication = await _UtilisateurApplicationManager.Recherche(id);
            if (UtilisateurApplication == null)  return NotFound("UtilisateurApplication est introuvable'");
            var isdeleted = await _UtilisateurApplicationManager.Supprimer(id);
            if (!isdeleted)  return BadRequest($"Une erreur est survenue lors de la suppression de UtilisateurApplication.");
            return Ok(isdeleted);
        }



    }
}

