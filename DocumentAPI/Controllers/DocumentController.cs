using DocumentAPI.Commands;
using DocumentAPI.Dto;
using DocumentAPI.Filter;
using DocumentAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DocumentAPI.Controllers
{
    [Route("api/document")] 
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ISender _mediator;
        public DocumentController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var documents = await _mediator.Send(new GetDocumentsQuery(filter));
            return Ok(documents);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DocumentForEditDto model)
        {
            try
            {
                var command = new AddDocumentCommand(model);
                var response = await _mediator.Send(command);
                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDocument(Guid id) 
        {
            var document = await _mediator.Send(new GetDocumentByIdQuery(id));
            
            if (document == null)
                return NotFound();

            return Ok(document);
        }

        [HttpPost]
        [Route("{id}/publish")]
        public async Task<IActionResult> PublishDocument(Guid id) 
        {
            bool result = await _mediator.Send(new PublishDocumentCommand(id));
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> ModifyDocument([FromBody] DocumentForEditDto model, Guid id) 
        {
            bool result = await _mediator.Send(new ModifyDocumentCommand(model, id));
            if (!result)
                return BadRequest();
            return Ok();
        }
    }
}
