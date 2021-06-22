using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Frames Or Marks", fileName = "NewFrame Or Mark")]
public class Frames : ScriptableObject
{
    public int ID;
    public string ObjectName;
    public bool seen;
    public int heartBeatValue;
}
