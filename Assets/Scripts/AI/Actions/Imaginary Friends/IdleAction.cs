using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/IdleIF")]
public class IdleAction : Action
{
    public override void Act(FSM entity)
    {
        
         entity.GetAgent().timer -= Time.deltaTime;
         //Debug.Log(entity.GetAgent().timer);
        
    }

    

}
