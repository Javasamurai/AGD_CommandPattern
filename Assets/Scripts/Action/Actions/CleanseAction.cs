using Command.Input;
using Command.Player;
using Command.Main;
using UnityEngine;

namespace Command.Actions
{
    public class CleanseAction : IAction
    {
        private UnitController actorUnit;
        private UnitController targetUnit;
        public TargetType TargetType  => TargetType.Enemy;
        private bool isSuccessful;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool isSuccessful)
        {
            this.actorUnit = actorUnit;
            this.targetUnit = targetUnit;
            this.isSuccessful = isSuccessful;

            actorUnit.PlayBattleAnimation(CommandType.Cleanse, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.CLEANSE);

            if (isSuccessful)
                targetUnit.ResetStats();
            else
                GameService.Instance.UIService.ActionMissed();
        }

        // public bool IsSuccessful() => Random.Range(0f, 1f) < hitChance;

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}
