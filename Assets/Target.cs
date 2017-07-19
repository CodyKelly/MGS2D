using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour 
{
    public TextMesh label;
    private Player player;
    private bool recordingHits = false;
    private int hits = 0, shotsTotal = 0, shotsAtStart = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (recordingHits)
        {
            shotsTotal = player.shotsFired - shotsAtStart;
            SetLabel();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (recordingHits && collision.gameObject.tag == "Bullet")
        {
            hits++;
        }
    }

    public void StartRecording()
    {
        hits = 0;
        label.gameObject.SetActive(true);
        recordingHits = true;
        shotsAtStart = player.shotsFired;
    }

    public void EndRecording()
    {
        recordingHits = false;
        label.gameObject.SetActive(false);
    }

    private void SetLabel()
    {
        if (shotsTotal == 0)
            label.text = "0%";
        else
            label.text = ((int)((float)hits / (float)shotsTotal * 100)).ToString() + "%";
    }
}