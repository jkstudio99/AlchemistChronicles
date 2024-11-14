using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloudGenerator : MonoBehaviour
{
    public GameObject[] clouds;
    public float spawnInterval;
    public GameObject endPoint;
    Vector3 startPos;

     void Start()
    {
        //Assign the position to the object
        startPos = transform.position;
        PrewarmCloud();
        Invoke("AttemptSpawn", spawnInterval);
    }

    void SpawnCloud(Vector3 startPos)
    {
        //Create a random index
        int randomIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex]);
        //Create a random vertical range (y)
        float startPosY = UnityEngine.Random.Range(startPos.y - 1f, startPos.y + 15f);
        cloud.transform.position = new Vector3(startPos.x, startPosY, startPos.z);
        //Create random scale clouds
        float scale = UnityEngine.Random.Range(0.5f, 1f);
        cloud.transform.localScale = new Vector2(scale, scale);
        //Create a random speed
        float speed = UnityEngine.Random.Range(0.7f, 1.6f);
        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);
    }
    void AttemptSpawn()
    {
        //Check some things
        SpawnCloud(startPos);

        Invoke("AttemptSpawn", spawnInterval);
    }

    //Creating clouds at the start of the game
    void PrewarmCloud()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 15);
            SpawnCloud(spawnPos);
        }
    }
}
