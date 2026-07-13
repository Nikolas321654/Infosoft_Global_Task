using Breeders.Application.DTOs;
using Breeders.Application.Interfaces;
using Breeders.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Breeders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LittersController(ILitterService litterService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<LitterDto>>> GetLitters(
        [FromHeader(Name = "X-Breeder-Id")] Guid breederId,
        [FromQuery] LitterStatus? status,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;
        if (pageSize > 100) pageSize = 100;

        var result = await litterService.GetLittersAsync(
            breederId,
            status,
            pageNumber,
            pageSize,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("{litterId:guid}/publish")]
    public async Task<IActionResult> PublishLitter(
        [FromRoute] Guid litterId,
        [FromHeader(Name = "X-Breeder-Id")] Guid breederId,
        CancellationToken cancellationToken = default)
    {
        await litterService.PublishLitterAsync(litterId, breederId, cancellationToken);

        return Ok(new { message = "Litter published successfully." });
    }
}