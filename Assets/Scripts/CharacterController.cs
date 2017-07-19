using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Controller 
{
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position += new Vector3(horizontalMovement, verticalMovement, 0f);

        
    }
}
