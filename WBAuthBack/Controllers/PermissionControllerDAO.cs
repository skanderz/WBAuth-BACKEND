using System.Threading.Tasks;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;

namespace WBAuth.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionControllerDAO : ControllerBase
    {
        private readonly IPermissionManagerDAO _PermissionManagerDAO;
        public PermissionControllerDAO(IPermissionManagerDAO PermissionManagerDAO)  { _PermissionManagerDAO = PermissionManagerDAO;  }


        [HttpGet]
        [Route("RechercheMultiFonction/{rech}/{IdApplication}/{IdRole}")]
        public async Task<IActionResult> RechercheMultiFonction(string rech, int IdApplication, int IdRole)
        {
            var oPermission = await _PermissionManagerDAO.RechercheMultiFonction(rech, IdApplication, IdRole);
            if (oPermission == null) return NoContent();
            return Ok(oPermission);
        }

        [HttpGet]
        [Route("RechercheFonctionUnique/{rech}/{IdApplication}/{IdRole}")]
        public async Task<IActionResult> RechercheFonctionUnique(string rech, int IdApplication, int IdRole)
        {
            var oPermission = await _PermissionManagerDAO.RechercheFonctionUnique(rech, IdApplication, IdRole);
            if (oPermission == null) return NoContent();
            return Ok(oPermission);
        }




    }
}

