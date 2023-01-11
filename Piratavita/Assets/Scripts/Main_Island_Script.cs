using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Island_Script : MonoBehaviour
{
    static public bool Main_Island_Pressed = false;
    private void OnMouseDown()
    {
        Main_Island_Pressed = true;
    }
}
