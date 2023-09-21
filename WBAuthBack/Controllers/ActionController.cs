using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;

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
        [Route("List")]
        public async Task<IActionResult> ChargerAll()
        {
            var oAction = await _ActionManager.ChargerAll();
            if (oAction == null)  return NoContent();
            return Ok(oAction);
        }


        //GET : api/Action/idAction
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ChargerAction(int id)
        {
            var oAction = await _ActionManager.Recherche(id);
            if (oAction == null)  return NoContent();
            return Ok(oAction);
        }


        //POST : api/Action/ajouter
        [HttpPost]
        [Route("ajouter")]
        public async Task<IActionResult> Ajouter([FromBody] Action oAction)
        {
            if (!ModelState.IsValid)  {  return BadRequest(ModelState);  }
            var id = await _ActionManager.Ajouter(oAction);
            if (id <= 0)   return BadRequest($"Une erreur est survenue lors de la création de l'Action {oAction.Nom}.");
            return Ok(id);
        }


        //PUT : api/Action/modifier
        [HttpPut]
        [Route("modifier")]
        public async Task<IActionResult> Modifier([FromBody] Action oAction)
        {
            if (!ModelState.IsValid)  {   return BadRequest(ModelState);  }
            var ticketType = await _ActionManager.Recherche(oAction.Id);
            if (ticketType == null)  return NotFound("Cet Action est introuvable'");
            var id = await _ActionManager.Modifier(oAction);
            if (id <= 0)  return BadRequest($"Une erreur est survenue lors de la mise à jour de l'Action {oAction.Nom}.");     
            return Ok(id);
        }


        //DELETE : api/Action/supprimer
        [HttpDelete]
        [Route("supprimer")]
        public async Task<IActionResult> Supprimer(int id)
        {
            if (id <= 0) {   return BadRequest("Action introuvable");  }
            var Action = await _ActionManager.Recherche(id);
            if (Action == null)  return NotFound("Action est introuvable'");
            var isdeleted = await _ActionManager.Supprimer(id);
            if (!isdeleted)  return BadRequest($"Une erreur est survenue lors de la suppression de Action.");
            return Ok(isdeleted);
        }



    }
}

