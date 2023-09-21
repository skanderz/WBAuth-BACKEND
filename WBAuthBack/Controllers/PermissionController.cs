using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;

namespace WBAuthBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionManager _PermissionManager;
        public PermissionController(IPermissionManager PermissionManager)  { _PermissionManager = PermissionManager;  }


        //GET : api/Permission/List
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ChargerAll()
        {
            var oPermission = await _PermissionManager.ChargerAll();
            if (oPermission == null)  return NoContent();
            return Ok(oPermission);
        }


        //GET : api/Permission/idPermission
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ChargerPermission(int id)
        {
            var oPermission = await _PermissionManager.Recherche(id);
            if (oPermission == null)  return NoContent();
            return Ok(oPermission);
        }


        //POST : api/Permission/ajouter
        [HttpPost]
        [Route("ajouter")]
        public async Task<IActionResult> Ajouter([FromBody] Permission oPermission)
        {
            if (!ModelState.IsValid)  {  return BadRequest(ModelState);  }
            var id = await _PermissionManager.Ajouter(oPermission);
            if (id <= 0)   return BadRequest($"Une erreur est survenue lors de la création de l'Permission {oPermission.Nom}.");
            return Ok(id);
        }


        //PUT : api/Permission/modifier
        [HttpPut]
        [Route("modifier")]
        public async Task<IActionResult> Modifier([FromBody] Permission oPermission)
        {
            if (!ModelState.IsValid)  {   return BadRequest(ModelState);  }
            var ticketType = await _PermissionManager.Recherche(oPermission.Id);
            if (ticketType == null)  return NotFound("Cet Permission est introuvable'");
            var id = await _PermissionManager.Modifier(oPermission);
            if (id <= 0)  return BadRequest($"Une erreur est survenue lors de la mise à jour de l'Permission {oPermission.Nom}.");     
            return Ok(id);
        }


        //DELETE : api/Permission/supprimer
        [HttpDelete]
        [Route("supprimer")]
        public async Task<IActionResult> Supprimer(int id)
        {
            if (id <= 0) {   return BadRequest("Permission introuvable");  }
            var Permission = await _PermissionManager.Recherche(id);
            if (Permission == null)  return NotFound("Permission est introuvable'");
            var isdeleted = await _PermissionManager.Supprimer(id);
            if (!isdeleted)  return BadRequest($"Une erreur est survenue lors de la suppression de Permission.");
            return Ok(isdeleted);
        }



    }
}

