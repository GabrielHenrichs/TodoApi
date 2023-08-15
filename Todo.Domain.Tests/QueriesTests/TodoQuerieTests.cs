using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Domain.Tests.QueriesTests;

[TestClass]
public class TodoQuerieTests
{
    private List<TodoItem> _items;

    public TodoQuerieTests()
    {
        _items = new List<TodoItem>
        {
            new TodoItem("Tarefa 1", "usuarioA", DateTime.Now),
            new TodoItem("Tarefa 2", "usuarioA", DateTime.Now),
            new TodoItem("Tarefa 3", "usuarioB", DateTime.Now),
            new TodoItem("Tarefa 4", "usuarioA", DateTime.Now),
            new TodoItem("Tarefa 5", "usuarioB", DateTime.Now)
        };
    }

    [TestMethod]
    public void Deve_retornar_tarefas_apenas_de_determinado_usuario()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("usuarioB"));
        Assert.AreEqual(2, result.Count());
    }
}