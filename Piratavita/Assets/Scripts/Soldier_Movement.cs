using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Movement : MonoBehaviour
{
    static public bool Soldier_Moving_Bool;
    GameObject Player;
    float force = 5F;
    float direction;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Random_Values();
        direction = Random.Range(1,5);
        time = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {

        if (Soldier_Moving_Bool) 
        {
            Soldier_Moving();
            if (transform.position.x == Player.transform.position.x & transform.position.y == Player.transform.position.y)
            {
                Soldier_Moving_Bool = false;
                Controller_Script.Game_Over = true;
            }
        }
        else 
        {
            Soldier_Movement_();
        }
    }
    void Soldier_Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.15F);
    }

    void Soldier_Movement_() 
    {
        if (direction == 1) 
        {
            if(time > 0)
            {
                Movement_Up();
                time -= Time.deltaTime;
            }
            else
            {
                time = Random.Range(1, 10);
                direction = Random.Range(1, 5);
            }
        }
        else if (direction == 2)
        {
            if (time > 0)
            {
                Movement_Down();
                time -= Time.deltaTime;
            }
            else
            {
                time = Random.Range(1, 10);
                direction = Random.Range(1, 5);
            }
        }
        else if (direction == 3)
        {
            if (time > 0)
            {
                Movement_Left();
                time -= Time.deltaTime;
            }
            else
            {
                time = Random.Range(1, 10);
                direction = Random.Range(1, 5);
            }
        }
        else if (direction == 4)
        {
            if (time > 0)
            {
                Movement_Right();
                time-= Time.deltaTime;
            }
            else
            {
                time = Random.Range(1, 10);
                direction = Random.Range(1, 5);
            }
        }

    }
    void Movement_Up() 
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + force * Time.deltaTime, 0);
    }
    void Movement_Down()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - force * Time.deltaTime, 0);
    }
    void Movement_Left()
    {
        transform.position = new Vector3(transform.position.x - force * Time.deltaTime, transform.position.y, 0);
    }
    void Movement_Right()
    {
        transform.position = new Vector3(transform.position.x + force * Time.deltaTime, transform.position.y, 0);
    }
    void Random_Values() 
    {
        time = 5;
    }
}
