using UnityEngine;

/// <summary>
/// 实现相关GameObject的动画表现
/// </summary>
public abstract class ViewManagerBase
{
    public virtual void Idle() { }
    public virtual void MoveTo(Vector3 destination) { }
    public virtual void Working() { }
    public virtual void Attack() { }
}