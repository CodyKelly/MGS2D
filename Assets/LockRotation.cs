using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour 
{
    public bool lockInitialRotation = true;
    public Vector3 rotation;

    private void Start()
    {
        if (lockInitialRotation)
        {
            rotation = transform.rotation.eulerAngles;
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(rotation);
    }

}
