using KampusLearn.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KampusLearn.Services.Controllers
{
    [Route("api/[controller]")]// Routing 

    [ApiController] // This is an WEB Api controller 
    public class CoursesController : ControllerBase
    {
        private readonly KampusLearnDbContext repo;

        //ClassA obj= new ClassA();

        //This controller class depends on the KampusLearnDbContext class for CRUD functionality.
        // Bcoz of the above reason the KAMpusLearmDbContext is called as a Dependency .

        public CoursesController(KampusLearnDbContext repo)//Injecting the Dependency
        {
            this.repo = repo;

            //The .Net Core Framework bcoz of Dependency Injection it will take care of object creation and destruction of the object.
        }

       [HttpGet("GetCourse")]
        public IActionResult GetAllCourses()// From Database using EF Core 
        {
          //  throw new System.Exception();

            List<Course> courses = repo.Courses.ToList();
            if (courses.Count == 0)
            {
                return StatusCode(204, courses);
            }
            else
            {

                return StatusCode(200, courses);//Success Status code
            }

        }

        [HttpGet("GetCourseById/{courseId}")]//Route for passing a parameter in the route.
        //By default passing the data using the url 
        public IActionResult GetCourseById(int courseId)
        {
            List<Course> courses = repo.Courses.ToList();
         
            Course course = courses.Find(c => c.CourseId == courseId);

            if (course == null)
            {
                return StatusCode(404, "Course Id Not available");
            }
            else
            {
                return StatusCode(200, course);
            }
        }
        //CRUD - Create, Read,Update, Delete

        [HttpPost("AddNew")]//route 
     public IActionResult AddNewCourse([FromBody]Course course)
        {

            repo.Courses.Add(course);
            repo.SaveChanges();
            return Created("Course Added", course);
        }
        [HttpPost("NewCourse")]
        public IActionResult NewCourse(Course course)
        {
            repo.Courses.Add(course);
            repo.SaveChanges();
            return Created("Course Added", course);
        }

        [HttpDelete("Delete/{courseId}")]
        public IActionResult Delete(int courseId)
        {
            Course course = repo.Courses.Find(courseId);

            if (course == null)
            {
                return StatusCode(404, "Course Id Not available");
            }
            else
            {
                repo.Courses.Remove(course);
                repo.SaveChanges();
                return Ok();
            }

        }
    }
}








