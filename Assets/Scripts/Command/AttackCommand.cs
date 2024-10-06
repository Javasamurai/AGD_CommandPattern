using Command.Actions;

namespace Command.Main
{
    public class AttackCommand : UnitCommand
    {
        private bool willHitTarget;
        public AttackCommand(CommandData data)
        {
            this.commandData = data;
            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget()
        {
            return true;
        }   
    }
}