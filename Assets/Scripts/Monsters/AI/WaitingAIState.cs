using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaitingAIState : MonsterAIState
{
    NavMeshAgent agent;

    public override void OnEnterState()
    {
        if (agent == null)
            agent = DrivenEntity.GetComponent<NavMeshAgent>();

        if (agent != null)
            agent.isStopped = true;
    }

    public override void OnUpdateState()
    {

    }

    public override void OnExitState()
    {
        if (agent != null)
            agent.isStopped = false;
    }

    public override float GetStateTriggerRange()
    {
        return 0;
    }
}
