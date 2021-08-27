using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColourAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ColourContext _context; 
        public ValuesController(ColourContext context)
        {
           _context = context; 
        }
            [HttpGet]
            public ActionResult<IEnumerable<Colour>> GetColourItems()
            {
            return _context.Colours;
        }
    }
}
