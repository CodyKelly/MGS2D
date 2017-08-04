using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Controller 
{
    public float stepRate;


    private void Start()
    {
        
    }

    private void Update()
    {
        move();
    }





    private void move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position += new Vector3(horizontalMovement, verticalMovement, 0f);
    }
}
