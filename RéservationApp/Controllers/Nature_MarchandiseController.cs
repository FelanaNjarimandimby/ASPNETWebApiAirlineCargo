using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Migrations;
using RéservationApp.Models;
using RéservationApp.Repository;

namespace RéservationApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class Nature_MarchandiseController : Controller
    {
        private readonly INature_MarchandiseRepository _nature_MarchandiseRepository;
        private readonly IMapper _mapper;
        private readonly ITypeTarifRepository _typeTarifRepository;
        private readonly DataContext _context;

        public Nature_MarchandiseController(INature_MarchandiseRepository nature_MarchandiseRepository, 
            IMapper mapper,
            ITypeTarifRepository typeTarifRepository,
            DataContext context )
        {
            _nature_MarchandiseRepository = nature_MarchandiseRepository;
            _mapper = mapper;
            _typeTarifRepository = typeTarifRepository;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Nature_Marchandise>))]

        public IActionResult GetNaure_Marchandises()
        {
            var nature_Marchandises = _mapper.Map<List<Nature_MarchandiseDto>>(_nature_MarchandiseRepository.GetNature_Marchandises());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(nature_Marchandises);
        }

        [HttpGet("marchandises/{marchandiseID}")]
        [ProducesResponseType(200, Type = typeof(Nature_Marchandise))]
        [ProducesResponseType(400)]

        public IActionResult GetNatureByMarchandise(int marchandiseID)
        {
            var nature = _mapper.Map<Nature_MarchandiseDto>(
                _nature_MarchandiseRepository.GetNature_MarchandiseByMarchandise(marchandiseID));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(nature);
        }

        [HttpGet("nature/{natureID}")]
        [ProducesResponseType(200, Type = typeof(Nature_Marchandise))]
        [ProducesResponseType(400)]

        public IActionResult GetNatureID(int natureID)
        {
            var nature = _mapper.Map<Nature_MarchandiseDto>(
                _nature_MarchandiseRepository.GetNature_Marchandise(natureID));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(nature);
        }


        [HttpGet("{natureID}/marchandises")]

        public IActionResult GetMarchandiseFromNature(int natureID)
        {
            if (!_nature_MarchandiseRepository.Nature_MarchandiseExists(natureID))
                return NotFound();

            var marchandises = _mapper.Map<List<MarchandiseDto>>(
                _nature_MarchandiseRepository.GetMarchandiseFromNature(natureID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(marchandises);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        
        public IActionResult CreateNature_Marchandise([FromBody] Nature_MarchandiseDto natureCreate)
        {
            if(natureCreate == null)
                return BadRequest(ModelState);

            var nature = _nature_MarchandiseRepository.GetNature_Marchandises()
                .Where(nat => nat.NatureMarchandiseLibelle.Trim().ToUpper() == natureCreate.NatureMarchandiseLibelle.TrimEnd().ToUpper())
                .FirstOrDefault();
            
            if (nature != null)
            {
                ModelState.AddModelError("", "Cette nature de marchandise existe déjà!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var natureMap = _mapper.Map<Nature_Marchandise>(natureCreate);

            natureMap.TypeTarif = _typeTarifRepository.GetTypeTarif(natureCreate.TarifLibelle);
            if (natureMap.TypeTarif == null)
            {
                ModelState.AddModelError("", "Ce type de tarif n'existe pas!");
                return StatusCode(422, ModelState);
            }

            if (!_nature_MarchandiseRepository.CreateNature_Marchandise(natureMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Nature de la marchandise ajoutée avec succès");
        }

        [HttpPut("{natureID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateNature_Marchandise(int natureID, [FromBody] Nature_MarchandiseDto natureUpdate)
        {
            if(natureUpdate == null)
                return BadRequest(ModelState);

            if(natureID != natureUpdate.id)
                return BadRequest(ModelState);

            if(!_nature_MarchandiseRepository.Nature_MarchandiseExists(natureID))
                return NotFound();
            
            if (!ModelState.IsValid) 
                return BadRequest();

 
            //var nature = _nature_MarchandiseRepository.GetNature_Marchandise(natureID);
            var nature = _context.Nature_Marchandises.Find(natureID);
            var typetarif = _typeTarifRepository.GetTypeTarif(natureUpdate.TarifLibelle);

            if (nature != null)
            {
                nature.NatureMarchandiseLibelle = natureUpdate.NatureMarchandiseLibelle;
                nature.TypeTarif = typetarif;

                _context.SaveChanges();

            };

            return Ok("Modification de la nature de la marchandise avec succès");
        }

        [HttpDelete("{natureID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteNature(int natureID)
        {
            if (!_nature_MarchandiseRepository.Nature_MarchandiseExists(natureID))
                return NotFound();

            var natureDelete = _nature_MarchandiseRepository.GetNature_Marchandise(natureID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_nature_MarchandiseRepository.DeleteNature_Marchandise(natureDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Nature supprimé avec succès");
        }

    }
}
