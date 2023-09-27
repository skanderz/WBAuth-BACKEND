using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;

namespace WBAuthBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurManager _UtilisateurManager;
        public UtilisateurController(IUtilisateurManager UtilisateurManager)  { _UtilisateurManager = UtilisateurManager;  }


        //GET : api/Utilisateur/List
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ChargerAll()
        {
            var oUtilisateur = await _UtilisateurManager.ChargerAll();
            if (oUtilisateur == null)  return NoContent();
            return Ok(oUtilisateur);
        }


        //GET : api/Utilisateur/idUtilisateur
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> RechercheById(int id)
        {
            var oUtilisateur = await _UtilisateurManager.RechercheById(id);
            if (oUtilisateur == null)  return NoContent();
            return Ok(oUtilisateur);
        }


        //GET : api/Utilisateur/idUtilisateur
        [HttpGet]
        [Route("{rech}")]
        public async Task<IActionResult> Recherche(string rech)
        {
            var oUtilisateur = await _UtilisateurManager.Recherche(rech);
            if (oUtilisateur == null) return NoContent();
            return Ok(oUtilisateur);
        }




        //POST : api/Utilisateur/ajouter
        [HttpPost]
        [Route("ajouter")]
        public async Task<IActionResult> Ajouter([FromBody] Utilisateur oUtilisateur)
        {
            if (!ModelState.IsValid)  {  return BadRequest(ModelState);  }
            var id = await _UtilisateurManager.Ajouter(oUtilisateur);
            if (id <= 0)   return BadRequest($"Une erreur est survenue lors de la création de l'Utilisateur {oUtilisateur.NomUtilisateur}.");
            return Ok(id);
        }


        //PUT : api/Utilisateur/modifier
        [HttpPut]
        [Route("modifier")]
        public async Task<IActionResult> Modifier([FromBody] Utilisateur oUtilisateur)
        {
            if (!ModelState.IsValid)  {   return BadRequest(ModelState);  }
            var ticketType = await _UtilisateurManager.RechercheById(oUtilisateur.Id);
            if (ticketType == null)  return NotFound("Cet Utilisateur est introuvable'");
            var id = await _UtilisateurManager.Modifier(oUtilisateur);
            if (id <= 0)  return BadRequest($"Une erreur est survenue lors de la mise à jour de l'Utilisateur {oUtilisateur.NomUtilisateur}.");     
            return Ok(id);
        }


        //DELETE : api/Utilisateur/supprimer
        [HttpDelete]
        [Route("supprimer")]
        public async Task<IActionResult> Supprimer(int id)
        {
            if (id <= 0) {   return BadRequest("Utilisateur introuvable");  }
            var Utilisateur = await _UtilisateurManager.RechercheById(id);
            if (Utilisateur == null)  return NotFound("Utilisateur est introuvable'");
            var isdeleted = await _UtilisateurManager.Supprimer(id);
            if (!isdeleted)  return BadRequest($"Une erreur est survenue lors de la suppression de Utilisateur.");
            return Ok(isdeleted);
        }



    }
}

