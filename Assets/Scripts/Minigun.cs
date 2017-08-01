using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Gun 
{
    public override void Attack()
    {
        lastAttackTime = Time.time;
        Instantiate<GameObject>(bulletPrefab, bulletSpawnPoint.position, GetBulletAngle());
        audioSource.pitch = Random.Range(0.98f, 1.02f);
        audioSource.PlayOneShot(audioClip);
        muzzleLight.enabled = true;
        transform.parent.Translate(Vector3.up * -kickbackLength);
    }
}
