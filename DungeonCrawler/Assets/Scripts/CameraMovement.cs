using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float xOffset;
    public float yOffset;
    public float zOffset;
    void Update()
    {
        transform.position = player.position + new Vector3(xOffset, yOffset, zOffset);
    }
}