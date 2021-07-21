using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCandlesAnimations : MonoBehaviour
{
    private Light candles;
    private int index = 0;
    private int animationSum;
    
    private float[] animationLight = {9f, 9.05f, 9.1f, 9.15f, 9.2f, 9.25f, 9.3f, 9.35f, 9.4f, 9.45f, 9.5f, 9.55f, 9.6f, 9.65f,
                                 9.7f, 9.75f, 9.8f, 9.85f, 9.9f, 10f, 10.05f, 10.1f, 10.15f, 10.2f, 10.25f, 10.3f, 10.35f,
                                  10.4f, 10.45f, 10.5f, 10.55f, 10.6f, 10.65f, 10.7f, 10.75f, 10.8f, 10.85f, 10.9f, 10.95f,
                                   11f, 11.05f, 11.1f, 11.15f, 11.2f, 11.25f, 11.3f, 11.35f, 11.4f, 11.45f, 11.5f, 11.55f,
                                    11.6f, 11.65f, 11.7f, 11.75f, 11.8f, 11.85f, 11.9f, 11.95f, 12f, 12.05f, 12.1f, 12.15f,
                                     12.2f, 12.25f, 12.3f, 12.35f, 12.4f, 12.45f, 12.5f, 12.55f, 12.6f, 12.65f, 12.7f, 12.75f,
                                      12.8f, 12.85f, 12.9f, 12.95f, 13f, 12.95f, 12.9f, 12.85f, 12.8f, 12.75f, 12.7f, 12.65f,
                                       12.6f, 12.55f, 12.5f, 12.45f, 12.4f, 12.35f, 12.3f, 12.25f, 12.2f, 12.15f, 12.1f,12.05f, 12f,
                                        11.95f, 11.9f, 11.85f, 11.8f, 11.75f, 11.7f, 11.65f, 11.6f, 11.55f, 11.5f, 11.45f, 11.4f, 11.35f,
                                         11.3f, 11.25f, 11.2f, 11.15f, 11.1f, 11.05f, 11f, 11.95f, 10.9f, 11.85f, 10.8f, 10.75f, 10.7f, 10.65f,
                                          10.6f, 10.55f, 10.5f, 10.45f, 10.4f, 10.35f, 10.3f, 10.25f, 10.2f, 10.15f, 10.1f, 10.05f, 10f,
                                           9.9f, 9.95f, 9.8f, 9.75f, 9.7f, 9.65f, 9.6f, 9.55f, 9.5f, 9.45f, 9.4f, 9.35f, 9.3f, 9.25f, 9.2f,
                                            9.15f ,9.1f, 9.05f, 9.0f};

    private float timer = 3.5f;
    private float initTimer = 3.5f;

    void Start()
    {
        candles = GetComponent<Light>();

        index = Random.Range(0, animationLight.Length - 2);

        int randomSum = 0;

        randomSum = Random.Range(0, 2);

        if (randomSum == 0)
        {
            animationSum = -1;
        }
        else
        {
            animationSum = 1;
        }


    }

    // Update is called once per frame
    void Update()
    {
        candles.intensity = animationLight[index];

        index += animationSum;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            index = Random.Range(6, 20);
            timer = initTimer;
        }

        if (index == 1)
        {
            index = animationLight.Length - 2;
        }

        if (index == animationLight.Length - 1)
        {
            index = 2;
        }
    }
}
