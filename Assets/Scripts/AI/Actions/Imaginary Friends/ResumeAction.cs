using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/Resume Agent")]
public class ResumeAction : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().ResumeAgent();
    }
}
