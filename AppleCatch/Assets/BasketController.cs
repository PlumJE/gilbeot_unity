using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        aud = GetComponent<AudioSource>();
        director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            float x = Mathf.RoundToInt(hit.point.x);
            float z = Mathf.RoundToInt(hit.point.z);
            transform.position = new Vector3(x, 0, z);
        }
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Apple") {
            aud.PlayOneShot(appleSE);
            director.GetComponent<GameDirector>().GetApple();
        }
        else {
            aud.PlayOneShot(bombSE);
            director.GetComponent<GameDirector>().GetBomb();
        }
        Destroy(other.gameObject);
    }
}
