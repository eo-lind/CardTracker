using CardTracker.Models;
using CardTracker.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        // GET: api/<CardController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cardRepository.GetAll());
        }

        // GET api/<CardController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var card = _cardRepository.GetById(id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }

        // POST api/<CardController>
        [HttpPost]
        public IActionResult Post(Card card)
        {
            _cardRepository.Add(card);
            return CreatedAtAction("Get", new { id = card.Id }, card);
        }

        // PUT api/<CardController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }

            _cardRepository.Update(card);
            return NoContent();
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cardRepository.Delete(id);
            return NoContent();
        }
    }
}
