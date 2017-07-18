using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public float fireRate; // per second
    public GameObject bulletPrefab;
    public float angleVariancy;

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

            float bulletAngle = transform.rotation.eulerAngles.z; // The original angle
            float newBulletAngle = bulletAngle - angleVariancy * (Random.value * 2 - 1); // New angle with gun accuracy applied
            Quaternion firingAngle = Quaternion.Euler(0f, 0f, newBulletAngle);

            Instantiate<GameObject>(bulletPrefab, transform.position, firingAngle);
        }
    }
}
