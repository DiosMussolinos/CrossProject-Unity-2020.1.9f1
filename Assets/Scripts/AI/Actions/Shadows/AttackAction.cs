using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Attack")]
public class AttackAction : Action
{
    public override void Act(FSM entity)
    {

        if (entity.GetAgent().imaginaryFriend.ID == 3)
        {
            //Rabbit
            entity.GetAgent().imaginaryFriend.InitialChaseTimer = entity.GetAgent().imaginaryFriend.ChaseTimer;
            entity.GetAgent().imaginaryFriend.LastPlayerPosition = entity.GetAgent().player.transform.position;
            entity.GetAgent().SetDestinationTo(entity.GetAgent().player.transform.position);
            //entity.GetComponent<MeshRenderer>().enabled = true;
            entity.GetComponent<LightShadowRay>().meshActive = true;
            //entity.GetAgent().animalSFX.Play();
        }
        else
        {
            //Others
            entity.GetAgent().imaginaryFriend.InitialChaseTimer = entity.GetAgent().imaginaryFriend.ChaseTimer;
            entity.GetAgent().imaginaryFriend.LastPlayerPosition = entity.GetAgent().player.transform.position;
            entity.GetAgent().transform.position = entity.GetAgent().player.transform.position;
            //entity.GetComponent<MeshRenderer>().enabled = false;
            entity.GetComponent<LightShadowRay>().meshActive = false;
        }
    }
}
