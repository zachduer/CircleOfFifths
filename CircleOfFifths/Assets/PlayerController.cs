using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System;

public class PlayerController : MonoBehaviour
{
    IA_CustomActions input;

    NavMeshAgent agent;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    [Header("canvas")]
    public Canvas canvas;
    public GameObject Line;
    public GameObject Inventory;
    public GameObject Scroll1;
    public GameObject Scroll2;

    [Header("chests")]
    [SerializeField] LayerMask chest1;
    [SerializeField] LayerMask chest2;

    float lookRotationSpeed = 8f;

    private bool spaceDown = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        input = new IA_CustomActions();

        AssignInputs();
    }

    void AssignInputs()
    {
        input.Main.Click.performed += ctx => ClickToMove();
        input.Main.Circle.performed += ctx => SpacebarDown();;
        input.Main.Circle.canceled += ctx => SpacebarUp();
    }

    void SpacebarDown()
    {
        if (spaceDown == false)
        {
            agent.isStopped = true;
            spaceDown = true;
            Line.SetActive(true);
            canvas.gameObject.SetActive(true);
            Inventory.SetActive(true);
        }
    }

    void SpacebarUp()
    {
        if (spaceDown == true)
        {
            agent.isStopped = false;
            spaceDown = false;
            Line.SetActive(false);
            canvas.gameObject.SetActive(false);
            Inventory.SetActive(false);
        }
    }
        
    void ClickToMove()
    {
        if (spaceDown == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, chest1))
            {
                //Debug.Log("Hit Chest 1");
                Scroll1.SetActive(true);
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, chest2))
            {
                //Debug.Log("Hit Chest 2");
                Scroll2.SetActive(true);
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, clickableLayers))
            {
                agent.destination = hit.point;
                if (clickEffect != null)
                {
                    Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
                }
            }
        }
    }

    void OnEnable()
    {
        input.Enable();
    }
    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        FaceTarget();
    }

    void FaceTarget()
    {
        Vector3 direction = (agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    }
}
