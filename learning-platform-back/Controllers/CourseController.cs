using AutoMapper;
using Data;
using Data.Entities;
using learning_platform_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learning_platform_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly PlatformDBContext context;
        //private readonly IMapper mapper;
        public CourseController(PlatformDBContext context)
        {
            this.context = context;
            //this.mapper = mapper;
        }
        [HttpGet("all")]
        public IActionResult Get()
        {
            var courses = context.Courses
                .Include(c => c.Category)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Description,
                    c.Price,
                    c.Discount,
                    c.ImageUrl,
                    CategoryName = c.Category.Name
                })
                .ToList();

            return Ok(courses);
        }

        //[HttpGet("all")]
        //public IActionResult Get()
        //{
        //    return Ok(context.Courses.ToList());
        //}

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = context.Courses.Find(id);
            if (entity == null) return NotFound(); // 404

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Course model)
        {
            if (!ModelState.IsValid) return BadRequest();

            //var entity = mapper.Map<Course>(model);
            context.Courses.Add(model);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromForm] Course model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = context.Courses.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);
            if (entity == null) return NotFound();

            context.Courses.Update(model);
            context.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = context.Courses.Find(id);
            if (entity == null) return NotFound();

            context.Courses.Remove(entity);
            context.SaveChanges();

            return Ok();
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            return Ok(context.Categories.ToList());
        }
        

    }
}
