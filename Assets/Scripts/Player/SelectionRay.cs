using UnityEngine;
using UnityEngine.UI;

public class SelectionRay : MonoBehaviour
{
    //Public
    //Text - Name of items
    public Text itemName;
    public GameObject textItemName;
    //Textures = Images
    public Texture handTexture;
    //Flowers
    public RawImage[] flowers;
    public int flowersCount = 0;
    //Distance
    public float distance = 5f;
    //Inventory Slot
    public Item itemColleted;

    private int flowersIndex;
    //GetImage & Script
    private RawImage ri;
    private ControlAndMovement control;
    //Tag to Change Image
    private string itemTag = "Item";
    private string frameTag = "Frame";
    private string flowerTag = "Flowers";

    public int GetFlowersCount()
    {
        return flowersCount;
    }

    private void Start()
    {
        //Script to get HeartBeats
        control = GetComponent<ControlAndMovement>();
        //Image
        ri = GetComponent<RawImage>();
        //textItemName.SetActive(false);


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
            //PICK ITEM
            //If Hit an Item and the radius of the Ray
            if ((Hit.transform.tag == itemTag) && (Vector3.Distance(transform.position, Hit.transform.position) < distance))
            {
                //Change Image to Hand
                textItemName.SetActive(true);
                itemName.text = Hit.collider.gameObject.name;

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
                textItemName.SetActive(false);
                itemName.text = null;
            }
            //PICK ITEM

            //PICK FLOWER
            if (Hit.transform.tag == flowerTag)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    int flowerID;
                    flowerID = Hit.transform.gameObject.GetComponent<FlowerData>().flowerData.ID;

                    flowersCount += 1;
                    Destroy(Hit.transform.gameObject);

                }
            }
            //PICK FLOWER

            //See FRAME
            if (Hit.transform.tag == frameTag)
            {
                //Debug.Log("Bateu");
                if (Hit.transform.gameObject.GetComponent<FramesData>().frameData.seen == false)
                {
                    //Debug.Log("afetou");
                    control.heartBeat += Hit.transform.gameObject.GetComponent<FramesData>().frameData.heartBeatValue;
                    Hit.transform.gameObject.GetComponent<FramesData>().frameData.seen = true;
                }
            }
            //See FRAME
        }
    }
}
