public abstract class IUnitCommand : ICommand
{
    public int ActorUnitId { get; set; }
    public int TargetUnitId { get; set; }
    public int ActorPlayerId { get; set; }
    public int TargetPlayerId { get; set; }

    protected UnitController actor;
    protected UnitController target;

    public abstract void Execute();
    public abstract bool WillHitTarget();
}