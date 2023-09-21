using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;
using WBAuth.BLL.Manager;

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
        [Route("List/{IdUtilisateur}")]
        public async Task<IActionResult> ChargerListe(int IdUtilisateur)
        {
            var oJournalisation = await _JournalisationManager.ChargerListe(IdUtilisateur);
            if (oJournalisation == null)  return NoContent();
            return Ok(oJournalisation);
        }


        //GET : api/Journalisation/idJournalisation
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> Recherche(int Id)
        {
            var oJournalisation = await _JournalisationManager.Recherche(Id);
            if (oJournalisation == null)  return NoContent();
            return Ok(oJournalisation);
        }



        //POST : api/Journalisation/EnregistrementJournalisations
        [HttpPost]
        [Route("EnregistrementJournalisations")]
        public async Task<IActionResult> EnregistrementJournalisations([FromBody] Journalisation oJournalisation)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var id = await _JournalisationManager.EnregistrementJournalisation(oJournalisation.IdUtilisateur);
            if (id <= 0) return BadRequest($"Une erreur est survenue lors de la création de la Journalisation a la date : {oJournalisation.DateConnexion}.");
            return Ok(id);
        }



        //DELETE : api/Journalisation/clear
        [HttpDelete]
        [Route("clear")]
        public async Task<IActionResult> Clear(int IdUtilisateur)
        {
            if (IdUtilisateur <= 0) { return BadRequest("Journalisation introuvable"); }
            var Journalisations = await _JournalisationManager.ChargerListe(IdUtilisateur);
            if (Journalisations == null) return NotFound("Liste de journalisations introuvable'");
            var isdeleted = await _JournalisationManager.Clear(IdUtilisateur);
            if (!isdeleted) return BadRequest($"Une erreur est survenue lors de la suppression de Journalisation.");
            return Ok(isdeleted);
        }



    }
}

