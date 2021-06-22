using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
    //Identifiers
    public string ID;
    public string itemName;
    public bool consumable;

    public GameObject prefab;
    public Mesh item;
    //Values
    public int lessHeartBeat;
}
