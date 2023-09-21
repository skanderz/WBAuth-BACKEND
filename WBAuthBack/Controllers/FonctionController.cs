using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;

namespace WBAuthBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FonctionController : ControllerBase
    {
        private readonly IFonctionManager _FonctionManager;
        public FonctionController(IFonctionManager FonctionManager)  { _FonctionManager = FonctionManager;  }


        //GET : api/Fonction/List
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ChargerAll()
        {
            var oFonction = await _FonctionManager.ChargerAll();
            if (oFonction == null)  return NoContent();
            return Ok(oFonction);
        }


        //GET : api/Fonction/idFonction
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ChargerFonction(int id)
        {
            var oFonction = await _FonctionManager.Recherche(id);
            if (oFonction == null)  return NoContent();
            return Ok(oFonction);
        }


        //POST : api/Fonction/ajouter
        [HttpPost]
        [Route("ajouter")]
        public async Task<IActionResult> Ajouter([FromBody] Fonction oFonction)
        {
            if (!ModelState.IsValid)  {  return BadRequest(ModelState);  }
            var id = await _FonctionManager.Ajouter(oFonction);
            if (id <= 0)   return BadRequest($"Une erreur est survenue lors de la création de l'Fonction {oFonction.Nom}.");
            return Ok(id);
        }


        //PUT : api/Fonction/modifier
        [HttpPut]
        [Route("modifier")]
        public async Task<IActionResult> Modifier([FromBody] Fonction oFonction)
        {
            if (!ModelState.IsValid)  {   return BadRequest(ModelState);  }
            var ticketType = await _FonctionManager.Recherche(oFonction.Id);
            if (ticketType == null)  return NotFound("Cet Fonction est introuvable'");
            var id = await _FonctionManager.Modifier(oFonction);
            if (id <= 0)  return BadRequest($"Une erreur est survenue lors de la mise à jour de l'Fonction {oFonction.Nom}.");     
            return Ok(id);
        }


        //DELETE : api/Fonction/supprimer
        [HttpDelete]
        [Route("supprimer")]
        public async Task<IActionResult> Supprimer(int id)
        {
            if (id <= 0) {   return BadRequest("Fonction introuvable");  }
            var Fonction = await _FonctionManager.Recherche(id);
            if (Fonction == null)  return NotFound("Fonction est introuvable'");
            var isdeleted = await _FonctionManager.Supprimer(id);
            if (!isdeleted)  return BadRequest($"Une erreur est survenue lors de la suppression de Fonction.");
            return Ok(isdeleted);
        }





    }
}

