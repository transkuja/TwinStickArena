using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterAIState
{
    public abstract void OnEnterState();

    public abstract void OnUpdateState();

    public abstract void OnExitState();

    public abstract float GetStateTriggerRange();
}
