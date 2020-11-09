using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIStateMachine : MonoBehaviour
{
    public enum Transition { PlayerRange, NoCooldownAvailable, OutsidePlayerRange }
    public enum StateType { Waiting, Attacking, Fleeing, Chasing }

    [SerializeField] State currentState;
    [SerializeField] StateType defaultState;
    [SerializeField] State[] states;

    [System.Serializable]
    public class State
    {
        public StateType stateType;
        public Transition conditionToEnter;
        public float conditionParameter;
        private MonsterAIState state;

        public void InitState()
        {
            switch (stateType)
            {
                case StateType.Waiting:
                    state = new WaitingAIState();
                    break;
                case StateType.Attacking:
                    state = new AttackingAIState();
                    break;
                case StateType.Fleeing:
                    state = new FleeingAIState();
                    break;
                case StateType.Chasing:
                    state = new ChasingAIState();
                    break;
                default:
                    break;
            }
        }

        public bool CanEnterState(Vector3 _position)
        {
            switch (conditionToEnter)
            {
                case Transition.PlayerRange:
                    return Vector3.Distance(state.PlayerRef.transform.position, _position) < conditionParameter;
                case Transition.NoCooldownAvailable:
                    return false;// TODO: condition cooldown
                case Transition.OutsidePlayerRange:
                    return Vector3.Distance(state.PlayerRef.transform.position, _position) > conditionParameter;
                default:
                    return false;
            }
        }

        public MonsterAIState GetState
        {
            get { return state; }
        }
    }

    private void Start()
    {
        TrashPlayer playerRef = FindObjectOfType<TrashPlayer>();
        foreach (var state in states)
        {
            state.InitState();
            state.GetState.DrivenEntity = transform.gameObject;
            state.GetState.PlayerRef = playerRef.gameObject;
        }

        // Initial state
        State defaultSt = states.ToList().Find(x => x.stateType == defaultState);
        if (defaultSt != null)
            currentState = defaultSt;
        else
            currentState = states[states.Length - 1];

        currentState.GetState.OnEnterState();
    }

    void Update()
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].CanEnterState(transform.position))
            {
                if (currentState == states[i])
                    break;

                currentState.GetState.OnExitState();
                currentState = states[i];
                currentState.GetState.OnEnterState();
                break;
            }
        }

        currentState.GetState.OnUpdateState();
    }

    private void OnDrawGizmos()
    {
        if (currentState != null && currentState.conditionToEnter == Transition.PlayerRange)
        {
            Gizmos.color = new Color(255, 0, 255, 0.5f);
            Gizmos.DrawSphere(transform.position, currentState.conditionParameter);
        }
    }
}
