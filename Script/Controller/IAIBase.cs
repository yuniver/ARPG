public interface IAIBase
{
    void Init();
    void Execute(ViewManagerBase viewManagerBase, EntityBase data);
    void Exit();
}