using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeAnimation : MonoBehaviour
{
    private RectTransform rt;
    private float angle = 0f;
    private float width = 212.5366f;
    private float height = 44.95f;
    public float sum = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        angle += sum;

        if (angle > 360)
        {
            angle = 0;
        }

        rt.sizeDelta = new Vector2(width + (Mathf.Sin(angle) * 10), height + (Mathf.Sin(angle) * 10.5f));
    }
}
