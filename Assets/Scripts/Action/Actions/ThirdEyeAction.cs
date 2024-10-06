using Command.Input;
using Command.Main;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class ThirdEyeAction : IAction
    {
        private UnitController actorUnit;
        private UnitController targetUnit;
        public TargetType TargetType => TargetType.Self;
        private bool isSuccessful;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool isSuccessful)
        {
            this.actorUnit = actorUnit;
            this.targetUnit = targetUnit;
            this.isSuccessful = isSuccessful;

            actorUnit.PlayBattleAnimation(CommandType.ThirdEye, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            if (isSuccessful)
            {
                int healthToConvert = (int)(targetUnit.CurrentHealth * 0.25f);
                targetUnit.TakeDamage(healthToConvert);
                targetUnit.CurrentPower += healthToConvert;
            }
            else
                GameService.Instance.UIService.ActionMissed();
        }

        // public bool IsSuccessful() => true;

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}