using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public float fireRate; // per second
    public GameObject bulletPrefab;

    private float lastTimeFired;

    void Start()
    {
        lastTimeFired = Time.time - fireRate;
    }

    void Update ()
    {
        if (Input.GetMouseButton(0) && Time.time - fireRate > lastTimeFired)
        {
            lastTimeFired = Time.time;
            Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
