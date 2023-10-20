using Microsoft.AspNetCore.Mvc;
using TurismoApi.Facades;
using TurismoApi.Interfaces;
using TurismoApi.Requests;
using TurismoApi.Responses;

namespace TurismoApi.Controllers;

//[ApiVersion("1.0")]
//[Route("api/v{version:apiVersion}/[controller]")] Add here versioning and packages, you can also add in the program.cs support for different formatters like XMl.
[ApiController]
[Route("api/[controller]")]
public class HubController : ControllerBase
{
    private readonly ILogger<HubController> _logger;
    private readonly IServiceFacade<HotelLegsFacade> _service;

    public HubController(ILogger<HubController> logger, IServiceFacade<HotelLegsFacade> service)
    {
        _logger = logger;
        _service = service;
    }

    
    [HttpPost(Name = "Search")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<HubResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<HubResponse>>> Search(HubRequest request)
    {
        try
        {

            var result = await SearchFromProviders(request); // For simplicity i will create the method here but ideally would be in some helper class.

            return Ok(new ApiResponse<HubResponse>
            {
                Success = true,
                Data = result,
                Error = null
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred.");
            return StatusCode(500, new ApiResponse<HubResponse>
            {
                Success = false,
                Data = null,
                Error = new ErrorResponse
                {
                    ErrorCode = 500,
                    ErrorMessage = "An unexpected error occurred."
                }
            });
        }
    }

    private async Task<HubResponse> SearchFromProviders(HubRequest request) 
    {
        // Start tasks concurrently
        var hotelLegstask = _service.Search(request);
        //var task2 = _service2.Search(request);

        // Wait for tasks to complete and get results
        await Task.WhenAll(hotelLegstask); // Add task2 if you want or more

        var hotelLegsResult = hotelLegstask.Result;

        // Wait for tasks to complete and get results

        // Here call some helper to merge all results in one.
        //var mergedResults = mergedResults(hotelLegsResult);

        var result = hotelLegsResult; // hotelLegsResult are supposed to be the merged results. 

        return result;
    }
}

