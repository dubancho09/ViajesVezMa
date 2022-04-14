using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public LugaresController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lugares>>> GetLugares(){
            var Lugares = await _db.Lugar.ToListAsync();
            return Ok(Lugares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lugares>> GetLugar(int id){
            int Id = id;
            var Lugar = await _db.Lugar.FindAsync(Id);
            return Ok(Lugar);
        }
        
    }
}