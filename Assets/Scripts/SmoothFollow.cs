using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {
    public Transform target;
    public Vector3 offset;
    public float elasticity;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position - offset, target.position, Time.deltaTime * elasticity) + offset;
    }
}
