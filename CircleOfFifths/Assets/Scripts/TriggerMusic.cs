using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    public MouseSliceTracker mouseSliceTracker;

    private void Awake()
    {
        mouseSliceTracker.OnSliceEntered += HandleSliceEntered;
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void HandleSliceEntered(int slice)
    {
        Debug.Log("TriggerMusic -> Slice entered: " + slice);
    }
}
