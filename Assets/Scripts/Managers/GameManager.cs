using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static List<int> collectedItems = new List<int>();
    static float speed = 5f, moveAccuracy = 0.15f;
    public IEnumerator MoveToPoint(Transform myObject, Vector2 point)
    {
        Vector2 positiondiff = point - (Vector2)myObject.position;
        while (positiondiff.magnitude > moveAccuracy)
        {
            myObject.Translate(speed * positiondiff.normalized * Time.deltaTime);
            positiondiff = point - (Vector2)myObject.position;
            yield return null;
        }
        myObject.position = point;
    }
}
