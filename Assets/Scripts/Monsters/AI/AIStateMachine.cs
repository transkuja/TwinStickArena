using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    public enum Transition { PlayerRange, NoCooldownAvailable }
    public enum StateType { Waiting, Attacking, Fleeing, Chasing }

    MonsterAIState currentState;
    [SerializeField] State[] states;

    [System.Serializable]
    public class State
    {
        public StateType stateType;
        public Transition conditionToEnter;
        public float conditionParameter;
        private MonsterAIState state;

        State()
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

        public bool CanEnterState()
        {
            switch (conditionToEnter)
            {
                case Transition.PlayerRange:
                    return false; // TODO: condition range player
                case Transition.NoCooldownAvailable:
                    return false;// TODO: condition cooldown
                default:
                    return false;
            }
        }

        public MonsterAIState GetState
        {
            get { return state; }
        }
    }

    void Update()
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].CanEnterState() && currentState != states[i].GetState)
            {
                currentState = states[i].GetState;
                break;
            }
        }
    }
}
