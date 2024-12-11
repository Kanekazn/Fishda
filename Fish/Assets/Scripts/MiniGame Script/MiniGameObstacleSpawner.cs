using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.VersionControl.Message;
using static UnityEngine.UIElements.UxmlAttributeDescription;


public class MiniGameObstacleSpawner : MonoBehaviour
{
    public GameObject rock;
    public GameObject box;
    public int spawnRate = 2;
    private float timer = 0;

    void Update()
    {
        int randomSpawn = UnityEngine.Random.Range(spawnRate, 4);

        if (timer < randomSpawn)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Spawn();
            timer = 0;
        }

       // Debug.Log("random generator: " + randomSpawn);
    }

    void Spawn()
    {
        int randomObstacle = UnityEngine.Random.Range(0, 2);
        //Debug.Log("random generator: " + randomObstacle);

        GameObject selectedObstacle = null;

        if (randomObstacle == 0)
        {
            selectedObstacle = rock;
        }
            
        else if (randomObstacle == 1)
        {
            selectedObstacle = box;
            
        }

        Instantiate(selectedObstacle, new Vector3(transform.position.x, UnityEngine.Random.Range(5, -5), 0), transform.rotation);
    }
}
