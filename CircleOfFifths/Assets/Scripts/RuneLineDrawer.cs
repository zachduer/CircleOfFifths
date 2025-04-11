using UnityEngine;

public class RuneLineDrawer : MonoBehaviour
{
    public RuneInterfaceController runeInterfaceController;

    private TrailRenderer trail;
    private Camera mainCamera;

    private void Awake()
    {
        runeInterfaceController.OnSliceClicked += HandleSliceClicked;
        runeInterfaceController.OnRuneSubmitted += HandleRuneSubmitted;
        trail = GetComponent<TrailRenderer>();
    }

    void Start()
    {
        mainCamera = Camera.main;
    }


    void Update()
    {
        
    }

    void HandleSliceClicked(int slice)
    {
        Debug.Log("RuneLineDrawer -> Slice clicked: " + slice);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Set depth for world position conversion
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0f; // Keep it in 2D plane

        // Move trail renderer to follow the mouse
        trail.transform.position = worldPosition;
    }

    void HandleRuneSubmitted()
    {
        trail.Clear();
    }
}
