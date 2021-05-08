using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionRay : MonoBehaviour
{
    //Public
    //UI
    public RawImage Selector;
    //Tag to Change Image
    public string itemTag = "Item";
    //Textures = Images
    public Texture lampTexture;
    public Texture handTexture;
    //Distance
    public float distance = 5f;
    //Inventory Slot
    public Item itemColleted;

    //GetImage & Script
    private RawImage ri;
    private ControlAndMovement control;

    private void Start()
    {
        //Script to get HeartBeats
        control = GetComponent<ControlAndMovement>();
        //Image
        ri = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        //Create Ray
        Ray selectionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        /*I KNOW, A LOT OF IFS, BUT I DIDNT FOUND OTHER WAYS TO DO THAT*/

        //Create ray, if hits and the distance it travels
        if (Physics.Raycast(selectionRay, out Hit, distance))
        {
            //If Hit an Item and the radius of the Ray
            if ((Hit.transform.tag == itemTag) && (Vector3.Distance(transform.position, Hit.transform.position) < distance))
            {
                //Change Image to Hand
                Selector.texture = handTexture;

                //If Mouse0 Pressed
                if (Input.GetMouseButtonDown(0))
                {
                    //If Type != Pill
                    if(Hit.transform.gameObject.GetComponent<ItemData>().itemData.consumable == false)
                    {
                        //If item Null
                        if ((itemColleted == null))
                        {
                            //Change Item to new one
                            itemColleted = Hit.transform.gameObject.GetComponent<ItemData>().itemData;
                            //Destroy the one in the map
                            Destroy(Hit.transform.gameObject);

                        }
                        else
                        {
                            //if item not null
                            //Creates the old item in the world
                            Instantiate(itemColleted.prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Quaternion.identity);

                            //Update the Item the player has
                            itemColleted = Hit.transform.gameObject.GetComponent<ItemData>().itemData;
                            //Destroy the one in the map
                            Destroy(Hit.transform.gameObject);
                        }
                    }
                    else
                    {
                        //if itemType == Pills
                        //Get item info and calculate the heartBeats
                        control.heartBeat -= Hit.transform.gameObject.GetComponent<ItemData>().itemData.lessHeartBeat;
                        //Destroy the one in the map
                        Destroy(Hit.transform.gameObject);
                    }
                }
            }
            else
            {
                //Change to Lamp Image
                Selector.texture = lampTexture;
            }
        }

    }
}
