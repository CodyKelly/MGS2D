using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;
    public float liveTime;

    private float startTime;

    void Start ()
    {
        startTime = Time.time;
    }

	void Update ()
    {
        if (Time.time - startTime > liveTime)
        {
            Destroy(gameObject);
        }
        Vector3 movement = Vector2.up * Time.deltaTime * speed;
        transform.Translate(movement);
	}
}
