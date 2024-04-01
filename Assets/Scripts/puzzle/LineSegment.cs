using System.Collections.Generic;
using UnityEngine;

public class LineSegment : MonoBehaviour
{
    public LineRenderer line;
    public List<Vector3> points = new List<Vector3>();

    private void OnMouseDown()
    {
        // 세그먼트를 클릭하면 세그먼트를 제거합니다.
        Destroy(gameObject);
    }

    public void AddPoint(Vector3 point)
    {
        points.Add(point);
        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, point);
    }
}

public class LineDrawer : MonoBehaviour
{
    public GameObject lineSegmentPrefab;

    private LineSegment currentSegment;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 버튼을 누르면 새로운 세그먼트를 시작합니다.
            GameObject segmentObject = Instantiate(lineSegmentPrefab);
            currentSegment = segmentObject.GetComponent<LineSegment>();
            currentSegment.AddPoint(GetMouseWorldPos());
        }
        else if (Input.GetMouseButton(0))
        {
            // 마우스 버튼을 누르고 있으면 세그먼트에 포인트를 추가합니다.
            currentSegment.AddPoint(GetMouseWorldPos());
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}