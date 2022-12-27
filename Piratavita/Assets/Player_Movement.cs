using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player_Movement : MonoBehaviour
{
    static public int Money = 10000;
    static public int Boat_Level = 10;
    static public int Max_Capacity_t = 100;
    static public double Actual_Capacity_t = 100;
    static public int Basic_Fish;
    static public int Special_Fish;
    static public int Heavy_Fish;
    static public int Whale_Fish;

    private float force = 10;
    private GameObject boat;
    private GameObject cam;
    bool Bigger_Camera = false;
    private GameObject Button_Map;
    private GameObject Button_Boat;
    private GameObject Button_Main_Island;
    GameObject Button_Basic_Fishing;
    GameObject Button_Special_Fishing;
    GameObject Button_Heavy_Fishing;
    GameObject Button_Whale_Fishing;

    GameObject Leave_Island_Button;
    private GameObject Button_Market;
    private GameObject Button_Jobs;
    GameObject Market_Menu;
    GameObject Jobs_Menu;
    bool Show_Stuff_Bool=false;

    GameObject Constant_Money;
    GameObject Constant_Level;
    GameObject _Capacity;
    GameObject Constant_Time;
    static float _Time;
    static int Time_Hour = 0;
    static int Time_Day = 0;
    
    private float Boat_Force = 5F;
    private Vector3 target;
    private int Scene_Number = 0;

    bool Standing_On_Market;
    bool Standing_On_Job;
    void Start()
    {

        Constant_Money = GameObject.Find("/Canvas/Konstnant/Money");
        Constant_Level = GameObject.Find("/Canvas/Konstnant/Level");
        Constant_Time = GameObject.Find("/Canvas/Konstnant/Time");
        Add_Constanst();
        //sea
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _Capacity = GameObject.Find("/Canvas/Konstnant/Capacity");
            _Capacity.GetComponent<Text>().text = "Capacity " + Actual_Capacity_t.ToString() + "/" + Max_Capacity_t.ToString() + " t";
            cam = GameObject.Find("Cam");
            boat = GameObject.Find("Boat");
            Button_Map = GameObject.Find("/Canvas/Map_Button");
            Button_Boat = GameObject.Find("/Canvas/Boat_Button");
            Button_Main_Island = GameObject.Find("/Canvas/Leave_Boat");
            Button_Basic_Fishing = GameObject.Find("/Canvas/Fish lvl 1");
            Button_Special_Fishing = GameObject.Find("/Canvas/Fish lvl 2");
            Button_Heavy_Fishing = GameObject.Find("/Canvas/Fish lvl 3");
            Button_Whale_Fishing = GameObject.Find("/Canvas/Fish lvl 4");

            target = boat.GetComponent<Transform>().position;
            Button_Boat.SetActive(false);
            Button_Main_Island.SetActive(false);
            Button_Basic_Fishing.SetActive(false);
            Button_Heavy_Fishing.SetActive(false);
            Button_Special_Fishing.SetActive(false);
            Button_Whale_Fishing.SetActive(false);
        }
        //Main island
        if (SceneManager.GetActiveScene().buildIndex >= 1) 
        {
            cam = GameObject.Find("Cam");
            Button_Market = GameObject.Find("/Canvas/Market_Button");
            Button_Jobs = GameObject.Find("/Canvas/Jobs_Button");
            Market_Menu = GameObject.Find("/Canvas/MarketText");
            Jobs_Menu = GameObject.Find("/Canvas/JobsText");
            Leave_Island_Button = GameObject.Find("/Canvas/Leave_Island");

            Leave_Island_Button.SetActive(false);
            Button_Market.SetActive(false);
            Button_Jobs.SetActive(false);
            Market_Menu.SetActive(false);
            Jobs_Menu.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Time_();
        //movement on the sea
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
        if (SceneManager.GetActiveScene().buildIndex >= 1)
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
            Leaving_Island();
        }

    }
    public void Bigger_Cam()
    {
        cam.GetComponent<Camera>().orthographicSize = 1700;
        Bigger_Camera = true;
        Button_Map.SetActive(false);
        Button_Boat.SetActive(true);
        cam.transform.position = new Vector3(0, 0, -10);

        Button_Basic_Fishing.SetActive(false);
        Button_Heavy_Fishing.SetActive(false);
        Button_Special_Fishing.SetActive(false);
        Button_Whale_Fishing.SetActive(false);
    }
    public void Smaller_Cam()
    {
        cam.GetComponent<Camera>().orthographicSize = 7;
        Bigger_Camera = false;
        Button_Map.SetActive(true);
        Button_Boat.SetActive(false);

        Button_Basic_Fishing.SetActive(true);
        if (Boat_Level > 0)
        {
            Button_Special_Fishing.SetActive(true);
        }
        if (Boat_Level > 1)
        {
            Button_Heavy_Fishing.SetActive(true);
        }
        if (Boat_Level > 2)
        {
            Button_Whale_Fishing.SetActive(true);
        }
    }
    void Boat_Movement() 
    {
        if (Input.GetMouseButtonDown(0) & Bigger_Camera)
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -700 | Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 2000)
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = 0;
                Debug.Log(target);
                Special_Movement();
            }
        }
        boat.transform.position = Vector3.MoveTowards(boat.transform.position, target, Boat_Force);
    }
    void Special_Movement() 
    {
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Market") 
        {
            Standing_On_Market = true;
            Button_Market.SetActive(true);

        }
        if (collision.name == "Jobs")
        {
            Standing_On_Job = true;
            Button_Jobs.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Market")
        {
            Standing_On_Market = false;
            Button_Market.SetActive(false);
            Market_Menu.SetActive(false);
        }
        if (collision.name == "Jobs")
        {
            Standing_On_Job = false;
            Button_Jobs.SetActive(false);
            Jobs_Menu.SetActive(false);
        }
    }
    public void Show_Stuff() 
    {
        if (Standing_On_Market&Show_Stuff_Bool == false) 
        {
            Market_Menu.SetActive(true);
            Show_Stuff_Bool = true;
        }
        else if (Standing_On_Job & Show_Stuff_Bool == false)
        {
            Jobs_Menu.SetActive(true);
            Show_Stuff_Bool = true ;
        }
        else if (Standing_On_Market&Show_Stuff_Bool)
        {
            Market_Menu.SetActive(false);
            Show_Stuff_Bool = false;
        }
        else if (Standing_On_Job & Show_Stuff_Bool)
        {
            Jobs_Menu.SetActive(false);
            Show_Stuff_Bool = false;
        }
    }
    void Add_Constanst() 
    {
        Constant_Money.GetComponent<Text>().text = Money.ToString()+ " coins";
        Constant_Level.GetComponent<Text>().text = Boat_Level.ToString() + " level";
        Constant_Time.GetComponent<Text>().text = Time_Hour + ":00";
    }
    public void Basic_Fishing() 
    {
        if(Actual_Capacity_t >= 0.0005 )
        {
            Basic_Fish += 1;
            Actual_Capacity_t -= 0.0005;

            _Capacity.GetComponent<Text>().text = "Capacity " + Actual_Capacity_t.ToString("N4") + "/" + Max_Capacity_t.ToString() + " t";
        }
    }
    public void Special_Fishing()
    {
        if (Actual_Capacity_t >= 0.001)
        {
            Special_Fish += 1;
            Actual_Capacity_t -= 0.001;

            _Capacity.GetComponent<Text>().text = "Capacity " + Actual_Capacity_t.ToString("N3") + "/" + Max_Capacity_t.ToString() + " t";
        }
    }
    public void Heavy_Fishing()
    {
        if (Actual_Capacity_t >= 1)
        {
            Heavy_Fish += 1;
            Actual_Capacity_t -= 1;

            _Capacity.GetComponent<Text>().text = "Capacity " + Actual_Capacity_t.ToString("N0") + "/" + Max_Capacity_t.ToString() + " t";
        }
    }
    public void Whale_Fishing()
    {
        if (Actual_Capacity_t >= 25)
        {
            Whale_Fish += 1;
            Actual_Capacity_t -= 25;

            _Capacity.GetComponent<Text>().text = "Capacity " + Actual_Capacity_t.ToString("N0") + "/" + Max_Capacity_t.ToString() + " t";
        }
    }
    public void Time_() 
    {
        _Time += Time.deltaTime;
        if(_Time >= 60) 
        {
            Time_Hour += 1;
            _Time = 0;  
            if (Time_Hour >= 24) 
            {
                Time_Hour = 0;
                Time_Day += 1;
            }
            Constant_Time.GetComponent<Text>().text = Time_Hour + ":00";
        }
    }

    public void Leave_Island() 
    {
        SceneManager.LoadScene(0);
    }
    void Leaving_Island() 
    {
        if (transform.position.x > -2 & transform.position.x < 2 & transform.position.y > -2 & transform.position.y < 2)
        {
            Leave_Island_Button.SetActive(true);
        }
        else 
        {
            Leave_Island_Button.SetActive(false);
        }
    }
}
