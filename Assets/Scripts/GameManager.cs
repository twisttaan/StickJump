using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
}
