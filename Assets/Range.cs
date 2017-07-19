using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour 
{
    public Target target;
    public int length = 1;
    public Transform spritesHolder;
    public GameObject rangePiece;

    private void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.size = new Vector2(2, length);
        collider.offset = new Vector2(0, (float)((float)-length / 2f));
        for (int x = 0; x < length; x++)
        {
            GameObject newPiece = Instantiate(rangePiece, new Vector3(0, -x - 0.5f), Quaternion.identity);
            newPiece.transform.SetParent(spritesHolder);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            target.StartRecording();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            target.EndRecording();
        }
    }
}
