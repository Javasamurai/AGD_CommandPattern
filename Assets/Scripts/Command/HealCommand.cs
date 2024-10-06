using Command.Actions;

namespace Command.Main
{
    public class HealCommand : UnitCommand
    {
        private bool willHitTarget;
        public HealCommand(CommandData data)
        {
            this.commandData = data;
            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.Heal).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget()
        {
            return true;
        }    
    }
}