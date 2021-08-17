using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverPause : MonoBehaviour
{
    public PauseMenu pause;
    public int buttonID;
    private RectTransform rect;
    private Vector2 mousePos;
    private Vector2 ImageXY;
    private Vector2 ImageWL;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        ImageXY = new Vector2(rect.position.x, rect.position.y);
        ImageWL = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (pause.isPaused && mousePos.x > ImageXY.x - 140 && mousePos.x < ImageXY.x + 20 + ImageWL.x && mousePos.y > ImageXY.y - 50 && mousePos.y < ImageXY.y + ImageWL.y + 10)
        {
            pause.options = buttonID;
        }
    }
}
