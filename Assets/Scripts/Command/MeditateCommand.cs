using Command.Actions;

namespace Command.Main
{
    public class MeditateCommand : UnitCommand
    {
        private bool willHitTarget;
        public MeditateCommand(CommandData data)
        {
            this.commandData = data;
            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget()
        {
            return true;
        }
    }
}
