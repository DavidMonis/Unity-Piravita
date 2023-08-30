using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Bouncer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "Fence1":
                GetComponentInParent<Soldier_Movement>().SetDirection(4);
                break;
            case "Fence7":
                GetComponentInParent<Soldier_Movement>().SetDirection(4);
                break;
            case "Fence8":
                GetComponentInParent<Soldier_Movement>().SetDirection(4);
                break;
            case "Fence4":
                GetComponentInParent<Soldier_Movement>().SetDirection(2);
                break;
            case "Fence5":
                GetComponentInParent<Soldier_Movement>().SetDirection(1);
                break;
            case "Fence6":
                GetComponentInParent<Soldier_Movement>().SetDirection(3);
                break;
        }
    }
}
