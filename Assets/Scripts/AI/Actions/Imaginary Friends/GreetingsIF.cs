using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/GreetingsIF")]
public class GreetingsIF : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().hasSpoken = false;
    }
}
