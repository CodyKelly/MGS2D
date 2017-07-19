using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGuns : MonoBehaviour 
{
    public GameObject[] guns;
    private int index = 0;

    private void Update()
    {
        bool switchedGuns = false;

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            switchedGuns = true;

            if (index + 1 == guns.Length)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            switchedGuns = true;

            if (index == 0)
            {
                index = guns.Length - 1;
            }
            else
            {
                index--;
            }
        }

        if(switchedGuns)
        {
            foreach (Transform t in transform)
            {
                if (t.gameObject.tag == "Weapon")
                {
                    Destroy(t.gameObject);
                }
            }

            Instantiate<GameObject>(guns[index], transform);

            print("Switched to " + guns[index].name);
        }
    }
}
