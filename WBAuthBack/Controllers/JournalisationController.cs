using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;
using WBAuth.BLL.Manager;

namespace WBAuth.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalisationController : ControllerBase
    {
        private readonly IJournalisationManager _JournalisationManager;
        public JournalisationController(IJournalisationManager JournalisationManager)  { _JournalisationManager = JournalisationManager;  }


        //GET : api/Journalisation/List
        [HttpGet]
        [Route("List/{GuidUtilisateur}")]
        public async Task<IActionResult> ChargerListe(string GuidUtilisateur)
        {
            var oJournalisation = await _JournalisationManager.ChargerListe(GuidUtilisateur);
            if (oJournalisation == null)  return NoContent();
            return Ok(oJournalisation);
        }


        //GET : api/Journalisation/idJournalisation
        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<IActionResult> RechercheById(int Id)
        {
            var oJournalisation = await _JournalisationManager.RechercheById(Id);
            if (oJournalisation == null)  return NoContent();
            return Ok(oJournalisation);
        }


        //GET : api/Journalisation/idJournalisation
        [HttpGet]
        [Route("{rech}")]
        public async Task<IActionResult> Recherche(string rech)
        {
            var oJournalisation = await _JournalisationManager.Recherche(rech);
            if (oJournalisation == null) return NoContent();
            return Ok(oJournalisation);
        }


        //POST : api/Journalisation/EnregistrementJournalisations
        [HttpPost]
        [Route("EnregistrementJournalisations")]
        public async Task<IActionResult> EnregistrementJournalisations([FromBody] Journalisation oJournalisation)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if(oJournalisation.GuidUtilisateur == null) return NotFound("Guid de l'utilisateur est null'"); 
            var id = await _JournalisationManager.EnregistrementJournalisation(oJournalisation);
            if (id <= 0) return BadRequest($"Une erreur est survenue lors de la création de la Journalisation ");
            return Ok(id);
        }
        

        //DELETE : api/Journalisation/clear
        [HttpDelete]
        [Route("clear")]
        public async Task<IActionResult> Clear(string GuidUtilisateur)
        {
            if (GuidUtilisateur == null) { return BadRequest("Journalisation introuvable"); }
            var Journalisations = await _JournalisationManager.ChargerListe(GuidUtilisateur);
            if (Journalisations == null) return NotFound("Liste de journalisations introuvable'");
            var isdeleted = await _JournalisationManager.Clear(GuidUtilisateur);
            if (!isdeleted) return BadRequest($"Une erreur est survenue lors de la suppression de Journalisation.");
            return Ok(isdeleted);
        }



    }
}

