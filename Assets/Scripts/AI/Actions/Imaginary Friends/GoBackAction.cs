using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/Go Back")]
public class GoBackAction : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().GoBack();
    }
}
