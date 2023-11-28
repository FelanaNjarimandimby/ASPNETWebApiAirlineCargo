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
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MarchandiseController(IMarchandiseRepository marchandiseRepository, 
            INature_MarchandiseRepository nature_MarchandiseRepository,
            DataContext context,
            IMapper mapper)
        {
            _marchandiseRepository = marchandiseRepository;
            _nature_marchandiseRepository = nature_MarchandiseRepository;
            _context = context;
            _mapper = mapper;
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


        [HttpGet("rapportVP/{MarchandiseID}")]
        [ProducesResponseType(200, Type = typeof(double))]
        [ProducesResponseType(400)]

        public IActionResult GetRapportVolumePoids(int MarchandiseID)
        {
            if (!_marchandiseRepository.MarchandiseExists(MarchandiseID))
                return NotFound();

            var marchandise = _marchandiseRepository.GetRapportVolumePoids(MarchandiseID);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(marchandise);
        }

        [HttpGet("poidsTaxation/{MarchandiseID}")]
        [ProducesResponseType(200, Type = typeof(double))]
        [ProducesResponseType(400)]

        public IActionResult GetPoidsTaxation(int MarchandiseID)
        {
            if (!_marchandiseRepository.MarchandiseExists(MarchandiseID))
                return NotFound();

            var marchandise = _marchandiseRepository.GetPoidsTaxation(MarchandiseID);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(marchandise);
        }

        [HttpGet("tarifNature/{MarchandiseID}")]
        [ProducesResponseType(200, Type = typeof(double))]
        [ProducesResponseType(400)]

        public IActionResult GetTarifNature(int MarchandiseID)
        {
            
            if (!_marchandiseRepository.MarchandiseExists(MarchandiseID))
                return NotFound();

            var marchandise = _marchandiseRepository.GetTarifBase(MarchandiseID);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(marchandise);
        }

        [HttpGet("tarif/{MarchandiseID}")]
        [ProducesResponseType(200, Type = typeof(double))]
        [ProducesResponseType(400)]

        public IActionResult GetTarif(int MarchandiseID)
        {
            if (!_marchandiseRepository.MarchandiseExists(MarchandiseID))
                return NotFound();

            var marchandise = _marchandiseRepository.GetTarif(MarchandiseID);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(marchandise);
        }


        [HttpGet("total")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetTotal()
        {
             var marchandise = _marchandiseRepository.TarifTotal();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(marchandise);
        }

        [HttpGet("totalReserve")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetTotalReserve()
        {
            var marchandise = _marchandiseRepository.TarifReserve();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(marchandise);
        }

        [HttpGet("totalConfirme")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetTotalConfirme()
        {
            var marchandise = _marchandiseRepository.TarifConfirme();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(marchandise);
        }


        
        [HttpGet("marchandiseConfirme")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetMC(string etat)
        {
            var marchandise = _marchandiseRepository.GetMarchandiseByEtat(etat);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(marchandise);
        }


        
        [HttpPost("getID")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult GetID([FromBody] MarchandiseDto marchandiseCreate)
        {
           var marchandise = _marchandiseRepository.GetMarchandises().Where(
               m => m.MarchandiseDesignation == marchandiseCreate.MarchandiseDesignation
                && m.MarchandiseNombre == marchandiseCreate.MarchandiseNombre 
                && m.MarchandisePoids == marchandiseCreate.MarchandisePoids
                && m.MarchandiseVolume == marchandiseCreate.MarchandiseVolume
                && m.Nature_Marchandise.NatureMarchandiseLibelle == marchandiseCreate.NatureMarchandiseLibelle)
                .FirstOrDefault();
            
            if (marchandise == null)
                return BadRequest(ModelState);

            return Ok(marchandise.id);
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateMarchandise([FromBody] MarchandiseDto marchandiseCreate)
        {
            if(marchandiseCreate == null)
                return BadRequest(ModelState);

            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var marchandiseMap = _mapper.Map<Marchandise>(marchandiseCreate);

            marchandiseMap.Nature_Marchandise = _nature_marchandiseRepository.GetNature(marchandiseCreate.NatureMarchandiseLibelle);
            if (marchandiseMap.Nature_Marchandise == null)
            {
                ModelState.AddModelError("", "Nature de marchandise n'existe pas!");
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

            if(marchandiseID != marchandiseUpdate.id)
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

        [HttpDelete("{marchandiseID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteMarchandise(int marchandiseID)
        {
            try
            {
                //var marchandise = _context.Marchandises.Find(marchandiseID);
                var marchandise = _context.Marchandises.Where(m => m.id == marchandiseID).SingleOrDefault();

                if (marchandise is not null)
                {
                    _context.Marchandises.Remove(marchandise);

                    _context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");

            }

            return Ok("Marchandise supprimé avec succès");
        }

    }
}
