using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fishing : MonoBehaviour
{
    public static int fishingType = 13;
    /*
    0 = basic
    1 = special1
    2 = special2
    3 = special3
    4 = special4
    5 = special5
    6 = heavy1
    7 = heavy2
    8 = heavy3
    9 = heavy4
    10 = heavy5
    11 = whale1
    12 = whale2
    13 = whale3
     */
    GameObject clickButton;
    GameObject clickFastButton;
    GameObject text;
    GameObject text1;
    GameObject backButton;
    int clicks;
    float force = 0;
    float value = 0;
    float direction;
    float time;
    bool moving = false;
    bool clicking = false;
    int needClicks = 10;
    int _case;
    // Start is called before the first frame update
    void Start()
    {
        clickButton = GameObject.Find("/Canvas/Click");
        clickFastButton = GameObject.Find("/Canvas/ClickFast");
        backButton = GameObject.Find("/Canvas/Back");
        text = GameObject.Find("/Canvas/Text");
        text1 = GameObject.Find("/Canvas/Text1");

        clickFastButton.SetActive(false);
        backButton.SetActive(false);
        text.SetActive(false);
        text1.SetActive(false);

        clickButton.GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(-300,300),Random.Range(-205, 205));

        direction = Random.Range(1, 5);
        time = Random.Range(0.1F, 0.5F);

        switch (fishingType)
        {
            case 0:
                needClicks = 6;
                break;
            case 1:
                force = 300;
                moving = true;
                needClicks = 7;
                _case = 1;
                break;
            case 2:
                force = 400;
                moving = true;
                needClicks = 8;
                _case = 1;
                break;
            case 3:
                force = 500;
                moving = true;
                needClicks = 9;
                _case = 1;
                break;
            case 4:
                force = 600;
                moving = true;
                needClicks = 10;
                _case = 1;
                break;
            case 5:
                force = 700;
                moving = true;
                needClicks = 11;
                _case = 1;
                break;
            case 6:
                force = 150;
                moving = true;
                needClicks = 12;
                _case = 2;
                break;
            case 7:
                force = 200;
                moving = true;
                needClicks = 13;
                _case = 2;
                break;
            case 8:
                force = 250;
                moving = true;
                needClicks = 14;
                _case = 2;
                break;
            case 9:
                force = 300;
                moving = true;
                needClicks = 15;
                _case = 2;
                break;
            case 10:
                force = 350;
                moving = true;
                needClicks = 16;
                _case = 2;
                break;
            case 11:
                time = 1;
                moving = true;
                needClicks = 17;
                _case = 3;
                break;
            case 12:
                time = 0.7F;
                moving = true;
                needClicks = 18;
                _case = 3;
                break;
            case 13:
                time = 0.5F;
                moving = true;
                needClicks = 20;
                _case = 3;
                break;
        }
        value = force;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            switch (_case)
            {
                case 1:
                    ButtonMoving1();
                    break;
                case 2:
                    ButtonMoving2();
                    break;
                case 3:
                    ButtonMoving3();
                    break;
            }
        }
        else if(clicking)
        {
            ButtonClicking();
        }
    }
    public void Click()
    {
        clickButton.SetActive(false);
        clickFastButton.SetActive(true);
        time = 5;
        moving = false;
        clicking = true;
    }
    public void FastClick()
    {
        clicks++;
    }
    void ButtonMoving1()
    {
        if (clickButton.GetComponent<RectTransform>().localPosition.x >350)
        {
            force = -value;
        }
        if (clickButton.GetComponent<RectTransform>().localPosition.x < -350)
        {
            force = value;
        }
        clickButton.GetComponent<RectTransform>().localPosition = new Vector3(clickButton.GetComponent<RectTransform>().localPosition.x + (Time.deltaTime * force), 0);
    }
    void ButtonMoving2()
    {
        if (clickButton.GetComponent<RectTransform>().localPosition.x > 350)
        {
            direction = 3;
            time = Random.Range(0.1F, 1F);
        }
        if (clickButton.GetComponent<RectTransform>().localPosition.x < -350)
        {
            direction = 4;
            time = Random.Range(0.1F, 1F);
        }
        if (clickButton.GetComponent<RectTransform>().localPosition.y > 205)
        {
            direction = 2;
            time = Random.Range(0.1F, 1F);
        }
        if (clickButton.GetComponent<RectTransform>().localPosition.y < -205)
        {
            direction = 1;
            time = Random.Range(0.1F, 1F);
        }
        if (direction == 1)
        {
            //up
            if (time > 0)
            {
                clickButton.GetComponent<RectTransform>().localPosition = new Vector3(clickButton.GetComponent<RectTransform>().localPosition.x, clickButton.GetComponent<RectTransform>().localPosition.y + (Time.deltaTime * force));
                time -= Time.deltaTime;
            }
            else
            {
                time = Random.Range(0.1F, 0.5F);
                direction = Random.Range(1, 5);
            }
        }
        else if (direction == 2)
        {
            //down
            if (time > 0)
            {
                clickButton.GetComponent<RectTransform>().localPosition = new Vector3(clickButton.GetComponent<RectTransform>().localPosition.x, clickButton.GetComponent<RectTransform>().localPosition.y + (Time.deltaTime * -force));
                time -= Time.deltaTime;
            }
            else
            {
                time = Random.Range(0.1F, 0.5F);
                direction = Random.Range(1, 5);
            }
        }
        else if (direction == 3)
        {
            //left
            if (time > 0)
            {
                clickButton.GetComponent<RectTransform>().localPosition = new Vector3(clickButton.GetComponent<RectTransform>().localPosition.x + (Time.deltaTime * -force), clickButton.GetComponent<RectTransform>().localPosition.y);
                time -= Time.deltaTime;
            }
            else
            {
                time = Random.Range(0.1F, 0.5F);
                direction = Random.Range(1, 5);
            }
        }
        else if (direction == 4)
        {
            //right
            if (time > 0)
            {
                clickButton.GetComponent<RectTransform>().localPosition = new Vector3(clickButton.GetComponent<RectTransform>().localPosition.x + (Time.deltaTime * force), clickButton.GetComponent<RectTransform>().localPosition.y);
                time -= Time.deltaTime;
            }
            else
            {
                time = Random.Range(0.1F, 0.5F);
                direction = Random.Range(1, 5);
            }
        }
    }
    void ButtonMoving3()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            clickButton.GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(-300, 300), Random.Range(-205, 205));
            time = 0.5F;
        }
    }

    void ButtonClicking()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        if (clicks >= needClicks)
        {
            text1.SetActive(true);
            switch (fishingType)
            {
                case 0:
                    Controller_Script.Basic_Fish += 1;
                    break;
                case 1:
                    Controller_Script.Special_Fish1 += 1;
                    break;
                case 2:
                    Controller_Script.Special_Fish2 += 1;
                    break;
                case 3:
                    Controller_Script.Special_Fish3 += 1;
                    break;
                case 4:
                    Controller_Script.Special_Fish4 += 1;
                    break;
                case 5:
                    Controller_Script.Special_Fish5 += 1;
                    break;
                case 6:
                    Controller_Script.Heavy_Fish1 += 1;
                    break;
                case 7:
                    Controller_Script.Heavy_Fish2 += 1;
                    break;
                case 8:
                    Controller_Script.Heavy_Fish3 += 1;
                    break;
                case 9:
                    Controller_Script.Heavy_Fish4 += 1;
                    break;
                case 10:
                    Controller_Script.Heavy_Fish5 += 1;
                    break;
                case 11:
                    Controller_Script.Whale_Fish1 += 1;
                    break;
                case 12:
                    Controller_Script.Whale_Fish2 += 1;
                    break;
                case 13:
                    Controller_Script.Whale_Fish3 += 1;
                    break;
            }
            clicking = false;
            clicks = 0;
            clickFastButton.SetActive(false);
            backButton.SetActive(true);
        }
        if(time <= 0)
        {
            if (clicks < needClicks)
            {
                Debug.Log(clicks);
                text.SetActive(true);
            }
            clicking = false; 
            clicks = 0;
            clickFastButton.SetActive(false);
            backButton.SetActive(true);
        }
    }
    public void Back()
    {
        SceneManager.LoadScene(9);
    }
}
