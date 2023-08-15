using Todo.Domain.Commands;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class TodoItemTests
{
    private readonly TodoItem _todo = new("abc", "abcdef", DateTime.Now);
    [TestMethod]
    public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
    {
        Assert.AreEqual(_todo.Done, false);
    }
}