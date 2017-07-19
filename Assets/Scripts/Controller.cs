using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    public float speed = 3;

    private void Attack ()
    {
        if (CarryingWeapon())
        {
            GetWeapon();
        }
    }

    protected Weapon GetWeapon()
    {
        Weapon weapon = null;

        foreach (Transform t in transform)
        {
            if (t.gameObject.tag == "Weapon")
            {
                weapon = t.gameObject.GetComponent<Weapon>();
            }
        }

        return weapon;
    }

    protected bool CarryingWeapon()
    {
        bool carryingWeapon = false;
        foreach (Transform t in transform)
        {
            if (t.gameObject.tag == "Weapon")
                carryingWeapon = true;
        }

        return carryingWeapon;
    }
}
