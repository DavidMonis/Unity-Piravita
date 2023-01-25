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
            small_boat = GameObject.Find("/Boat/Boat 1");
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

        }
        if (collision.tag == "Soldier")
        {
            Soldier_Movement.Soldier_Moving_Bool = true;
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

        }
    }
}
