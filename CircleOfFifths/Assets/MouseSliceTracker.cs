using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class MouseSliceTracker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image CSlice;
    public Image GSlice;

    private RectTransform rectTransform;
    private bool isDrawing = false;
    private int currentSlice = -1;  // No slice at the start
    private HashSet<int> enteredSlices = new HashSet<int>();  // Track visited slices
    private List<int> enteredSliceOrder = new List<int>();  // Ordered history of entered slices

    public event Action<int> OnSliceEntered;  // Event for entering a new slice



    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (isDrawing)
        {
            TrackMousePosition();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrawing = true;
        enteredSlices.Clear();
        enteredSliceOrder.Clear();
        currentSlice = -1;
        TrackMousePosition(); // Capture the initial slice
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDrawing = false;
    }

    private void TrackMousePosition()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out localPoint);


        //Debug.Log("Input.mousePosition " + Input.mousePosition);
        //Debug.Log("localPoint" + localPoint);

        int newSlice = GetPieSlice(localPoint);

        // Check if we've moved into a new slice
        if (newSlice != currentSlice)
        {
            currentSlice = newSlice;

            // If it's a new slice (not already in set), trigger event
            if (!enteredSlices.Contains(newSlice))
            {
                enteredSlices.Add(newSlice);
                enteredSliceOrder.Add(newSlice);
                OnSliceEntered?.Invoke(newSlice); // Fire event
                Debug.Log($"Entered new slice: {newSlice}");
                if(newSlice == 3)
                {
                    CSlice.enabled = true;
                }
                if (newSlice == 2)
                {
                    GSlice.enabled = true;
                }

            }
        }
    }

    private int GetPieSlice(Vector2 point)
    {
        //Debug.Log("point: " + point);
        // Get the angle in degrees
        float angle = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;

        // Convert angle to range 0 - 360 (so 0° is at the top)
        if (angle < 0) angle += 360;
        
        angle += 15; // Offset by 15 degrees to center the slices
        //Debug.Log("Angle: " + angle);

        // Each slice covers 30 degrees, so divide the angle by 30 to get the index
        int sliceIndex = Mathf.FloorToInt(angle / 30);

        sliceIndex = sliceIndex == 12 ? 0 : sliceIndex;

        //Debug.Log("sliceIndex: " + sliceIndex);

        return sliceIndex;
    }

    // Getter to retrieve the list of visited slices
    public List<int> GetEnteredSliceOrder()
    {
        return new List<int>(enteredSliceOrder); // Return a copy to prevent modification
    }
}
