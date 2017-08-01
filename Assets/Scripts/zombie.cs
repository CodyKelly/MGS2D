using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour 
{
    public float speed;
    public float damage;
    public Transform target;
    public float maxHealth;
    public float health;
    public float sightLength;
    public float sightAngle;
    public Rigidbody2D rigidbody;
    public bool dead
    {
        get
        {
            return health <= 0;
        }
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!dead)
        {
            faceTarget();
            move();
        }
        else
        {
            die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 10;
        }
    }

    private void move()
    {
        rigidbody.AddForce(transform.right * speed * Time.deltaTime);
    }

    private void faceTarget()
    {
        Vector3 target_pos = target.position;
        float angle;    // This will hold the angle between the mouse and the object

        target_pos.z = transform.position.z; // Set the 'z coordinate' of the cursor to that of the object so it won't tilt up or down

        // Get difference of positions between mouse and object
        target_pos.x = target_pos.x - transform.position.x;
        target_pos.y = target_pos.y - transform.position.y;

        // Calculate angle (subtracting 90 degrees so that object won't point to the side)
        angle = Mathf.Atan2(target_pos.y, target_pos.x) * Mathf.Rad2Deg;

        // Apply rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void die()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}
