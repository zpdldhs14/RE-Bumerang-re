using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    private bool redLineConnected = false;
    private bool blueLineConnected = false;
    private bool yellowLineConnected = false;

    public void LineConnected(string color)
    {
        switch (color)
        {
            case "Red":
                redLineConnected = true;
                break;
            case "Blue":
                blueLineConnected = true;
                break;
            case "Yellow":
                yellowLineConnected = true;
                break;
        }
        CheckLines();
    }

    public void LineDisconnected(string color)
    {
        switch (color)
        {
            case "Red":
                redLineConnected = false;
                break;
            case "Blue":
                blueLineConnected = false;
                break;
            case "Yellow":
                yellowLineConnected = false;
                break;
        }
        CheckLines();
    }

    private void CheckLines()
    {
        if (!blueLineConnected && !yellowLineConnected)
        {
            Debug.Log("비상 장금이 작동되었습니다");
        }
        else if (!yellowLineConnected)
        {
            Debug.Log("잠금이 해제되었습니다");
        }
        else if (!blueLineConnected)
        {
            // 아무 일도 일어나지 않음
        }
    }
}