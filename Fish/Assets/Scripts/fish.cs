using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    public List<Transform> spawnLeftLocation = new List<Transform>();
    public List<Transform> spawnRightLocation = new List<Transform>();
    public GameObject fish1;
    public GameObject fish2;
    public GameObject fish3; // Currently unused fish3, you can add later

    public int target = 20;
    public float timer;

    // Update is called once per frame
    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Random.Range(2f, 5f) && target > 0) // Ensure target > 0 to prevent negative spawning
        {
            SpawnFish();
            timer = 0f;
            target--;
        }
    }

    public void SpawnFish()
    {
        bool isSpawnedOnLeft = Random.Range(0, 2) == 0;

        Transform spawnLocation;
        Transform endLocation;

        // Determine spawn location
        if (isSpawnedOnLeft)
        {
            spawnLocation = spawnLeftLocation[Random.Range(0, spawnLeftLocation.Count)];
            endLocation = spawnRightLocation[Random.Range(0, spawnRightLocation.Count)];
        }
        else
        {
            spawnLocation = spawnRightLocation[Random.Range(0, spawnRightLocation.Count)];
            endLocation = spawnLeftLocation[Random.Range(0, spawnLeftLocation.Count)];
        }

       
       GameObject spawnedFish = Random.Range(0, 2) == 0 ? Instantiate(fish1, spawnLocation.position, Quaternion.identity) : Instantiate(fish2, spawnLocation.position, Quaternion.identity);

        
        FishMovement fishMovement = spawnedFish.GetComponent<FishMovement>();
        if (fishMovement != null)
        {
            
            fishMovement.SetEndLocation(endLocation);

            
            fishMovement.MoveFishToTarget();
        }
        else
        {
            Debug.LogError("FishMovement script is missing on the fish prefab!");
        }
    }


}



