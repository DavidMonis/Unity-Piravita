using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShip : MonoBehaviour
{
    // Start is called before the first frame update
    static public float forceB = 0.3F;
    Vector3 position;
    GameObject boat;
    bool hunting = false;
    void Awake()
    {
        boat = GameObject.Find("Boat");
        position.x = Random.Range(950, 3000);
        position.y = Random.Range(-275,1600);
        position.z = -2;
        Debug.Log(position);
    }

    // Update is called once per frame
    void Update()
    {
        if (hunting == false)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, position, forceB * Time.deltaTime);
            if (gameObject.transform.position == position)
            {
                position = new Vector3(2101, 876, -1.9F);
            }
            if (gameObject.transform.position == new Vector3(2101, 876, -1.9F))
            {
                Destroy(gameObject);
            }
        }
        else if(hunting)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, boat.transform.position, forceB * Time.deltaTime);
            if (gameObject.transform.position == boat.transform.position)
            {
                Fight();
            }
            if (gameObject.transform.position.x<900|| gameObject.transform.position.y < -300)
            {
                hunting = false;
            }
        }
    }
    static public void Increase()
    {
        forceB *= 400;
    }
    static public void Decrease()
    {
        forceB /= 400;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Boat")
        {
            hunting = true;
        }
    }
    void Fight()
    {
        float num = Controller_Script.Boat_Power / 100;
        Mathf.Round(num);
        Controller_Script.Boat_Power = Controller_Script.Boat_Power - (int)Mathf.Round(80 / num);
        Debug.Log(Controller_Script.Boat_Power);
        if (Controller_Script.Boat_Power<0)
        {
            Debug.Log("GameOver");
            Destroy(boat);
            Controller_Script.Game_Over = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
