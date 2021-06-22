using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Imaginary Friends/Sees Player")]
public class IFSeesPlayer : Condition
{
    [SerializeField]
    public bool sawPlayer;
    public override bool Validate(FSM entity)
    {
        if(Vector3.Distance(entity.GetAgent().transform.position, entity.GetAgent().player.transform.position) <= entity.GetAgent().imaginaryFriend.VisionRange)
        {
            return sawPlayer;
        }
        else
        {
            return !sawPlayer;
        }
    }
}
