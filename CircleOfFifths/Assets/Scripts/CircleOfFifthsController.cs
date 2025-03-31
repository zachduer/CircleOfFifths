using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CircleOfFifthsController : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    bool isDrawing;
    private RectTransform rectTransform;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    //void Update()
    //{
    //    if (isDrawing)
    //    {
    //        TrackMousePosition();
    //    }
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    isDrawing = true;
    //    TrackMousePosition(); // Capture the initial press position
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    isDrawing = false;
    //}

    //private void TrackMousePosition()
    //{
    //    Vector2 localPoint;
    //    RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, null, out localPoint);

    //    // Convert to relative coordinates
    //    Vector2 topLeftRelative = new Vector2(localPoint.x + rectTransform.rect.width / 2, rectTransform.rect.height / 2 - localPoint.y);
    //    Vector2 centerRelative = localPoint;

    //    Debug.Log($"Mouse dragging at Top-Left Relative: {topLeftRelative}");
    //    Debug.Log($"Mouse dragging at Center Relative: {centerRelative}");
    //}


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.button + " mouse DOWN on: " + gameObject);

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localPoint);

        Debug.Log("eventData.position" + eventData.position);
        Debug.Log("localPoint" + localPoint);

        Vector2 centerRelative = localPoint;

        // Determine which pie slice the click falls into
        int sliceIndex = GetPieSlice(centerRelative);

        Debug.Log($"Click relative to center: {centerRelative}");

        Debug.Log($"Slice index: {sliceIndex}");
    }

    private int GetPieSlice(Vector2 point)
    {
        // Get the angle in degrees
        float angle = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;

        // Convert angle to range 0 - 360 (so 0° is at the top)
        if (angle < 0) angle += 360;
        Debug.Log("angle: " + angle);

        angle += 15; // Offset by 15 degrees to center the slices

        // Each slice covers 30 degrees, so divide the angle by 30 to get the index
        int sliceIndex = Mathf.FloorToInt(angle / 30);

        sliceIndex = sliceIndex == 12 ? 0 : sliceIndex;

        return sliceIndex;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(eventData.button + " mouse CLICK on: " + gameObject);

        //Vector2 localPoint;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localPoint);

        //// Convert to top-left based coordinates
        //Vector2 topLeftRelative = new Vector2(localPoint.x + rectTransform.rect.width / 2, rectTransform.rect.height / 2 - localPoint.y);

        //// Convert to center-based coordinates
        //Vector2 centerRelative = localPoint;

        //Debug.Log($"Click relative to top-left: {topLeftRelative}");
        //Debug.Log($"Click relative to center: {centerRelative}");
    }

}
