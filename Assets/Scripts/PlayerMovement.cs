using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float totalTimeSurvived = 0;

    float speed = 0.05f;
    Rigidbody rb;

    [SerializeField]
    Text text;

    bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            speed += Time.deltaTime / 100;
            //rb.MovePosition(transform.position + transform.forward * speed);
            transform.position = transform.position + transform.forward * speed;
            //rb.velocity = transform.forward * speed;

            totalTimeSurvived += Time.deltaTime;
        }
        else {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(0);
            else if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.deathZone)
        {
            moving = false;

            totalTimeSurvived = (float)(int)totalTimeSurvived * 100;
            totalTimeSurvived /= 100;

            text.transform.root.gameObject.SetActive(true);
            text.text = "You survived for: " + totalTimeSurvived + " Seconds";
        }
    }
}
