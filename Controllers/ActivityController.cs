using LearningManagementSystemAPI.Models;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly ILogger<ActivityController> _logger;

        public ActivityController(IActivityService activityService, ILogger<ActivityController> logger)
        {
            _activityService = activityService;
            _logger = logger;
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<ActivityDto> Get([FromRoute] int id)
        {
            var activityDto = _activityService.Get(id);
            return Ok(activityDto);
        }     
        
        [HttpDelete("{id}")]
        public ActionResult DeleteActivity([FromRoute] int id)
        {
            _activityService.Delete(id);
            return NotFound();
        }
        
        [HttpPatch("{id}")]
        public ActionResult UpdateActivity([FromBody] CreateOrUpdateActivityDto activityDto, [FromRoute] int id)
        {
            _activityService.Update(activityDto, id);
            return Ok();
        }
    }
}
