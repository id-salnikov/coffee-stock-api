using Coffee.StockApi.Infrastructure.Commands.CreateStockItem;
using CoffeeStockApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.StockApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CoffeeController : Controller
{
    private readonly IMediator _mediator;
    public CoffeeController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetItems(CancellationToken token) {
        return Ok("StockItem");
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateCoffee(StockItemPostViewModel _postViewModel) {
        var createStockItemCommand = new CreateStockItemCommand {
            Sku = _postViewModel.Sku,
            MinimalQuantity = _postViewModel.MinimalQuantity,
            Name = _postViewModel.Name,
            StockItemType = _postViewModel.StockItemType,
            Volume = _postViewModel.Volume,
            Quantity = _postViewModel.Quantity,
        };
        var result = await _mediator.Send(createStockItemCommand);
        return Ok(result);
    }
}