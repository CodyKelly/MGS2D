using UnityEngine;
using System.Collections;

public class FaceCursor : MonoBehaviour
{
    void Update()
    {
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get cursor position in World coordinates
        float angle;    // This will hold the angle between the mouse and the object

        mouse_pos.z = transform.position.z; // Set the 'z coordinate' of the cursor to that of the object so it won't tilt up or down

        // Get difference of positions between mouse and object
        mouse_pos.x = mouse_pos.x - transform.position.x;
        mouse_pos.y = mouse_pos.y - transform.position.y;

        // Calculate angle (subtracting 90 degrees so that object won't point to the side)
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90f;

        // Apply rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}