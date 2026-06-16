using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) {
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;

            if (swipeLength > 0) {
                speed = swipeLength / 500.0f;
            }
            else if (transform.position.x > 7.5f) {
                speed = 0;
            }

            GetComponent<AudioSource>().Play();
        }

        if (-7.0f <= transform.position.x && transform.position.x <= 7.5f) {
            transform.Translate(speed, 0, 0);
        }
        speed *= 0.98f;
    }

    public void resetCar() {
        transform.position = new Vector3(-7.0f, -3.7f, 0);
        speed = 0;
    }
}
