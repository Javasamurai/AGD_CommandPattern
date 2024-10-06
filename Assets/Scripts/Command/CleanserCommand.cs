using Command.Actions;
using UnityEngine;

namespace Command.Main
{
    public class CleanserCommand : UnitCommand
    {
        private const float hitChance = 0.2f;

        private bool willHitTarget;
        public CleanserCommand(CommandData data)
        {
            this.commandData = data;
            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.Cleanse).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget()
        {
            return Random.Range(0f, 1f) < hitChance;
        }
    }
}