using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    float speed = 1f;
    Rigidbody rb;

    [SerializeField]
    GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed += Time.deltaTime / 100;


        if (!Canvas.activeSelf)
        {
            if (Input.GetAxis("Horizontal") < 0)
                transform.Rotate(Vector3.forward, -speed);
            //rb.MoveRotation(Quaternion.Euler(transform.eulerAngles + Vector3.forward * speed));
            else if (Input.GetAxis("Horizontal") > 0)
                transform.Rotate(Vector3.forward, speed);
            //rb.MoveRotation(Quaternion.Euler(transform.eulerAngles - Vector3.forward * speed));
        }
    }
}
