using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {
    public bool automaticallyFollowPlayer = true;
    public Transform target;
    public Vector3 offset;
    public float elasticity;

    private void Start()
    {
        if (automaticallyFollowPlayer)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position - offset, target.position, Time.deltaTime * elasticity) + offset;
    }
}
