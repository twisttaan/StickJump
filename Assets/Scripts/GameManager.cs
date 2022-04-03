using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pillarPrefab;
    public Transform topSpawnPoint;
    public Transform bottomSpawnPoint;
    public GameObject startingGround;

    public float spawnRate = 1.5f;
    public bool inGame = false;

    private float nextSpawn = 0.0f;
    void Start()
    {
        startingGround = Instantiate(startingGround, new Vector3(0, -5, 0), Quaternion.identity);
    }

    public void StartGame()
    {
        inGame = true;
        startingGround.AddComponent<SlideScript>();
    }

    void Update()
    {
        if (!inGame) return;

        if (Time.time > nextSpawn)
        {
            Random.InitState(System.DateTime.Now.Millisecond);

            if (Random.Range(0, 2) == 1)
            {
                float bSpawnY = Random.Range(bottomSpawnPoint.position.y, bottomSpawnPoint.position.y * 1.5f);
                float tSpawnY = Random.Range(topSpawnPoint.position.y, topSpawnPoint.position.y * 1.5f);

                Instantiate(pillarPrefab, new Vector3(topSpawnPoint.position.x, tSpawnY, 0), Quaternion.identity);
                Instantiate(pillarPrefab, new Vector3(bottomSpawnPoint.position.x, bSpawnY, 0), Quaternion.identity);
            }
            else
            {
                float spawnY = Random.Range(bottomSpawnPoint.position.y, bottomSpawnPoint.position.y * 1.5f);

                Instantiate(pillarPrefab, new Vector3(topSpawnPoint.position.x, spawnY, 0), Quaternion.identity);
            }


            nextSpawn = Time.time + spawnRate;
        }
    }
}
