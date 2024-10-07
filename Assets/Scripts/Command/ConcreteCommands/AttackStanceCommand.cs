using Command.Main;

namespace Command.Commands
{
    public class AttackStanceCommand : UnitCommand
    {
        private bool willHitTarget;

        public AttackStanceCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            if (willHitTarget)
            {
                actorUnit.RestoreHealth((int) (targetUnit.CurrentPower * 0.2f));
                actorUnit.Owner.ResetCurrentActivePlayer();
            }
        }

        public override bool WillHitTarget() => true;
    }
}
