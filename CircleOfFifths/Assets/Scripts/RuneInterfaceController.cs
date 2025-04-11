using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.Drawing;

public class RuneInterfaceController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image AGlow;
    public Image BGlow;
    public Image CGlow;
    public Image DGlow;
    public Image EGlow;
    public Image FGlow;
    public Image GGlow;

    public Image CircleSpellcastGlow;

    private RectTransform rectTransform;
    private bool isDrawing = false;
    private int currentSlice = -1;  // No slice at the start
    //private HashSet<int> clickedSlices = new HashSet<int>();  // Track visited slices .... hashset was for when we were thinking about only having each slice be clickable once
    private List<int> clickedSlices = new List<int>();  // Track visited slices 
    //private List<int> clickedSliceOrder = new List<int>();  // Ordered history of entered slices

    public event Action<int> OnSliceEntered;  // Event for entering a new slice
    public event Action<int> OnSliceClicked;  // Event for clicking a slice
    public event Action OnRuneSubmitted;  // Event for submitting the rune



    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        int newSlice = GetPieSlice();

        // Check if we've moved into a new slice
        if (newSlice != currentSlice)
        {
            //Debug.Log("Entered new slice: " + newSlice);
            currentSlice = newSlice;
            OnSliceEntered?.Invoke(newSlice); // Fire event
        }

    }

    public void SubmitMelody()
    {
        AGlow.enabled = false;
        BGlow.enabled = false;
        CGlow.enabled = false;
        DGlow.enabled = false; 
        EGlow.enabled = false;
        FGlow.enabled = false;
        GGlow.enabled = false;

        clickedSlices.Clear();
        //clickedSliceOrder.Clear();

        OnRuneSubmitted?.Invoke(); // Fire event
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
        isDrawing = true;

        int newSlice = GetPieSlice();

        clickedSlices.Add(newSlice);

        OnSliceClicked?.Invoke(newSlice); // Fire event

        EnableSliceGlow(newSlice);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDrawing = false;
    }

    //private void UpdateSlice()
    //{
    //    int newSlice = GetPieSlice();

    //    // Check if we've moved into a new slice
    //    if (newSlice != currentSlice)
    //    {
    //        currentSlice = newSlice;

    //        // If it's a new slice (not already in set), trigger event
    //        if (!enteredSlices.Contains(newSlice))
    //        {
    //            enteredSlices.Add(newSlice);
    //            enteredSliceOrder.Add(newSlice);
    //            OnSliceEntered?.Invoke(newSlice); // Fire event
    //            //Debug.Log($"Entered new slice: {newSlice}");
                
    //            EnableSliceGlow(newSlice);
    //        }
    //    }
    //}

    private void EnableSliceGlow(int sliceIndex)
    {
        if (sliceIndex == 0)
        {
            AGlow.enabled = true;
        }
        if (sliceIndex == 1)
        {
            BGlow.enabled = true;
        }
        if (sliceIndex == 2)
        {
            CGlow.enabled = true;
        }
        if (sliceIndex == 3)
        {
            DGlow.enabled = true;
        }
        if (sliceIndex == 4)
        {
            EGlow.enabled = true;
        }
        if (sliceIndex == 5)
        {
            FGlow.enabled = true;
        }
        if (sliceIndex == 6)
        {
            GGlow.enabled = true;
        }
    }

    private int GetPieSlice()
    {
        Vector2 point;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out point);

        // only calculate slide if the click is in the radius of the arc of the circle
        float radius = point.magnitude; // Same as sqrt(x^2 + y^2)
        //Debug.Log("radius: " + radius);
        if (radius < 310f || radius > 450f)
        {
            // Outside valid range
            return -1;
        }

        //Debug.Log("point: " + point);
        // Get the angle in degrees
        float angle = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;

        // Convert angle to range 0 - 360 (so 0° is at the top)
        if (angle < 0) angle += 360;

        //Debug.Log("Real angle: " + angle);

        angle -= 115; // Offset in order to line up with drawn slices
        //Debug.Log("offset angle: " + angle);

        // reverse the angle to go clockwise instead of counterclockwise
        angle = (360 - angle) % 360;
        //Debug.Log("reverse angle: " + angle);

        // Each slice covers 360 / 7 degrees, so divide that angle to get the index
        int sliceIndex = Mathf.FloorToInt(angle / 51.43f);

        sliceIndex = sliceIndex == 7 ? 0 : sliceIndex;

        //Debug.Log("sliceIndex: " + sliceIndex);

        return sliceIndex;
    }

    // Getter to retrieve the list of visited slices
    public List<int> GetClickedSlices()
    {
        //return new List<int>(enteredSliceOrder); // Return a copy to prevent modification
        return new List<int>(clickedSlices); // Return a copy to prevent modification
    }
}
