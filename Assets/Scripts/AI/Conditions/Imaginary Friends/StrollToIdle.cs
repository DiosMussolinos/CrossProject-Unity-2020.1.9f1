using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Imaginary Friends/Stroll To Idle")]
public class StrollToIdle : Condition
{
    public override bool Validate(FSM entity)
    {

        if (entity.GetAgent().IsAtDestination())
        {
            return true;
        }

        return false;
             
    }

   
}
