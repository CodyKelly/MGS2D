using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float fireRate; // per second
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float angleVariancy;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float muzzleFlashTime;
    public float muzzleFlashIntensity;
    public Light muzzleLight;
    public float kickbackLength;

    private float lastTimeFired;

    void Start()
    {
        lastTimeFired = Time.time - fireRate;
    }

    void FixedUpdate ()
    {
        foreach(Transform t in transform.parent)
        {
            t.position = transform.parent.position;
        }
        if (Input.GetMouseButton(0) && Time.time - fireRate > lastTimeFired)
        {
            Shoot();
        }
        if (Time.time - muzzleFlashTime > lastTimeFired)
        {
            muzzleLight.intensity = 0f;
        }
    }

    private void Shoot ()
    {
        lastTimeFired = Time.time;
        Instantiate<GameObject>(bulletPrefab, bulletSpawnPoint.position, GetBulletAngle());
        audioSource.pitch = Random.Range(0.98f, 1.02f);
        audioSource.PlayOneShot(audioClip);
        muzzleLight.intensity = muzzleFlashIntensity;
        foreach (Transform t in transform.parent)
        {
            t.Translate(Vector3.up * -kickbackLength);
        }
    }

    private Quaternion GetBulletAngle()
    {
        float bulletAngle = transform.rotation.eulerAngles.z; // The original angle
        float newBulletAngle = bulletAngle - angleVariancy * (Random.value * 2 - 1); // New angle with firing variancy applied
        return Quaternion.Euler(0f, 0f, newBulletAngle);
    }
}
