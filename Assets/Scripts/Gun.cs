using UnityEngine;
using System.Collections;

public class Gun : Weapon
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float angleVariancy;
    public float muzzleFlashTime;
    public float muzzleFlashIntensity;
    public Light muzzleLight;
    public float kickbackLength;

    void FixedUpdate ()
    {
        foreach(Transform t in transform.parent)
        {
            t.position = transform.parent.position;
        }
        if (Input.GetMouseButton(0) && Time.time - attackCooldown > lastAttackTime)
        {
            Attack();
        }
        if (Time.time - muzzleFlashTime > lastAttackTime)
        {
            muzzleLight.intensity = 0f;
        }
    }

    public override void Attack ()
    {
        lastAttackTime = Time.time;
        Instantiate<GameObject>(bulletPrefab, bulletSpawnPoint.position, GetBulletAngle());
        audioSource.pitch = Random.Range(0.98f, 1.02f);
        audioSource.PlayOneShot(audioClip);
        muzzleLight.intensity = muzzleFlashIntensity;
        foreach (Transform t in transform.parent)
        {
            t.Translate(Vector3.up * -kickbackLength);
        }
    }

    protected Quaternion GetBulletAngle()
    {
        float bulletAngle = transform.rotation.eulerAngles.z; // The original angle
        float newBulletAngle = bulletAngle - angleVariancy * (Random.value * 2 - 1); // New angle with firing variancy applied
        return Quaternion.Euler(0f, 0f, newBulletAngle);
    }
}
