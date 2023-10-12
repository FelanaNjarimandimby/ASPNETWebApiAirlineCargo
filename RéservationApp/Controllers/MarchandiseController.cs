using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Models;
using RéservationApp.Repository;
using System.Text.RegularExpressions;

namespace RéservationApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class MarchandiseController : Controller
    {
        private readonly IMarchandiseRepository _marchandiseRepository;
        private readonly INature_MarchandiseRepository _nature_marchandiseRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public MarchandiseController(IMarchandiseRepository marchandiseRepository, 
            INature_MarchandiseRepository nature_MarchandiseRepository,
            IMapper mapper,
            DataContext context)
        {
            _marchandiseRepository = marchandiseRepository;
            _nature_marchandiseRepository = nature_MarchandiseRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Marchandise>))]
        public IActionResult GetMarchandises()
        {
            var marchandises = _mapper.Map<List<MarchandiseDto>>(_marchandiseRepository.GetMarchandises());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(marchandises);
        }

        [HttpGet("{marchandiseID}")]
        [ProducesResponseType(200, Type = typeof(Marchandise))]
        [ProducesResponseType(400)]

        public IActionResult GetMarchandise(int marchandiseID)
        {
            if (!_marchandiseRepository.MarchandiseExists(marchandiseID))
                return NotFound();

            var marchandise = _mapper.Map<MarchandiseDto>(_marchandiseRepository.GetMarchandise(marchandiseID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(marchandise);
        }

        [HttpGet("nature/{marchandiseID}")]
        [ProducesResponseType(200, Type = typeof(Marchandise))]
        [ProducesResponseType(400)]

        public IActionResult GetNatureByMarchandise(int marchandiseID)
        {
            var natures = _mapper.Map<List<Nature_MarchandiseDto>>(
                _marchandiseRepository.GetNatureByMarchandise(marchandiseID));

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(natures);
        }


        [HttpGet("rapportVP/{IDMarchandise}")]
        [ProducesResponseType(200, Type = typeof(double))]
        [ProducesResponseType(400)]

        public IActionResult GetRapportVolumePoids(int IDMarchandise)
        {
            if (!_marchandiseRepository.MarchandiseExists(IDMarchandise))
                return NotFound();

            var marchandise = _marchandiseRepository.GetRapportVolumePoids(IDMarchandise);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(marchandise);
        }

        [HttpGet("poidsTaxation/{IDMarchandise}")]
        [ProducesResponseType(200, Type = typeof(double))]
        [ProducesResponseType(400)]

        public IActionResult GetPoidsTaxation(int IDMarchandise)
        {
            if (!_marchandiseRepository.MarchandiseExists(IDMarchandise))
                return NotFound();

            var marchandise = _marchandiseRepository.GetPoidsTaxation(IDMarchandise);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(marchandise);
        }

        [HttpPost("getID")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult GetID([FromBody] MarchandiseDto marchandiseCreate)
        {
           var marchandise = _context.Marchandises.FirstOrDefault(m => m.Designation == marchandiseCreate.Designation 
                && m.NombreColis == marchandiseCreate.NombreColis && m.Poids == marchandiseCreate.Poids 
                && m.Dimension == marchandiseCreate.Dimension && m.Volume == marchandiseCreate.Volume 
                && m.Nature_Marchandise.Libelle == marchandiseCreate.Libelle);
            
            if (marchandise == null)
                return BadRequest(ModelState);

            return Ok(marchandise.IDMarchandise);
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateMarchandise([FromBody] MarchandiseDto marchandiseCreate)
        {
            if(marchandiseCreate == null)
                return BadRequest(ModelState);

            var marchandise = _marchandiseRepository.GetMarchandises()
                .Where(mar => mar.Designation.Trim().ToUpper() == marchandiseCreate.Designation.TrimEnd().ToUpper())
                .FirstOrDefault();

            if(marchandise != null)
            {
                ModelState.AddModelError("", "Marchandise existe déjà!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var marchandiseMap = _mapper.Map<Marchandise>(marchandiseCreate);


            marchandiseMap.Nature_Marchandise = _nature_marchandiseRepository.GetNature(marchandiseCreate.Libelle);
            if (marchandiseMap.Nature_Marchandise == null)
            {
                ModelState.AddModelError("", "Marchandise existe déjà!");
                return StatusCode(422, ModelState);
            }

            if (!_marchandiseRepository.CreateMarchandise(marchandiseMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Marchandise ajouté avec succès");
        }

        [HttpPut("{marchandiseID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateMarchandise(int marchandiseID, [FromBody] MarchandiseDto marchandiseUpdate)
        {
            if (marchandiseUpdate == null)
                return BadRequest(ModelState);

            if(marchandiseID != marchandiseUpdate.IDMarchandise)
                return BadRequest(ModelState);

            if (!_marchandiseRepository.MarchandiseExists(marchandiseID))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest();

            var marchandiseMap = _mapper.Map<Marchandise>(marchandiseUpdate);

            if(!_marchandiseRepository.UpdateMarchandise(marchandiseMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification de la marchandise avec succès");
        }

    }
}
