using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFootsteps : MonoBehaviour 
{
    public AudioClip[] newSteps;

    private Dictionary<GameObject, AudioClip[]> oldSteps;

    private void Start()
    {
        oldSteps = new Dictionary<GameObject, AudioClip[]>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Footsteps footsteps = collision.gameObject.GetComponent<Footsteps>();
        if (footsteps != null)
        {
            oldSteps.Add(footsteps.gameObject, footsteps.stepSounds);
            footsteps.stepSounds = newSteps;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (oldSteps.ContainsKey(collision.gameObject))
        {
            AudioClip[] steps = null;
            oldSteps.TryGetValue(collision.gameObject, out collision.gameObject.GetComponent<Footsteps>().stepSounds);
            oldSteps.Remove(collision.gameObject);
        }
    }
}
