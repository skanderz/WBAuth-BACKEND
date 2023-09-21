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
        [Route("List/{IdApplication}")]
        public async Task<IActionResult> ChargerAll(int IdApplication)
        {
            var ListFonction = await _FonctionManager.ChargerAll(IdApplication);
            if (ListFonction == null)  return NoContent();
            return Ok(ListFonction);
        }


        //GET : api/Fonction/idFonction
        [HttpGet]
        [Route("{Id}/{IdApplication}")]
        public async Task<IActionResult> ChargerFonction(int id, int IdApplication)
        {
            var oFonction = await _FonctionManager.Recherche(id ,IdApplication);
            if (oFonction == null)  return NoContent();
            return Ok(oFonction);
        }


        //POST : api/Fonction/ajouter
        [HttpPost]
        [Route("ajouter/{IdApplication}")]
        public async Task<IActionResult> Ajouter([FromBody] Fonction oFonction ,int IdApplication)
        {
            if (!ModelState.IsValid)  {  return BadRequest(ModelState);  }
            var id = await _FonctionManager.Ajouter(oFonction ,IdApplication);
            if (id <= 0)   return BadRequest($"Une erreur est survenue lors de la création de la fonction : {oFonction.Nom}.");
            return Ok(id);
        }


        //PUT : api/Fonction/modifier
        [HttpPut]
        [Route("modifier/{IdApplication}")]
        public async Task<IActionResult> Modifier([FromBody] Fonction oFonction, int IdApplication)
        {
            if (!ModelState.IsValid)  {   return BadRequest(ModelState);  }
            var fonction = await _FonctionManager.Recherche(oFonction.Id ,IdApplication);
            if (fonction == null)  return NotFound("Cet Fonction est introuvable'");
            var id = await _FonctionManager.Modifier(oFonction ,IdApplication);
            if (id <= 0)  return BadRequest($"Une erreur est survenue lors de la mise à jour de la Fonction : {oFonction.Nom}.");     
            return Ok(id);
        }


        //DELETE : api/Fonction/supprimer
        [HttpDelete]
        [Route("supprimer")]
        public async Task<IActionResult> Supprimer(int id, int IdApplication)
        {
            if (id <= 0) {   return BadRequest("Fonction introuvable");  }
            var Fonction = await _FonctionManager.Recherche(id, IdApplication);
            if (Fonction == null)  return NotFound("Fonction est introuvable'");
            var isdeleted = await _FonctionManager.Supprimer(id, IdApplication);
            if (!isdeleted)  return BadRequest($"Une erreur est survenue lors de la suppression de la Fonction: {Fonction.Nom}.");
            return Ok(isdeleted);
        }





    }
}

