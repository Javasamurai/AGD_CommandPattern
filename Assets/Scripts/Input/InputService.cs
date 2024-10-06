using Command.Main;
using Command.Player;
using Command.Actions;
using System;

namespace Command.Input
{
    public class InputService
    {
        private MouseInputHandler mouseInputHandler;

        private InputState currentState;
        private Actions.CommandType selectedActionType;
        private TargetType targetType;

        public InputService()
        {
            mouseInputHandler = new MouseInputHandler(this);
            SetInputState(InputState.INACTIVE);
            SubscribeToEvents();
        }

        public void SetInputState(InputState inputStateToSet) => currentState = inputStateToSet;

        private void SubscribeToEvents() => GameService.Instance.EventService.OnActionSelected.AddListener(OnActionSelected);

        public void UpdateInputService()
        {
            if(currentState == InputState.SELECTING_TARGET)
                mouseInputHandler.HandleTargetSelection(targetType);
        }

        public void OnActionSelected(Actions.CommandType selectedActionType)
        {
            this.selectedActionType = selectedActionType;
            SetInputState(InputState.SELECTING_TARGET);
            TargetType targetType = SetTargetType(selectedActionType);
            ShowTargetSelectionUI(targetType);
        }

        private void ShowTargetSelectionUI(TargetType selectedTargetType)
        {
            int playerID = GameService.Instance.PlayerService.ActivePlayerID;
            GameService.Instance.UIService.ShowTargetOverlay(playerID, selectedTargetType);
        }

        private TargetType SetTargetType(Actions.CommandType selectedActionType) => targetType = GameService.Instance.ActionService.GetTargetTypeForAction(selectedActionType);

        public void OnTargetSelected(UnitController targetUnit)
        {
            SetInputState(InputState.EXECUTING_INPUT);
            UnitCommand command = CreateUnitCommand(selectedActionType, targetUnit);
            GameService.Instance.ProcessUnitCommand(command);
        }

        private UnitCommand CreateUnitCommand(CommandType selectedActionType, UnitController targetUnit)
        {
            CommandData commandData = CreateUnitCommandData(targetUnit);
            switch(selectedActionType)
            {
                case CommandType.Attack:
                    return new AttackCommand(commandData);
                case CommandType.AttackStance:
                    return new AttackStanceCommand(commandData);
                case CommandType.Heal:
                    return new HealCommand(commandData);
                case CommandType.Cleanse:
                    return new CleanserCommand(commandData);
                case CommandType.ThirdEye:
                    return new ThirdEyeCommand(commandData);
                case CommandType.Meditate:
                    return new MeditateCommand(commandData);
                case CommandType.BerserkAttack:
                    return new BerserkCommand(commandData);
                
                default:
                    throw new ArgumentException("Invalid action type");
            }
        }

        private CommandData CreateUnitCommandData(UnitController targetUnit)
        {
            return new CommandData(GameService.Instance.PlayerService.ActivePlayerID, targetUnit.UnitID, GameService.Instance.PlayerService.ActivePlayerID, targetUnit.Owner.PlayerID);
        }
    }
}