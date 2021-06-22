using UnityEngine;

public class LightShadowRay : MonoBehaviour
{
    public GameObject[] lights;
    public GameObject player;
    public float lightRadius;
    public GameObject shader;
    public State attackState;

    private Vector3 origin;
    private int closesLighttIndex;
    private ControlAndMovement control;
    private FSM fsm;
    private GameObject mesh;
    public bool meshActive = false;
    private bool rayHitWall = false;

    void Start()
    {
        origin = Vector3.zero;
        control = player.GetComponent<ControlAndMovement>();
        fsm = GetComponent<FSM>();
        mesh = transform.GetChild(1).gameObject;
        shader.SetActive(true);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RayCastLightShadow();
        ShaderController();

        mesh.SetActive(meshActive);

        if ((meshActive == false) && (fsm.currentState != attackState) && (rayHitWall == true))
        {
            shader.SetActive(true);
        }
        else
        {
            shader.SetActive(false);
        }
    }

    public void ShaderController()
    {
        GameObject heatShader = transform.GetChild(0).gameObject;

        if (Physics.Linecast(transform.position, player.transform.position, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                rayHitWall = true;
            }
            else if(hit.collider.gameObject.CompareTag("Wall"))
            {
                rayHitWall = false;
            }

        }
    }

    public void RayCastLightShadow()
    {
        float closestDistance = Mathf.Infinity;
        int closestLightId = 0;

        for (int i = 0; i < lights.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, lights[i].transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestLightId = i;
            }
        }

        origin = lights[closestLightId].transform.position;
       
        if (Physics.Linecast(origin, transform.position, out RaycastHit hit))
        {
            //Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.CompareTag("Shadow") && (closestDistance < lightRadius))
            {
                RayCastShadowPlayer();
            }
            else
            {
                meshActive = false;
            }
        }
    }

    public void RayCastShadowPlayer()
    {
        if (Physics.Linecast(transform.position, player.transform.position, out RaycastHit HitPlayer))
        {
            //Debug.Log(HitPlayer.collider.tag);
            if (HitPlayer.collider.gameObject.CompareTag("Player") || (HitPlayer.collider.gameObject.CompareTag("Lights")))
            {
                meshActive = true;
                if (this.transform.name == "Shadow - Cat")
                {
                    control.CanSeeShadow();
                }
            }
            else
            {
                meshActive = false;
                //control.sawShadow = false;
            }

        }
    }

}