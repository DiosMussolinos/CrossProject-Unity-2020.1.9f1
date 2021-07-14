using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class CameraControl : MonoBehaviour
{
    //Public Variables
    public float mouseSense = 100f;
    public GameObject player;

    //Private Variables
    private float cameraRotation;
    private ControlAndMovement control;

    // New Input System:
    private Vector2 lookInput;

    public Animator anim;
    public GameObject breathingUI;

    private Quaternion currRotation;
    private Vector3 currPosition;

    private Camera cam;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        control = player.GetComponent<ControlAndMovement>();
        currRotation = this.transform.localRotation;
        cam = GetComponent<Camera>();

    }
    public void OnRotateCamera(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        lookInput = new Vector2(inputVec.x, inputVec.y);

    }

    public void BreathingEffect()
    {
        this.transform.localPosition = new Vector3(currPosition.x, Mathf.Sin(Time.time * 1.5f) * 0.1f, currPosition.z);
    }

    public void DropCamera()
    {
        anim.SetTrigger("cameraDrop");
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("cameraDrop"))
        {
            currPosition = this.transform.localPosition;
        }
    }

    public void RestoreCamera()
    {
        StartCoroutine(SlerpFromTo(this.transform.localRotation, currRotation, 2f));

    }

    IEnumerator SlerpFromTo(Quaternion initial, Quaternion final, float duration)
    {
        for (float i = 0f; i < duration; i += Time.deltaTime)
        {
            transform.localRotation = Quaternion.Slerp(initial, final, i / duration);
            yield return 0;
        }
        transform.localRotation = final;
    }

    void Update()
    {
        if ((control.interacting == false) && (!breathingUI.GetComponent<BreathingUI>().IsUIActive()))
        {
            cameraRotation -= lookInput.y;
            cameraRotation = Mathf.Clamp(cameraRotation, -90f, 45f);
            transform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);
            control.transform.Rotate(Vector3.up * lookInput.x);
        }
        //else if(control.HasTriggeredBreathingUI())
        //{
        //    DropCamera();
        //    breathingUI.SetActive(true);
        //}

    }
}
