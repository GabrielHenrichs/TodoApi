using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class UpdateTodoCommand : Notifiable<Notification>, ICommand
{
    public UpdateTodoCommand() { }

    public UpdateTodoCommand(Guid id, string user, string title)
    {
        Id = id;
        User = user;
        Title = title;
    }

    public Guid Id { get; set; }
    public string User { get; set; }
    public string Title { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<UpdateTodoCommand>()
            .Requires()
            .IsLowerThan(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
            .IsLowerThan(User, 6, "User", "Usuário inválido"));
    }
}