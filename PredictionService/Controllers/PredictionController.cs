using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PredictionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly ApiService _apiService;

        public PredictionController()
        {
            _apiService = new ApiService("https://localhost:44369"); // Server API base address
        }

        // GET: api/Prediction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudySessionModel>>> Get()
        {
            var sessions = await _apiService.GetSessionsAsync();
            return Ok(sessions);
        }

        // GET: api/Prediction/Progress
        [HttpGet("/Progress")]
        public async Task<ActionResult<IEnumerable<ProgressModel>>> GetPregress()
        {
            var progresses = await _apiService.GetProgressesAsync();
            return Ok(progresses);
        }

    }
}
