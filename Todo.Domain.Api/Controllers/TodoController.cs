using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("v1/todos")]
[Authorize]
public class TodoController : ControllerBase
{
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
            [FromServices]ITodoRepository todoRepository
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return todoRepository.GetAll(user);
    }

    [HttpGet("done")]
    public IEnumerable<TodoItem> GetAllDone(
            [FromServices]ITodoRepository todoRepository
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return todoRepository.GetAllDone(user);
    }

    [HttpGet("undone")]
    public IEnumerable<TodoItem> GetAllUndone(
            [FromServices]ITodoRepository todoRepository
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return todoRepository.GetAllUndone(user);
    }

    [HttpGet("done/today")]
    public IEnumerable<TodoItem> GetDoneForToday(
            [FromServices]ITodoRepository todoRepository
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return todoRepository.GetByPeriod(user, DateTime.Now.Date, true);
    }

    [HttpGet("undone/today")]
    public IEnumerable<TodoItem> GetUndoneForToday(
            [FromServices]ITodoRepository todoRepository
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return todoRepository.GetByPeriod(user, DateTime.Now.Date, false);
    }

    [HttpGet("done/tomorrow")]
    public IEnumerable<TodoItem> GetDoneForTomorrow(
            [FromServices]ITodoRepository todoRepository
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return todoRepository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
    }

    [HttpGet("undone/tomorrow")]
    public IEnumerable<TodoItem> GetUndoneForTomorrow(
            [FromServices]ITodoRepository todoRepository
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return todoRepository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false);
    }

    [HttpPost]
    public GenericCommandResult Create(
            [FromBody]CreateTodoCommand command,
            [FromServices]TodoHandler handler
        )
    {
        command.User = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return (GenericCommandResult)handler.Handle(command);
    }

    [HttpPut]
    public GenericCommandResult Update(
            [FromBody]UpdateTodoCommand command,
            [FromServices]TodoHandler handler
        )
    {
        command.User = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return (GenericCommandResult)handler.Handle(command);
    }

    [HttpPut("mark-as-done")]
    public GenericCommandResult MarkTodoAsDone(
            [FromBody]MarkTodoAsDoneCommand command,
            [FromServices]TodoHandler handler
        )
    {
        command.User = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return (GenericCommandResult)handler.Handle(command);
    }

    [HttpPut("mark-as-undone")]
    public GenericCommandResult MarkTodoAsUndone(
            [FromBody]MarkTodoAsUndoneCommand command,
            [FromServices]TodoHandler handler
        )
    {
        command.User = User.Claims.FirstOrDefault(x => x.Type == "user.id")?.Value;
        return (GenericCommandResult)handler.Handle(command);
    }
}