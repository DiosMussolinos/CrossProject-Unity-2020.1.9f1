using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Also Edirlei's generic code:

[CreateAssetMenu(menuName = "Finite State Machine/State")]
public class State : ScriptableObject
{
    [SerializeField]
    private Action entryAction;

    [SerializeField]
    private Action[] stateActions;

    [SerializeField]
    private Action exitAction;

    [SerializeField]
    private Transition[] transitions;

    [SerializeField]
    private State previousState;

    public Action GetEntryAction()
    {
        return entryAction;
    }

    public Action GetExitAction()
    {
        return exitAction;
    }

    public Action[] GetActions()
    {
        return stateActions;
    }

    public Transition[] GetTransitions()
    {
        return transitions;
    }

    public State GetPreviousState()
    {
        return previousState;
    }

    public void SetPreviousState(State state)
    {
        previousState = state;
    }
}