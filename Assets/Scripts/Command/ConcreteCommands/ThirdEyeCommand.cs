using Command.Main;

namespace Command.Commands
{
    public class ThirdEyeCommand : UnitCommand
    {
        private bool willHitTarget;

        public ThirdEyeCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            var damageToDeal = (int)(targetUnit.CurrentMaxHealth * 0.2f);
            targetUnit.TakeDamage(damageToDeal);
        }

        public override bool WillHitTarget() => true;
    } 
}
