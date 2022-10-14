using AutoMapper;
using LearningManagementSystemAPI.Entities;
using LearningManagementSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;
        
        

        public CourseController(ICourseService courseService, ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _logger = logger;         
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetAll()
        {
            var coursesDto = _courseService.GetAll();
            return Ok(coursesDto);
        }
        [HttpGet("{id}")]
        public ActionResult<CourseDto> Get([FromRoute] int id)
        {
            var courseDto = _courseService.Get(id);

            if (courseDto == null)
                return NotFound();

            return Ok(courseDto);
        }

        [HttpPost]
        public ActionResult<CourseDto> CreateCourse([FromBody]CreateOrUpdateCourseDto courseDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = _courseService.Create(courseDto);

            return Created($"/api/course/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse([FromRoute] int id)
        {
            var isDeleted = _courseService.Delete(id);
            if (isDeleted)
                return NoContent();
            return NotFound();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateCourse([FromBody] CreateOrUpdateCourseDto courseDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var isUpdated = _courseService.Update(courseDto, id);
            if(!isUpdated)           
                return NotFound();

            return Ok();
        }
    }
}