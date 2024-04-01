using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    public LineRenderer line;
    public LineManager manager;
    public string lineColor;
    private bool isDrawing = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            StopDrawing();
        }

        if (isDrawing)
        {
            line.SetPosition(1, GetMouseWorldPos());
        }
    }

    public void StartDrawing()
    {
        isDrawing = true;
        line.positionCount = 2;
        line.SetPosition(0, GetMouseWorldPos());
    }

    public void StopDrawing()
    {
        isDrawing = false;
        line.positionCount = 0;
        manager.LineDisconnected(lineColor);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}