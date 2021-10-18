using ClassLibraryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PesquisarCodigoPostal_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisarCodigoPostal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodigoPostalController : ControllerBase
    {

        private readonly PesquisarCodigoPostal_APIContext _context;

        public CodigoPostalController(PesquisarCodigoPostal_APIContext context)
        {
            _context = context;
        }

        [HttpGet("{query}")]
        public List<CodigoPostal> GetCodigoPostal(string query)
        {

            var result = from item in _context.CodigoPostal
                         where item.CodigoPostalString.Contains(query)
                         select item;



            return (List<CodigoPostal>)result.ToList();
        }
    }
}
