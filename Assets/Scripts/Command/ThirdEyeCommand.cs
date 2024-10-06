using Command.Actions;

namespace Command.Main
{
    public class ThirdEyeCommand : UnitCommand
    {
        private bool willHitTarget;
        public ThirdEyeCommand(CommandData data)
        {
            this.commandData = data;
            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget()
        {
            return true;
        }
    }
}
