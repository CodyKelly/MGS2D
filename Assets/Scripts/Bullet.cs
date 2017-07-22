using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;
    public float liveTime;
    public float rayLength;
    public LayerMask layerMask;
    public bool destroyOnImpact = true;

    private Ray2D ray;

    private float startTime;

    void Start ()
    {
        startTime = Time.time;
    }

	void FixedUpdate ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, layerMask);

        if (hit.collider != null && hit.collider.gameObject.tag != "Player")
        {
            Debug.Log(hit.collider.gameObject.name);
            Destroy(gameObject);
        }

        if (Time.time - startTime > liveTime)
        {
            Destroy(gameObject);
        }

        Vector3 movement = Vector2.up * Time.deltaTime * speed;
        transform.Translate(movement);
	}
}
