using AutoMapper;
using LearningManagementSystemAPI.Entities;
using LearningManagementSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Controllers
{
    
    [Route("api/course")]
    //[ApiController] // check Modelstate for all request
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
            return Ok(courseDto);
        }

        [HttpPost]
        public ActionResult<CourseDto> CreateCourse([FromBody]CreateOrUpdateCourseDto courseDto)
        {
            var id = _courseService.Create(courseDto);
            return Created($"/api/course/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse([FromRoute] int id)
        {
            _courseService.Delete(id);
            return NotFound();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateCourse([FromBody] CreateOrUpdateCourseDto courseDto, [FromRoute] int id)
        {
            _courseService.Update(courseDto, id);          
            return Ok();
        }
    }
}