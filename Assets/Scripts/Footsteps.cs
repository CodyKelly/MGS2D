using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour 
{
    public AudioClip[] stepSounds;
    public AudioSource audioSource;
    public float stepRate;
    public bool randomizeStepRate = false;

    private int currentStepIndex = 0;
    private float lastStepTime = 0f;
    private Vector3 lastPosition;
    private Vector3 deltaPosition
    {
        get
        {
            return transform.position - lastPosition;
        }
    }

    private void Start()
    {
        lastStepTime = Time.time;
        lastPosition = transform.position;

        if (randomizeStepRate)
            stepRate += Random.value / 2;
    }

    private void Update()
    {
        if (deltaPosition != Vector3.zero)
            checkForStep();

        lastPosition = transform.position;
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
            audioSource.volume = Random.value / 2+0.55f;
            audioSource.PlayOneShot(stepSounds[currentStepIndex]);
            incrementStepIndex();
            lastStepTime = Time.time;
        }
    }
}
