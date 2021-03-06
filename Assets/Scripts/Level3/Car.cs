﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    public GameObject Start_point;
    public GameObject End_point;
    public GameObject Moving_car;
    public GameObject Indian_car;
    public float delta_x, delta_y;
    public Vector3 Start_position, End_position, Car_position;
    public float interval;
    public bool is_moving;
    public bool parked = false;


	// Use this for initialization
	void Start () {
        Indian_car.SetActive(false);
        is_moving = true;
        Start_position = Start_point.transform.position;
        Moving_car.transform.position = Start_position;
        End_position = End_point.transform.position;
        delta_x = (End_position.x - Start_position.x) / 400;
        delta_y = (End_position.y - Start_position.y) / 400;
        this.GetComponent<AudioSource>().Play();
	}

    public void Park_Car()
    {
        //Debug.Log("------------------------------------Parked.");
        this.GetComponent<AudioSource>().Stop();
        GameObject.Find("horn").GetComponent<AudioSource>().Play();
        parked = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (parked)
        {
            //Debug.Log("The car is parked.");
            return;
        }
        Car_position = Moving_car.transform.position;
        if (Car_position.x > End_position.x || Car_position.y > End_position.y) {
            Moving_car.transform.Translate(delta_x, delta_y, 0);
        }
        else
        {
            if (is_moving)
            {
                interval = Random.Range(3f, 7f);
                is_moving = false;
            }
            else
            {
                interval -= Time.deltaTime;
                if (interval < 0)
                {
                    Moving_car.transform.position = Start_position;
                    Moving_car.GetComponent<AudioSource>().Play();
                    int x = Random.Range(0, 9);
                    if (x == 5)
                        Indian_car.SetActive(true);
                    else
                        Indian_car.SetActive(false);
                    is_moving = true;
                }
            }
        }
	}
}
