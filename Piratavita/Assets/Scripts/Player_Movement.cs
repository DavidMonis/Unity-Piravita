using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    GameObject small_boat;
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            string name = "/Boat/Boat 1/Boat_LVL";
            name += Controller_Script.Boat_Level.ToString();
            small_boat = GameObject.Find(name);
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.GetKey(KeyCode.D) & small_boat.GetComponent<Transform>().position.x + 9 > GetComponent<Transform>().position.x)
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + Controller_Script.force * Time.deltaTime, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.A) & small_boat.GetComponent<Transform>().position.x - 9 < GetComponent<Transform>().position.x)
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - Controller_Script.force * Time.deltaTime, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.W) & small_boat.GetComponent<Transform>().position.y + 23 > GetComponent<Transform>().position.y)
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + Controller_Script.force * Time.deltaTime, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.S) & small_boat.GetComponent<Transform>().position.y - 23 < GetComponent<Transform>().position.y)
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - Controller_Script.force * Time.deltaTime, GetComponent<Transform>().position.z);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            //zmenit
            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + Controller_Script.force * Time.deltaTime, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - Controller_Script.force * Time.deltaTime, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + Controller_Script.force * Time.deltaTime, GetComponent<Transform>().position.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - Controller_Script.force * Time.deltaTime, GetComponent<Transform>().position.z);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            if (collision.name == "Market")
            {
                Controller_Script.Standing_On_Market = true;
                Controller_Script.Button_Market.SetActive(true);
            }
            if (collision.name == "Pub")
            {
                Controller_Script.Button_Pub.SetActive(true);
                Controller_Script.Standing_On_Pub = true;

            }

        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (collision.tag == "Boat_Border")
            {
                Controller_Script.Touching_Basic = true;
            }
            //special fish
            if (collision.tag == "Special1")
            {
                Controller_Script.Touching_Special1 = true;
                Controller_Script.Touching_Special = true;
            }
            else if (collision.tag == "Special2")
            {
                Controller_Script.Touching_Special = true;
                Controller_Script.Touching_Special2 = true;
            }
            else if (collision.tag == "Special3")
            {
                Controller_Script.Touching_Special = true;
                Controller_Script.Touching_Special3 = true;
            }
            else if (collision.tag == "Special4")
            {
                Controller_Script.Touching_Special = true;
                Controller_Script.Touching_Special4 = true;
            }
            else if (collision.tag == "Special5")
            {
                Controller_Script.Touching_Special = true;
                Controller_Script.Touching_Special5 = true;
            }
            //heavy fish
            if (collision.tag == "Heavy1")
            {
                Controller_Script.Touching_Heavy1 = true;
                Controller_Script.Touching_Heavy = true;
            }
            else if (collision.tag == "Heavy2")
            {
                Controller_Script.Touching_Heavy = true;
                Controller_Script.Touching_Heavy2 = true;
            }
            else if (collision.tag == "Heavy3")
            {
                Controller_Script.Touching_Heavy = true;
                Controller_Script.Touching_Heavy3 = true;
            }
            else if (collision.tag == "Heavy4")
            {
                Controller_Script.Touching_Heavy = true;
                Controller_Script.Touching_Heavy4 = true;
            }
            else if (collision.tag == "Heavy5")
            {
                Controller_Script.Touching_Heavy = true;
                Controller_Script.Touching_Heavy5 = true;
            }
            //whale fish
            if (collision.tag == "Whale1")
            {
                Controller_Script.Touching_Whale1 = true;
                Controller_Script.Touching_Whale = true;
            }
            else if (collision.tag == "Whale2")
            {
                Controller_Script.Touching_Whale = true;
                Controller_Script.Touching_Whale2 = true;
            }
            else if (collision.tag == "Whale3")
            {
                Controller_Script.Touching_Whale = true;
                Controller_Script.Touching_Whale3 = true;
            }
        }
        if (collision.tag == "Soldier")
        {
            Soldier_Movement.Soldier_Moving_Bool = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (collision.tag == "Boat_Border")
            {
                Controller_Script.Touching_Basic = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex >= 0)
        {
            if (collision.name == "Market")
            {
                Controller_Script.Standing_On_Market = false;
                Controller_Script.Button_Market.SetActive(false);
                Controller_Script.Market_Menu.SetActive(false);
                Controller_Script.Button_Market2.SetActive(false);
            }
            if (collision.name == "Pub")
            {
                Controller_Script.Button_Pub.SetActive(false);
                Controller_Script.Panel_Pub.SetActive(false);
                Controller_Script.Standing_On_Pub = false;
                Controller_Script.random2 = false;
            }
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                if (collision.tag == "Boat_Border")
                {
                    Controller_Script.Touching_Basic = false;
                }
                //special fish
                if (collision.tag == "Special1")
                {
                    Controller_Script.Touching_Special = false;
                    Controller_Script.Touching_Special1 = false;
                }
                else if (collision.tag == "Special2")
                {
                    Controller_Script.Touching_Special = false;
                    Controller_Script.Touching_Special2 = false;
                }
                else if (collision.tag == "Special3")
                {
                    Controller_Script.Touching_Special = false;
                    Controller_Script.Touching_Special3 = false;
                }
                else if (collision.tag == "Special4")
                {
                    Controller_Script.Touching_Special = false;
                    Controller_Script.Touching_Special4 = false;
                }
                else if (collision.tag == "Special5")
                {
                    Controller_Script.Touching_Special = false;
                    Controller_Script.Touching_Special5 = false;
                }
                //heavy fish
                if (collision.tag == "Heavy1")
                {
                    Controller_Script.Touching_Heavy1 = false;
                    Controller_Script.Touching_Heavy = false;
                }
                else if (collision.tag == "Heavy2")
                {
                    Controller_Script.Touching_Heavy = false;
                    Controller_Script.Touching_Heavy2 = false;
                }
                else if (collision.tag == "Heavy3")
                {
                    Controller_Script.Touching_Heavy = false;
                    Controller_Script.Touching_Heavy3 = false;
                }
                else if (collision.tag == "Heavy4")
                {
                    Controller_Script.Touching_Heavy = false;
                    Controller_Script.Touching_Heavy4 = false;
                }
                else if (collision.tag == "Heavy5")
                {
                    Controller_Script.Touching_Heavy = false;
                    Controller_Script.Touching_Heavy5 = false;
                }
                //whale fish
                if (collision.tag == "Whale1")
                {
                    Controller_Script.Touching_Whale1 = false;
                    Controller_Script.Touching_Whale = false;
                }
                else if (collision.tag == "Whale2")
                {
                    Controller_Script.Touching_Whale = false;
                    Controller_Script.Touching_Whale2 = false;
                }
                else if (collision.tag == "Whale3")
                {
                    Controller_Script.Touching_Whale = false;
                    Controller_Script.Touching_Whale3 = false;
                }
            }
        }
    }
}
