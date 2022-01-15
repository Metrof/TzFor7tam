using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInMap : MonoBehaviour
{
    private float maxX = 6.1f;
    private float minX = -6.6f;
    private float maxY = 3.5f;
    private float minY = -3.8f;
    private void LateUpdate()
    {
        Vector2 mapPos = transform.position;
        mapPos.x = Mathf.Clamp(mapPos.x, minX, maxX);
        mapPos.y = Mathf.Clamp(mapPos.y, minY, maxY);
        transform.position = mapPos;
    }
}
