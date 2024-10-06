using Command.Actions;

namespace Command.Main
{
    public class BerserkCommand : UnitCommand
    {
        private bool willHitTarget;
        public BerserkCommand(CommandData data)
        {
            this.commandData = data;
            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget()
        {
            return true;
        }
    }
}