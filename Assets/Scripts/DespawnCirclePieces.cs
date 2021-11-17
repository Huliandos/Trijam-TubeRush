using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnCirclePieces : MonoBehaviour
{
    Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - playerPosition.position.z <= -15)
            Destroy(gameObject);
    }
}
