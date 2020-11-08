using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterAIState
{
    protected GameObject drivenEntity;
    protected GameObject playerRef;

    public GameObject PlayerRef
    {
        get { return playerRef; }
        set { playerRef = value; }
    }

    public GameObject DrivenEntity
    {
        get { return drivenEntity; }
        set { drivenEntity = value; }
    }

    public abstract void OnEnterState();

    public abstract void OnUpdateState();

    public abstract void OnExitState();

    public abstract float GetStateTriggerRange();
}
