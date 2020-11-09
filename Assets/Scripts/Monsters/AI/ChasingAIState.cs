using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingAIState : MonsterAIState
{
    NavMeshAgent agent;

    public override void OnEnterState()
    {
        if (agent == null)
            agent = DrivenEntity.GetComponent<NavMeshAgent>();
    }

    public override void OnUpdateState()
    {
        if (agent != null)
            agent.SetDestination(PlayerRef.transform.position);

    }

    public override void OnExitState()
    {

    }

    public override float GetStateTriggerRange()
    {
        return 0;
    }
}
