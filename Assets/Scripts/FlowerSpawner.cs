using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{

    public float spawnTime;        // The amount of time between each spawn.
    public float spawnDelay;       // The amount of time before spawning starts.
    public GameObject daisyFlower;
    public GameObject pinkFlower;
    public GameObject sunFlower;

    public int minDistance;
    public int maxDistance;
    public Transform playerTransform;

    void Start()
    {
        StartCoroutine(SpawnTimeDelay());
    }

    IEnumerator SpawnTimeDelay()
    {
        while (true)
        {
            var flowerTransform = new Vector3(playerTransform.position.x + Random.Range(minDistance, maxDistance), playerTransform.position.y + Random.Range(minDistance, maxDistance), playerTransform.position.z);

            var randomFlower = GetRandomFlower();

            Instantiate(randomFlower, flowerTransform, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private GameObject GetRandomFlower()
    {
        var flowerSelected = (FlowerTypes)Random.Range(0, 3);

        switch (flowerSelected)
        {
            case FlowerTypes.DaisyFlower:
                return daisyFlower;
            case FlowerTypes.PinkFlower:
                return pinkFlower;
            case FlowerTypes.SunFlower:
            default:
                return sunFlower;
        }
    }
}