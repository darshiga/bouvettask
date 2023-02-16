using Bouvet_Task.Data;
using Bouvet_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Bouvet_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly TaskAPIDbContext dbContext;

        public TasksController(TaskAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await dbContext.TaskDetails.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTaskDetail([FromRoute] Guid id)
        {
            var taskdetails = await dbContext.TaskDetails.FindAsync(id);

            if (taskdetails == null)
            {
                return NotFound();
            }

            return Ok(taskdetails);
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskDetail(AddTaskDetail addTaskDetail)
        {
            var taskdetails = new TaskDetails()
            {
                id = Guid.NewGuid(),
                ProjectName = addTaskDetail.ProjectName,
                ProjectDescription = addTaskDetail.ProjectDescription,
                ProjectManager = addTaskDetail.ProjectManager,
                TaskName = addTaskDetail.TaskName,
                TaskDescription = addTaskDetail.TaskDescription,
                EpicName = addTaskDetail.EpicName,
                EpicDescription = addTaskDetail.EpicDescription,
                EpicResponsibility = addTaskDetail.EpicResponsibility
            };

            await dbContext.TaskDetails.AddAsync(taskdetails);
            await dbContext.SaveChangesAsync();

            return Ok(taskdetails);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTaskDetails([FromRoute] Guid id, UpdateTaskDetail updateTaskDetail) 
        {
            var taskdetails = await dbContext.TaskDetails.FindAsync(id);

            if (taskdetails != null) 
            {
                taskdetails.ProjectName = updateTaskDetail.ProjectName;
                taskdetails.ProjectDescription = updateTaskDetail.ProjectDescription;
                taskdetails.ProjectManager = updateTaskDetail.ProjectManager;
                taskdetails.TaskName = updateTaskDetail.TaskName;
                taskdetails.TaskDescription = updateTaskDetail.TaskDescription;
                taskdetails.EpicName = updateTaskDetail.EpicName;
                taskdetails.EpicDescription = updateTaskDetail.EpicDescription;
                taskdetails.EpicResponsibility = updateTaskDetail.EpicResponsibility;

                await dbContext.SaveChangesAsync();

                return Ok(taskdetails);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTaskDetail([FromRoute] Guid id)
        {
            var taskdetails = await dbContext.TaskDetails.FindAsync(id);

            if (taskdetails != null)
            {
                dbContext.Remove(taskdetails);
                await dbContext.SaveChangesAsync();
                return Ok(taskdetails);
            }

            return NotFound();
        }

    }
}
