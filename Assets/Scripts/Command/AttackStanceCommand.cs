using Command.Actions;

namespace Command.Main
{
    public class AttackStanceCommand : UnitCommand
    {
        private bool willHitTarget;
        public AttackStanceCommand(CommandData data)
        {
            this.commandData = data;
            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget()
        {
            return true;
        }
    }
}