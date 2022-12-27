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
    static public int Food_On_Day = 100;
    static public int Basic_Fish;
    static public int Special_Fish;
    //types
    static public int Special_Fish_1;
    static public int Special_Fish_2;
    static public int Special_Fish_3;
    static public int Special_Fish_4;
    static public int Special_Fish_5;

    static public int Heavy_Fish;
    //types
    static public int Heavy_Fish_1;
    static public int Heavy_Fish_2;
    static public int Heavy_Fish_3;
    static public int Heavy_Fish_4;
    static public int Heavy_Fish_5;

    static public int Whale_Fish;
    //types
    static public int Whale_Fish_1;
    static public int Whale_Fish_2;
    static public int Whale_Fish_3;

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
    GameObject Inventory_Button;
    GameObject Inventory_Table;

    GameObject Leave_Island_Button;
    private GameObject Button_Market;
    private GameObject Button_Jobs;
    GameObject Market_Menu;
    GameObject Jobs_Menu;
    bool Show_Stuff_Bool;

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

    bool Touching_Special;
    bool Touching_Special1;
    bool Touching_Special2;
    bool Touching_Special3;
    bool Touching_Special4;
    bool Touching_Special5;

    bool Touching_Heavy;
    bool Touching_Heavy1;
    bool Touching_Heavy2;
    bool Touching_Heavy3;
    bool Touching_Heavy4;
    bool Touching_Heavy5;

    bool Touching_Whale;
    bool Touching_Whale1;
    bool Touching_Whale2;
    bool Touching_Whale3;

    void Start()
    {

        Constant_Money = GameObject.Find("/Canvas/Konstnant/Money");
        Constant_Level = GameObject.Find("/Canvas/Konstnant/Level");
        Constant_Time = GameObject.Find("/Canvas/Konstnant/Time");
        Add_Constanst();
        //sea
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Show_Stuff_Bool = false;
            _Capacity = GameObject.Find("/Canvas/Capacity");
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
            Inventory_Button = GameObject.Find("/Canvas/Inventory");
            Inventory_Table = GameObject.Find("/Canvas/Inventory table");

            target = boat.GetComponent<Transform>().position;
            Button_Boat.SetActive(false);
            Button_Main_Island.SetActive(false);
            Button_Basic_Fishing.SetActive(false);
            Button_Heavy_Fishing.SetActive(false);
            Button_Special_Fishing.SetActive(false);
            Button_Whale_Fishing.SetActive(false);
            _Capacity.SetActive(false);
            Inventory_Table.SetActive(false);
        }
        //Main island
        if (SceneManager.GetActiveScene().buildIndex >= 1) 
        {
            Show_Stuff_Bool = false;
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
            Touching_Special_Area();
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
        Inventory_Button.SetActive(false);
        cam.transform.position = new Vector3(0, 0, -10);

        Button_Basic_Fishing.SetActive(false);
        Button_Special_Fishing.SetActive(false);
        Button_Heavy_Fishing.SetActive(false);
        Button_Whale_Fishing.SetActive(false);
        Inventory_Table.SetActive(false);
        _Capacity.SetActive(false);
        Show_Stuff_Bool = false;
    }
    public void Smaller_Cam()
    {
        cam.GetComponent<Camera>().orthographicSize = 7;
        Bigger_Camera = false;
        Button_Map.SetActive(true);
        Button_Boat.SetActive(false);
        Inventory_Button.SetActive(true);

        Button_Basic_Fishing.SetActive(true);

    }
    void Boat_Movement() 
    {
        if (Input.GetMouseButtonDown(0) & Bigger_Camera)
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -700 | Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 2000)
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = 0;
                Special_Boat_Movement();
            }
        }
        boat.transform.position = Vector3.MoveTowards(boat.transform.position, target, Boat_Force);
    }
    void Special_Boat_Movement() 
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
        if (SceneManager.GetActiveScene().buildIndex >= 1) 
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

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //special fish
            if (collision.tag == "Special1")
            {
                Touching_Special1 = true;
                Touching_Special = true;
            }
            else if(collision.tag == "Special2")
            {
                Touching_Special = true;
                Touching_Special2 = true;
            }
            else if(collision.tag == "Special3")
            {
                Touching_Special = true;
                Touching_Special3 = true;
            }
            else if(collision.tag == "Special4")
            {
                Touching_Special = true;
                Touching_Special4 = true;
            }
            else if(collision.tag == "Special5")
            {
                Touching_Special = true;
                Touching_Special5 = true;
            }
            //heavy fish
            if (collision.tag == "Heavy1")
            {
                Touching_Heavy1 = true;
                Touching_Heavy = true;
            }
            else if (collision.tag == "Heavy2")
            {
                Touching_Heavy = true;
                Touching_Heavy2 = true;
            }
            else if (collision.tag == "Heavy3")
            {
                Touching_Heavy = true;
                Touching_Heavy3 = true;
            }
            else if (collision.tag == "Heavy4")
            {
                Touching_Heavy = true;
                Touching_Heavy4 = true;
            }
            else if (collision.tag == "Heavy5")
            {
                Touching_Heavy = true;
                Touching_Heavy5 = true;
            }
            //whale fish
            if (collision.tag == "Whale1")
            {
                Touching_Whale1 = true;
                Touching_Whale = true;
            }
            else if (collision.tag == "Whale2")
            {
                Touching_Whale = true;
                Touching_Whale2 = true;
            }
            else if (collision.tag == "Whale3")
            {
                Touching_Whale = true;
                Touching_Whale3 = true;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex >= 0)
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
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //special fish
            if (collision.tag == "Special1")
            {
                Touching_Special = false;
                Touching_Special1 = false;
            }
            else if (collision.tag == "Special2")
            {
                Touching_Special = false;
                Touching_Special2 = false;
            }
            else if(collision.tag == "Special3")
            {
                Touching_Special = false;
                Touching_Special3 = false;
            }
            else if(collision.tag == "Special4")
            {
                Touching_Special = false;
                Touching_Special4 = false;
            }
            else if(collision.tag == "Special5")
            {
                Touching_Special = false;
                Touching_Special5 = false;
            }
            //heavy fish
            if (collision.tag == "Heavy1")
            {
                Touching_Heavy1 = false;
                Touching_Heavy = false;
            }
            else if (collision.tag == "Heavy2")
            {
                Touching_Heavy = false;
                Touching_Heavy2 = false;
            }
            else if (collision.tag == "Heavy3")
            {
                Touching_Heavy = false;
                Touching_Heavy3 = false;
            }
            else if (collision.tag == "Heavy4")
            {
                Touching_Heavy = false;
                Touching_Heavy4 = false;
            }
            else if (collision.tag == "Heavy5")
            {
                Touching_Heavy = false;
                Touching_Heavy5 = false;
            }
            //whale fish
            if (collision.tag == "Whale1")
            {
                Touching_Whale1 = false;
                Touching_Whale = false;
            }
            else if (collision.tag == "Whale2")
            {
                Touching_Whale = false;
                Touching_Whale2 = false;
            }
            else if (collision.tag == "Whale3")
            {
                Touching_Whale = false;
                Touching_Whale3 = false;
            }
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
            if(Touching_Special1)
            {
                Special_Fish_1 += 1;
            }
            else if (Touching_Special2)
            {
                Special_Fish_2 += 1;
            }
            else if (Touching_Special3)
            {
                Special_Fish_3 += 1;
            }
            else if (Touching_Special4)
            {
                Special_Fish_4 += 1;
            }
            else if (Touching_Special5)
            {
                Special_Fish_5 += 1;
            }
            Special_Fish += 1;
            Actual_Capacity_t -= 0.001;
            _Capacity.GetComponent<Text>().text = "Capacity " + Actual_Capacity_t.ToString("N3") + "/" + Max_Capacity_t.ToString() + " t";
        }
    }
    public void Heavy_Fishing()
    {
        if (Actual_Capacity_t >= 1)
        {
            if (Touching_Heavy1)
            {
                Heavy_Fish_1 += 1;
            }
            else if (Touching_Heavy2)
            {
                Heavy_Fish_2 += 1;
            }
            else if (Touching_Heavy3)
            {
                Heavy_Fish_3 += 1;
            }
            else if (Touching_Heavy4)
            {
                Heavy_Fish_4 += 1;
            }
            else if (Touching_Heavy5)
            {
                Heavy_Fish_5 += 1;
            }
            Heavy_Fish += 1;
            Actual_Capacity_t -= 1;

            _Capacity.GetComponent<Text>().text = "Capacity " + Actual_Capacity_t.ToString("N0") + "/" + Max_Capacity_t.ToString() + " t";
        }
    }
    public void Whale_Fishing()
    {
        if (Actual_Capacity_t >= 25)
        {
            if (Touching_Whale1)
            {
                Whale_Fish_1 += 1;
            }
            else if (Touching_Whale2)
            {
                Whale_Fish_2 += 1;
            }
            else if (Touching_Whale3)
            {
                Whale_Fish_3 += 1;
            }
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
    public void Opening_Inventory() 
    {
        if(Show_Stuff_Bool == false) 
        {
            Inventory_Table.SetActive(true);
            _Capacity.SetActive(true);
            Show_Stuff_Bool = true;

            Debug.Log("Basic fish: "+Basic_Fish);
            Debug.Log("Special fish: "+Special_Fish);
            Debug.Log("Special fish1: " + Special_Fish_1);
            Debug.Log("Special fish2: " + Special_Fish_2);
            Debug.Log("Special fish3: " + Special_Fish_3);
            Debug.Log("Special fish4: " + Special_Fish_4);
            Debug.Log("Special fish5: " + Special_Fish_5);

            Debug.Log("Heavy fish: " + Heavy_Fish);
            Debug.Log("Heavy fish1: " + Heavy_Fish_1);
            Debug.Log("Heavy fish2: " + Heavy_Fish_2);
            Debug.Log("Heavy fish3: " + Heavy_Fish_3);
            Debug.Log("Heavy fish4: " + Heavy_Fish_4);
            Debug.Log("Heavy fish5: " + Heavy_Fish_5);

            Debug.Log("Whale fish: " + Whale_Fish);
            Debug.Log("Whale fish1: " + Whale_Fish_1);
            Debug.Log("Whale fish2: " + Whale_Fish_2);
            Debug.Log("Whale fish3: " + Whale_Fish_3);
        }
        else if (Show_Stuff_Bool)
        {
            Inventory_Table.SetActive(false);
            _Capacity.SetActive(false);
            Show_Stuff_Bool = false;
        }
    }
    void Touching_Special_Area() 
    {
        if (Boat_Level > 0 & Touching_Special & Bigger_Camera == false)
        {
            Button_Special_Fishing.SetActive(true);
        }
        else
        {
            Button_Special_Fishing.SetActive(false);
        }
        if (Boat_Level > 1 & Touching_Heavy & Bigger_Camera == false)
        {
            Button_Heavy_Fishing.SetActive(true);
        }
        else
        {
            Button_Heavy_Fishing.SetActive(false);
        }
        if (Boat_Level > 2 & Touching_Whale & Bigger_Camera == false)
        {
            Button_Whale_Fishing.SetActive(true);
        }
        else
        {
            Button_Whale_Fishing.SetActive(false);
        }
    }
}
