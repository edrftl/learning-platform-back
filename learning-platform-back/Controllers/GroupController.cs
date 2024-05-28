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
    public class GroupController : ControllerBase
    {
        private readonly PlatformDBContext context;
        //private readonly IMapper mapper;
        public GroupController(PlatformDBContext context)
        {
            this.context = context;
            //this.mapper = mapper;
        }
        [HttpGet("all")]
        public IActionResult Get()
        {
            var groups = context.Groups
                .Include(c => c.Course)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.MaxPlaces,
                    CourseName = c.Course.Name
                })
                .ToList();

            return Ok(groups);
        }

        //[HttpGet("all")]
        //public IActionResult Get()
        //{
        //    return Ok(context.Groups.ToList());
        //}

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = context.Groups.Find(id);
            if (entity == null) return NotFound(); // 404

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Groups model)
        {
            if (!ModelState.IsValid) return BadRequest();

            //var entity = mapper.Map<Course>(model);
            context.Groups.Add(model);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromForm] Groups model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = context.Groups.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);
            if (entity == null) return NotFound();

            context.Groups.Update(model);
            context.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = context.Groups.Find(id);
            if (entity == null) return NotFound();

            context.Groups.Remove(entity);
            context.SaveChanges();

            return Ok();
        }

        [HttpGet("courses")]
        public IActionResult GetCourse()
        {
            return Ok(context.Courses.ToList());
        }

    }
}
