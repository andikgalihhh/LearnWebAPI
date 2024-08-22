using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Persistence.DatabaseContext;
using Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;
using Core.Features.Queries.AddTableSpecifications;
using Core.Features.Queries.UpdateTableSpesifications;
using Core.Features.Queries.DeleteTableSpecifications;

namespace Application.Controllers;

public class TableController : BaseController
{
    private readonly IMediator _mediator;

    public TableController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("v1/table/specification/{id}")]
    public async Task<GetTableSpecificationsResponse> GetTableSpecifications(Guid id)
    {
        var request = new GetTableSpecificationsQuery()
        {
            TableSpecificationId = id
        };
        var response = await _mediator.Send(request);
        return response;
    }

    [HttpPost("v1/table/specification/add")]
    public async Task<ActionResult<AddTableSpecificationsResponse>> AddTableSpecification([FromBody] AddTableSpecificationsQuery command)
    {
        var response = await _mediator.Send(command);

        if (response == null)
        {
            return BadRequest("Failed to add table specification.");
        }

        return CreatedAtAction(nameof(GetTableSpecifications), new { id = response.TableId }, response);
    }

    [HttpPost("v1/table/specification/update")]
    public async Task<ActionResult<UpdateTableSpecificationsResponse>> UpdateTableSpecification([FromBody] UpdateTableSpecificationsQuery command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("v1/table/specification/delete")]
    public async Task<ActionResult<DeleteTableSpecificationsResponse>> DeleteTableSpecification([FromBody] DeleteTableSpecificationsQuery command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }



}