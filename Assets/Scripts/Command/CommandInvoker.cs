using System;
using System.Collections.Generic;

public class CommandInvoker
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    public void ProcessCommand(ICommand command) {
        ExecuteCommand(command);
        RegisterCommand(command);
    }

    private void ExecuteCommand(ICommand command) {
        command.Execute();
    }

    private void RegisterCommand(ICommand command) {
        commandHistory.Push(command);
    }
}