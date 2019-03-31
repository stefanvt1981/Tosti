using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TostiBackEnd.Repository;
using TostiBusinessEntities;

namespace TostiBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TostiController : ControllerBase
    {
        private ITostiRepository _repository;

        public TostiController(ITostiRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Tosti
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Tosti>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Tosti>>> Get()
        {
            try
            {                
                return Ok(await _repository.GetAllTostis());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Tosti/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(Tosti), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Tosti>> Get(int id)
        {
            try
            {
                return Ok(await _repository.GetTostiById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Tosti/GetByName/HamKaas
        [HttpGet("GetByName/{naam}", Name = "GetByName")]
        [ProducesResponseType(typeof(Tosti), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Tosti>> GetByName(string naam)
        {
            try
            {
                return Ok(await _repository.GetTostiByName(naam));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/Tosti
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(int id, [FromBody] Tosti tosti)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _repository.UpsertTosti(tosti);
                    return Ok();
                }
                catch(Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        // PUT: api/Tosti
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(int id, [FromBody] Tosti tosti)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpsertTosti(tosti);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        // DELETE: api/Tosti
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id, [FromBody] Tosti tosti)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.DeleteTosti(tosti);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
