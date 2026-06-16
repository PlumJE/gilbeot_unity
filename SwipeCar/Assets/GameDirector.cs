using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car");
        flag = GameObject.Find("flag");
        distance = GameObject.Find("distance");
    }

    // Update is called once per frame
    void Update()
    {
        float length = flag.transform.position.x - car.transform.position.x;
        if (length >= 0) {
            distance.GetComponent<TextMeshProUGUI>().text = "Distance : " + length.ToString("F2") + "m";
        }
        else {
            distance.GetComponent<TextMeshProUGUI>().text = "GameOver!";
        }
    }
}
