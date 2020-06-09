using System;
using System.Threading.Tasks;
using MegaNote.Services.Interfaces;
using MegaNote.Services.Interfaces.Models.Note;
using Microsoft.AspNetCore.Mvc;

namespace MegaNote.Controllers.v1
{
    
    [ApiController]
    [Route("api/v1/notes")]
    public class NotesController : ControllerBase
    {

        private readonly INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _noteService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDetails(Guid id)
        {
            var result = _noteService.GetDetails(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateNoteRequest request)
        {
            var id = await _noteService.Create(request);
            return Ok(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]UpdateNoteRequest request)
        {
            request.Id = id;
            await _noteService.Update(request);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _noteService.Delete(id);
            return Ok();
        }
    }
}
