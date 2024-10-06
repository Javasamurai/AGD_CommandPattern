using System;
using Command.Actions;
using UnityEngine;

namespace Command.Main
{
    public class BerserkCommand : UnitCommand
    {
        private const float hitChance = 0.66f;

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
            return UnityEngine.Random.Range(0f, 1f) < hitChance;
        }
    }
}