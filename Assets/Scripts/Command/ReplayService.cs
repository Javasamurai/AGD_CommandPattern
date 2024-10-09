using System.Collections;
using System.Collections.Generic;
using Command.Commands;
using Command.Main;

public class ReplayService {
    private Stack<ICommand> commandStack;

    public enum ReplayState
    {
        ACTIVE,
        INACTIVE
    }

    private ReplayState replayState;
    public ReplayService()
    {
        commandStack = new Stack<ICommand>();
        replayState = ReplayState.INACTIVE;
    }

    public void SetReplayState(ReplayState state) => replayState = state;
    public void SetCommandStack(Stack<ICommand> stack)
    {   
        commandStack = new Stack<ICommand>(stack);
    }
    public void ExecuteNextCommand()
    {
        if (commandStack.Count > 0)
        {
            GameService.Instance.ProcessUnitCommand(commandStack.Pop());
        }
    }
}