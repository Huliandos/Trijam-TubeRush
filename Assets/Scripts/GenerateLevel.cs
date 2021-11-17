using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField]
    GameObject circlePrefab, lightPrefab;

    [SerializeField]
    Transform playerPos;

    [SerializeField]
    Material deathZoneMat;

    float lastZPosition = 31.72f;

    bool angle = false;

    int obstacleSpawnNumber = 1, obstacleSpawnFrequenzy = 5, obstacleSpawnedCounter = 4;

    GameObject obstacle;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastZPosition - playerPos.transform.position.z < 35)
        {
            lastZPosition += 3;

            if (angle) {
                obstacle = Instantiate(circlePrefab, new Vector3(0, 0, lastZPosition), Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 45)), transform);
                angle = false;
            }
            else
            {
                obstacle = Instantiate(circlePrefab, new Vector3(0, 0, lastZPosition), Quaternion.Euler(transform.eulerAngles), transform);
                angle = true;
            }


            obstacleSpawnedCounter++;
            if (obstacleSpawnFrequenzy == obstacleSpawnedCounter) {
                obstacleSpawnedCounter = 0;

                int[] spawnLocations = new int[obstacleSpawnNumber];
                for(int i=0; i<obstacleSpawnNumber; i++) {
                    int rand = Random.Range(0, 7);

                    spawnLocations[i] = rand;
                }

                for(int i=0; i<spawnLocations.Length; i++) {
                    obstacle.GetComponentsInChildren<CurvedWorld>()[spawnLocations[i]].GetComponent<Renderer>().material = deathZoneMat;
                    obstacle.GetComponentsInChildren<CurvedWorld>()[spawnLocations[i]].gameObject.tag = Tags.deathZone;
                    Instantiate(lightPrefab, obstacle.GetComponentsInChildren<CurvedWorld>()[spawnLocations[i]].transform);
                }
            }
        }

        if (time >= 15 && obstacleSpawnNumber < 5) {
            time -= time;

            obstacleSpawnNumber++;
        }

        time += Time.deltaTime;

    }
}
