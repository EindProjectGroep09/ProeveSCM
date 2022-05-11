using UnityEngine;

public abstract class SequenceBaseState {
    public abstract void EnterState(SequenceStateManager enemy);

    public abstract void UpdateState(SequenceStateManager enemy);

    public abstract void CollisionEnter(SequenceStateManager enemy, Collision collision);
}