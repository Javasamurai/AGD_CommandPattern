using Command.Main;
using System.Collections.Generic;

namespace Command.Commands
{
    public class CommandInvoker
    {
        private Stack<ICommand> commandRegistry = new Stack<ICommand>();

        public void ProcessCommand(ICommand commandToProcess)
        {
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }

        public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();

        public void RegisterCommand(ICommand commandToRegister) => commandRegistry.Push(commandToRegister);

        public bool CommandBelongsToActivePlayer()
        {
            if (commandRegistry.Count > 0)
            {
                ICommand command = commandRegistry.Peek();
                return command.ActorUnit.Owner == GameService.Instance.PlayerService.ActivePlayerID;
            }
            return false;
        }

        private bool IsRegistryEmpty() => commandRegistry.Count == 0;
        public void Undo()
        {
            if (!IsRegistryEmpty())
            {
                ICommand commandToUndo = commandRegistry.Pop();
                commandToUndo.Undo();
            }
        }
    }
}