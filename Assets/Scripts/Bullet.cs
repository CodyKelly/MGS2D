using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;
    public float liveTime;
    public bool destroyOnImpact = true;

    private float startTime;

    void Start ()
    {
        startTime = Time.time;
    }

	void FixedUpdate ()
    {
        if (Time.time - startTime > liveTime)
        {
            Destroy(gameObject);
        }
        Vector3 movement = Vector2.up * Time.deltaTime * speed;
        transform.Translate(movement);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
