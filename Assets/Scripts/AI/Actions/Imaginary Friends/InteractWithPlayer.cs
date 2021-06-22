using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/Interact With Player")]
public class InteractWithPlayer : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().PauseAgent();
        entity.GetAgent().transform.LookAt(entity.GetAgent().player.transform.position);
        if(!entity.GetAgent().hasSpoken && Vector3.Distance(entity.transform.position, entity.GetAgent().player.transform.position) <= 7f)
        {
                entity.GetAgent().GetNarrations().TriggeredSpeech(entity.gameObject, 1);
                entity.GetAgent().hasSpoken = true;        
        }
        

    }
}
