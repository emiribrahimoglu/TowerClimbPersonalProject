using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject platformToSpawn;
    private GameObject lastSpawnedPlatform;

    public Transform topOfTheCamera;

    private int platformsSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlatformSpawnAtLevelStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlatformSpawnAtLevelStart()
    {
        float possibleX = Random.Range(-5.90f, 5.80f);
        float possibleY = Random.Range(-1.2f, 0f);
        Instantiate(platformToSpawn, new Vector3(possibleX, possibleY, 0), Quaternion.identity);
        //possibleX = Random.Range(-5.90f, 5.80f);
        //possibleY = Random.Range(-0.3f, 0.2f);
        //Instantiate(platformToSpawn, new Vector3(possibleX, possibleY, 0), Quaternion.identity);
        possibleX = Random.Range(-5.90f, 5.80f);
        possibleY = Random.Range(2f, 3.5f);
        lastSpawnedPlatform = Instantiate(platformToSpawn, new Vector3(possibleX, possibleY, 0), Quaternion.identity);
    }

    private void PlatformSpawn()
    {
        if (platformsSpawned == 0)
        {
            float lastY = lastSpawnedPlatform.transform.position.y;
            float possibleX = Random.Range(-5.90f, 5.80f);
            float possibleY = Random.Range(lastY + 3f, lastY + 3.7f);
            lastSpawnedPlatform = Instantiate(platformToSpawn, new Vector3(possibleX, possibleY, 0), Quaternion.identity);
        }
        //else
        //{
        //    float lastY = topOfTheCamera.transform.position.y;
        //    float possibleX = Random.Range(-5.90f, 5.80f);
        //    float possibleY = Random.Range(lastY + 2.5f, lastY + 3.2f);
        //    lastSpawnedPlatform = Instantiate(platformToSpawn, new Vector3(possibleX, possibleY, 0), Quaternion.identity);
        //    platformsSpawned++;
        //}
    }

    private void GiveCameraUpwardsSpeed()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            PlatformSpawn();
        }
    }
}
