using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBAuth.BO;
using Microsoft.AspNetCore.Http;
using WBAuth.BLL.IManager;
using Microsoft.AspNetCore.Mvc;


namespace Clean_API_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationdaoController : ControllerBase
    {
        private readonly IApplicationManagerDAO _ApplicationManager;

        public ApplicationdaoController(IApplicationManagerDAO ApplicationManager) {   _ApplicationManager = ApplicationManager;   }

        //GET : api/Applicationdao/List
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ChargerAll()
        {
            var oApplication = await _ApplicationManager.ChargerAll();
            if (oApplication == null)  return NoContent();
            return Ok(oApplication);
        }


      

    }
}