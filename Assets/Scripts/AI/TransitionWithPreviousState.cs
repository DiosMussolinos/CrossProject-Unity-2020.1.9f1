using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Transition With Previous State")]
public class TransitionWithPreviousState : Transition
{
    public override bool IsTriggered(FSM entity)
    {
        targetState = entity.currentState.GetPreviousState();
        return decision.Validate(entity); // IsTriggered receives the agent to which the FSM code is attached (entity) and validates its condition to see if it's true or false to proceed to next state
    }
}
