using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Action")]
public abstract class Action : ScriptableObject
{
    // abstract = something that can be overriden by children who inherit from this class, for example "PatrolAction : Action" script will be a child of this script
    public abstract void Act(FSM entity);
    
}
