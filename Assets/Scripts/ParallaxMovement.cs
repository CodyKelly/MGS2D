using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour 
{
    public float zPosition;
    public float ratio;
    public Vector3 originPoint;
    public Transform target;

    private void Start()
    {
        originPoint = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(originPoint.x + target.position.x * ratio, originPoint.y + target.position.y * ratio, zPosition);
    }
}
