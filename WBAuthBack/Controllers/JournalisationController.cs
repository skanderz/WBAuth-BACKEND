using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;

namespace WBAuthBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalisationController : ControllerBase
    {
        private readonly IJournalisationManager _JournalisationManager;
        public JournalisationController(IJournalisationManager JournalisationManager)  { _JournalisationManager = JournalisationManager;  }


        //GET : api/Journalisation/List
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ChargerAll()
        {
            var oJournalisation = await _JournalisationManager.ChargerAll();
            if (oJournalisation == null)  return NoContent();
            return Ok(oJournalisation);
        }


        //GET : api/Journalisation/idJournalisation
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ChargerJournalisation(int id)
        {
            var oJournalisation = await _JournalisationManager.Recherche(id);
            if (oJournalisation == null)  return NoContent();
            return Ok(oJournalisation);
        }


        //POST : api/Journalisation/ajouter
        [HttpPost]
        [Route("ajouter")]
        public async Task<IActionResult> Ajouter([FromBody] Journalisation oJournalisation)
        {
            if (!ModelState.IsValid)  {  return BadRequest(ModelState);  }
            var id = await _JournalisationManager.Ajouter(oJournalisation);
            if (id <= 0)   return BadRequest($"Une erreur est survenue lors de la création de l'Journalisation {oJournalisation.Nom}.");
            return Ok(id);
        }


        //PUT : api/Journalisation/modifier
        [HttpPut]
        [Route("modifier")]
        public async Task<IActionResult> Modifier([FromBody] Journalisation oJournalisation)
        {
            if (!ModelState.IsValid)  {   return BadRequest(ModelState);  }
            var ticketType = await _JournalisationManager.Recherche(oJournalisation.Id);
            if (ticketType == null)  return NotFound("Cet Journalisation est introuvable'");
            var id = await _JournalisationManager.Modifier(oJournalisation);
            if (id <= 0)  return BadRequest($"Une erreur est survenue lors de la mise à jour de l'Journalisation {oJournalisation.Nom}.");     
            return Ok(id);
        }


        //DELETE : api/Journalisation/supprimer
        [HttpDelete]
        [Route("supprimer")]
        public async Task<IActionResult> Supprimer(int id)
        {
            if (id <= 0) {   return BadRequest("Journalisation introuvable");  }
            var Journalisation = await _JournalisationManager.Recherche(id);
            if (Journalisation == null)  return NotFound("Journalisation est introuvable'");
            var isdeleted = await _JournalisationManager.Supprimer(id);
            if (!isdeleted)  return BadRequest($"Une erreur est survenue lors de la suppression de Journalisation.");
            return Ok(isdeleted);
        }



    }
}

