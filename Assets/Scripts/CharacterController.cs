using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Controller 
{
    public float stepRate;
    public AudioClip[] stepSounds;
    public AudioSource audioSource;

    private int currentStepIndex = 0;
    private float lastStepTime = 0f;

    private void Start()
    {
        lastStepTime = Time.time;
    }

    private void Update()
    {
        move();
    }

    private void incrementStepIndex()
    {
        if (currentStepIndex == stepSounds.Length - 1)
            currentStepIndex = 0;
        else
            currentStepIndex++;
    }

    private void checkForStep()
    {
        if (stepRate < Time.time - lastStepTime)
        {
            audioSource.PlayOneShot(stepSounds[currentStepIndex]);
            incrementStepIndex();
            lastStepTime = Time.time;
        }
    }

    private void move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position += new Vector3(horizontalMovement, verticalMovement, 0f);

        if (horizontalMovement != 0 || verticalMovement != 0)
            checkForStep();
    }
}
