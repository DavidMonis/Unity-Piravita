using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    private float force = 10;
    private GameObject boat;
    private GameObject cam;
    bool Bigger_Camera = false;
    private GameObject Button_Map;
    private GameObject Button_Boat;
    private GameObject Button_Main_Island;

    private float Boat_Force = 5F;
    private Vector3 target;
    private int Scene_Number = 0;


    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            boat = GameObject.Find("Boat");
            Button_Map = GameObject.Find("/Canvas/Map_Button");
            Button_Boat = GameObject.Find("/Canvas/Boat_Button");
            Button_Main_Island = GameObject.Find("/Canvas/Main_Island_Button");
            target = boat.GetComponent<Transform>().position;
            Button_Boat.SetActive(false);
            Button_Main_Island.SetActive(false);
        }
        
        cam = GameObject.Find("Cam");
    }

    // Update is called once per frame
    void Update()
    {

        //movement on the see
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.GetKey(KeyCode.D) & boat.GetComponent<Transform>().position.x + 9 > GetComponent<Transform>().position.x)
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + force * Time.deltaTime, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.A) & boat.GetComponent<Transform>().position.x - 9 < GetComponent<Transform>().position.x)
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - force * Time.deltaTime, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.W) & boat.GetComponent<Transform>().position.y + 23 > GetComponent<Transform>().position.y)
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + force * Time.deltaTime, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.S) & boat.GetComponent<Transform>().position.y - 23 < GetComponent<Transform>().position.y)
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - force * Time.deltaTime, GetComponent<Transform>().position.z);
            }

            Boat_Movement();
            Cam_Movement();
            Control_Position();
        }
        //movement on Main Island
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + force * Time.deltaTime, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - force * Time.deltaTime, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + force * Time.deltaTime, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - force * Time.deltaTime, GetComponent<Transform>().position.z);
            }
            Cam_Movement();
        }

    }
    public void Bigger_Cam()
    {
        cam.GetComponent<Camera>().orthographicSize = 1700;
        Bigger_Camera = true;
        Button_Map.SetActive(false);
        Button_Boat.SetActive(true);
        cam.transform.position = new Vector3(0, 0, -10);
    }
    public void Smaller_Cam()
    {
        cam.GetComponent<Camera>().orthographicSize = 7;
        Bigger_Camera = false;
        Button_Map.SetActive(true);
        Button_Boat.SetActive(false);
    }
    void Boat_Movement() 
    {
        if (Input.GetMouseButtonDown(0) & Bigger_Camera)
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -700 | Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 2000)
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = 0;
                //mainisland
                if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 1500 & Camera.main.ScreenToWorldPoint(Input.mousePosition).y > 1000 &
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 1900 & Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 2500)
                {
                    target = new Vector3(2040, 1040, 0);
                }
                //island1
                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < -1450 & Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -1550 &
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -2350 & Camera.main.ScreenToWorldPoint(Input.mousePosition).x < -2250) 
                {
                    target = new Vector3(-2270, -1500, 0);
                }
                //island2
                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < -1570 & Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -1670 &
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -2435 & Camera.main.ScreenToWorldPoint(Input.mousePosition).x < -2335)
                {
                    target = new Vector3(-2360, -1620, 0);
                }
                //island3
                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < -1600 & Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -1700 &
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -2600 & Camera.main.ScreenToWorldPoint(Input.mousePosition).x < -2500)
                {
                    target = new Vector3(-2530, -1650, 0);
                }
                //island4
                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < -1310 & Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -1410 &
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -2420 & Camera.main.ScreenToWorldPoint(Input.mousePosition).x < -2320)
                {
                    target = new Vector3(-2330, -1360, 0);
                }
                //island5
                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < -1460 & Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -1560 &
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -2660 & Camera.main.ScreenToWorldPoint(Input.mousePosition).x < -2560)
                {
                    target = new Vector3(-2570, -1510, 0);
                }
                //island6
                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < -1280 & Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -1380 &
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -2580 & Camera.main.ScreenToWorldPoint(Input.mousePosition).x < -2480)
                {
                    target = new Vector3(-2500, -1330, 0);
                }
                //island7
                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < -1450 & Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -1550 &
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -2500 & Camera.main.ScreenToWorldPoint(Input.mousePosition).x < -2400)
                {
                    target = new Vector3(-2430, -1500, 0);
                }
            }
        }
        boat.transform.position = Vector3.MoveTowards(boat.transform.position, target, Boat_Force);
    }
    void Cam_Movement() 
    {
        if (Bigger_Camera == false)
        {
            cam.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
    public void Leave_Boat()
    {
        SceneManager.LoadScene(Scene_Number);
    }
    void Control_Position() 
    {
        //main
        if (boat.transform.position.x == 2040 & boat.transform.position.y == 1040 & Bigger_Camera == false)
        {
            Button_Main_Island.SetActive(true);
            Scene_Number = 1;
        }
        //islan1
        else if (boat.transform.position.x == -2270 & boat.transform.position.y == -1500 & Bigger_Camera == false)
        {
            Button_Main_Island.SetActive(true);
            Scene_Number = 2;
        }
        //island2
        else if (boat.transform.position.x == -2360 & boat.transform.position.y == -1620 & Bigger_Camera == false)
        {
            Button_Main_Island.SetActive(true);
            Scene_Number = 3;
        }
        //island3
        else if (boat.transform.position.x == -2530 & boat.transform.position.y == -1650 & Bigger_Camera == false)
        {
            Button_Main_Island.SetActive(true);
            Scene_Number = 4;
        }
        //island4
        else if (boat.transform.position.x == -2330 & boat.transform.position.y == -1360 & Bigger_Camera == false)
        {
            Button_Main_Island.SetActive(true);
            Scene_Number = 5;
        }
        //island5
        else if (boat.transform.position.x == -2570 & boat.transform.position.y == -1510 & Bigger_Camera == false)
        {
            Button_Main_Island.SetActive(true);
            Scene_Number = 6;
        }
        //island6
        else if (boat.transform.position.x == -2500 & boat.transform.position.y == -1330 & Bigger_Camera == false)
        {
            Button_Main_Island.SetActive(true);
            Scene_Number = 7;
        }
        //island7
        else if (boat.transform.position.x == -2430 & boat.transform.position.y == -1500 & Bigger_Camera == false)
        {
            Button_Main_Island.SetActive(true);
            Scene_Number = 8;
        }
        else
        {
            Button_Main_Island.SetActive(false);
            Scene_Number = 0;
        }
    }
    
}
