using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;

namespace WBAuthBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleManager _RoleManager;
        public RoleController(IRoleManager RoleManager)  { _RoleManager = RoleManager;  }


        //GET : api/Role/List
        [HttpGet]
        [Route("List/{IdApplication}")]
        public async Task<IActionResult> ChargerAll(int IdApplication)
        {
            var oRole = await _RoleManager.ChargerAll(IdApplication);
            if (oRole == null)  return NoContent();
            return Ok(oRole);
        }


        //GET : api/Role/idRole
        [HttpGet]
        [Route("{rech}/{IdApplication}")]
        public async Task<IActionResult> Recherche(string rech ,int IdApplication)
        {
            var oRole = await _RoleManager.Recherche(rech, IdApplication);
            if (oRole == null)  return NoContent();
            return Ok(oRole);
        }


        //GET : api/Role/idRole
        [HttpGet]
        [Route("Get/{id}/{IdApplication}")]
        public async Task<IActionResult> ChargerRoleById(int Id, int IdApplication)
        {
            var oRole = await _RoleManager.RechercheById(Id, IdApplication);
            if (oRole == null) return NoContent();
            return Ok(oRole);
        }


        //POST : api/Role/ajouter
        [HttpPost]
        [Route("ajouter")]
        public async Task<IActionResult> Ajouter([FromBody] Role oRole)
        {
            if (!ModelState.IsValid)  {  return BadRequest(ModelState);  }
            var id = await _RoleManager.Ajouter(oRole);
            if (id <= 0)   return BadRequest($"Une erreur est survenue lors de la création de l'Role {oRole.Nom}.");
            return Ok(id);
        }


        //PUT : api/Role/modifier
        [HttpPut]
        [Route("modifier")]
        public async Task<IActionResult> Modifier([FromBody] Role oRole)
        {
            if (!ModelState.IsValid)  {   return BadRequest(ModelState);  }
            var ticketType = await _RoleManager.RechercheById(oRole.Id, oRole.IdApplication);
            if (ticketType == null)  return NotFound("Cet Role est introuvable'");
            var id = await _RoleManager.Modifier(oRole);
            if (id <= 0)  return BadRequest($"Une erreur est survenue lors de la mise à jour de l'Role {oRole.Nom}.");     
            return Ok(id);
        }


        //DELETE : api/Role/supprimer
        [HttpDelete]
        [Route("supprimer")]
        public async Task<IActionResult> Supprimer(int id ,int IdApplication)
        {
            if (id <= 0) {   return BadRequest("Role introuvable");  }
            var Role = await _RoleManager.RechercheById(id ,IdApplication);
            if (Role == null)  return NotFound("Role est introuvable'");
            var isdeleted = await _RoleManager.Supprimer(id);
            if (!isdeleted)  return BadRequest($"Une erreur est survenue lors de la suppression de Role.");
            return Ok(isdeleted);
        }



    }
}

