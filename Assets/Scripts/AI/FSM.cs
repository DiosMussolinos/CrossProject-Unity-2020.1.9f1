using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public State initialState;
    public State currentState;
    private NavMesh navMeshAgent;

    // Code taken from Edirlei:

    void Start()
    {
        currentState = initialState;
        navMeshAgent = GetComponent<NavMesh>();
    }

    public NavMesh GetAgent()
    {
        return navMeshAgent;
    }

    void DoActions(List<Action> actions)
    {
        foreach (Action a in actions)
        {
            if (a != null)
            {
                a.Act(this); //Important function: execute an action by an agent to which this script is attached
            }
        }
    }

    void Update()
    {
        Transition triggeredTransition = null;
        foreach (Transition t in currentState.GetTransitions())
        {
            if (t.IsTriggered(this))
            {
                triggeredTransition = t;
                break;
            }
        }

        List<Action> actions = new List<Action>();

        if (triggeredTransition) // if the condition for next state is true / if triggeredTransition exists
        {
            State targetState = triggeredTransition.GetTargetState(); // Simply read the next state
            actions.Add(currentState.GetExitAction()); // 3rd on list: We can remove it later, but I want to see if exit action will be useful for us
            actions.Add(triggeredTransition.GetAction()); // 2nd on list: The action that the agent will do during the state
            actions.Add(targetState.GetEntryAction()); // 1st on list: Entry action will act to nullify the previous activity if we put here the "StopAgent" act  
            targetState.SetPreviousState(currentState);
            currentState = targetState;
        }

        else // else just keep doing ur stuff during the current state
        {
            foreach (Action a in currentState.GetActions())
            {
                actions.Add(a);

            }
        }


        DoActions(actions);
    }
}
