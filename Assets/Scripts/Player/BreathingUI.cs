using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class BreathingUI : MonoBehaviour
{
    public ControlAndMovement player;
    private float speed;
    //public GameObject buttonPrefab;
    public List<GameObject> buttonPrefabs;
    public Transform buttonInstantiate;
    private List<GameObject> buttons;
    private GameObject newButton;
    public GameObject pointer;
    private float instantiateTimer;
    private int successNr;
    private float generalTimer;
    public CameraControl cam;
    private bool panelActive;

    void Start()
    {
        speed = 300f;
        buttons = new List<GameObject>();
        instantiateTimer = 0f;
        successNr = 0;
        generalTimer = 60f;
        
        // list of buttons

    }

    private void OnEnable()
    {
        panelActive = true;
        player.interacting = true;
    }

    void InstantiateButtons()
    {
        if (instantiateTimer <= 0)
        {
            int randIndex = UnityEngine.Random.Range(0, 2);
            newButton = Instantiate(buttonPrefabs[randIndex], buttonInstantiate.localPosition, Quaternion.identity);
            newButton.transform.SetParent(this.transform, false);
            buttons.Add(newButton);
            instantiateTimer = UnityEngine.Random.Range(0.5f, 2.7f);
            }
        instantiateTimer-= Time.deltaTime;
        // run random timer
        // instantiate a button
        // Add it to list
    }

    public bool IsUIActive()
    {
        return panelActive;
    }

    Rect GetWorldSpaceRect(RectTransform rct)
    {
        var r = rct.rect;
        r.center = rct.TransformPoint(r.center);
        r.size = rct.TransformVector(r.size);
        return r;
    }

    void RunButtons()
    {
        GameObject pressedBtn = null;
        foreach (GameObject button in buttons)
        {
            //Debug.Log(GetWorldSpaceRect(pointer.GetComponent<RectTransform>()).Overlaps(GetWorldSpaceRect(button.GetComponent<RectTransform>())));
            button.transform.Translate(Vector3.left * speed * Time.deltaTime);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(ButtonIntersects(button))
                {
                    
                    //Debug.Log(button);
                    successNr += 1;
                    pressedBtn = button;
                    button.GetComponent<Animator>().SetBool("Fade", true);

                }

                //disable button
            }

            if (successNr >= 5 || successNr <= -5)
            {
                GameObject.Destroy(button);
            }
        }

        if(pressedBtn == null && Input.GetKeyDown(KeyCode.E))
        {
            successNr -= 1;
        }
      

        if (pressedBtn != null)
        {
            buttons.Remove(pressedBtn);
            GameObject.Destroy(pressedBtn, 0.3f);
        }
    }

    public int GetSuccessNr()
    {
        return successNr;
    }

    void PlayerWins()
    {
        cam.RestoreCamera();
        ResetHeartbeat();
        buttons.Clear();
        successNr = 0;
        panelActive = false;
        gameObject.SetActive(false);
        
        // raise camera back
    }

    public void ResetHeartbeat()
    {
        int value = (int)player.heartBeat - 120;
        player.heartBeat -= value;
    }

    void EndGame()
    {
        buttons.Clear();
        successNr = 0;
        //GameObject.Destroy(gameObject);
        gameObject.SetActive(false);

        //death cutscene here
    }

    bool ButtonIntersects(GameObject currButton)
    {
        return (GetWorldSpaceRect(pointer.GetComponent<RectTransform>()).Overlaps(GetWorldSpaceRect(currButton.GetComponent<RectTransform>())));
    }


    void Update()
    {
        generalTimer -= Time.deltaTime;
        if(generalTimer > 0)
        {
            InstantiateButtons();
            RunButtons();
            cam.Invoke("BreathingEffect", 2.5f);
            //cam.BreathingEffect();
            if (successNr >= 5)
            {
                player.interacting = false;
                PlayerWins();
            }
            else if (successNr <= -5)
            {
                player.interacting = false;
                EndGame();
            }
        }
       
        
        //clickArea
    }
}

