using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;
using Action = WBAuth.BO.Action;


namespace WBAuthBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IActionManager _ActionManager;
        public ActionController(IActionManager ActionManager)  { _ActionManager = ActionManager;  }


        //GET : api/Action/List
        [HttpGet]
        [Route("List/{idJournalisation}")]
        public async Task<IActionResult> ChargerListe(int IdJournalisation)
        {
            var Actions = await _ActionManager.ChargerListe(IdJournalisation);
            if (Actions == null)  return NoContent();
            return Ok(Actions);
        }


        //GET : api/Action/idAction
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Recherche(int id)
        {
            var oAction = await _ActionManager.Recherche(rech);
            if (oAction == null)  return NoContent();
            return Ok(oAction);
        }



        //POST : api/Action/EnregistrementActions
        [HttpPost]
        [Route("EnregistrementActions")]
        public async Task<IActionResult> EnregistrementActions([FromBody] Action oAction)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var id = await _ActionManager.EnregistrementActions(oAction.IdJournalisation);
            if (id <= 0) return BadRequest($"Une erreur est survenue lors de la création de l'action a la date : {oAction.Date}.");
            return Ok(id);
        }



        //DELETE : api/Action/clear
        [HttpDelete]
        [Route("clear")]
        public async Task<IActionResult> Clear(int IdJournalisation)
        {
            if (IdJournalisation <= 0) {   return BadRequest("Action introuvable");  }
            var Actions = await _ActionManager.ChargerListe(IdJournalisation);
            if (Actions == null)  return NotFound("Liste d'actions introuvable'");
            var isdeleted = await _ActionManager.Clear(IdJournalisation);
            if (!isdeleted)  return BadRequest($"Une erreur est survenue lors de la suppression de Action.");
            return Ok(isdeleted);
        }



    }
}

