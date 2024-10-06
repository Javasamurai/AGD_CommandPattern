using Command.Player;


namespace Command.Main
{
    public abstract class UnitCommand : ICommand
    {
        public CommandData commandData;
        protected int ActorUnitId { get; set; }
        protected int TargetUnitId { get; set; }
        public int ActorPlayerId { get; set; }
        public int TargetPlayerId { get; set; }

        protected UnitController actorUnit;
        protected UnitController targetUnit;

        public abstract void Execute();
        public abstract bool WillHitTarget();

        public void SetActorUnit(UnitController actor)
        {
            this.actorUnit = actor;
        }
        public void SetTargetUnit(UnitController target)
        {
            this.targetUnit = target;
        }
    }
}


public struct CommandData
{
    public int ActorUnitId;
    public int TargetUnitId;
    public int ActorPlayerId;
    public int TargetPlayerId;
    public CommandData(int actorUnitId, int targetUnitId, int actorPlayerId, int targetPlayerId)
    {
        ActorUnitId = actorUnitId;
        TargetUnitId = targetUnitId;
        ActorPlayerId = actorPlayerId;
        TargetPlayerId = targetPlayerId;
    }
}