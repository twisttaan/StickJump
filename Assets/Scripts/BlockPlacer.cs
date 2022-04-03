

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    public float spawnRate = 1.5f;

    private Transform pTransform;

    public Transform rightLeg;

    private float nextSpawn = 0.0f;

    void Start()
    {
        pTransform = GetComponent<Transform>();
    }

    void Update()
    {
        // This script is attached to the player, so we can access the player's location
        // We can use this to spawn blocks in front of the player using magic ai and raycasting
        // The player jumps from block to block, so we always need to have a block in front of the player to parkour
        // So make sure there is a couple of random blockPrefab's infront of the player ready for the player to jump on

        Random.InitState(System.DateTime.Now.Millisecond);


        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            GameObject randomBlock = blockPrefabs[randomIndex];

            // Spawn the block in front of the player at leg level from a random distance and at a random height, make sure it is not too close to the player

            Vector2 spawnPosition = new Vector2(pTransform.position.x + Random.Range(10, 30), rightLeg.position.y - Random.Range(2, 4));

            // make sure there isnt already a block in a circle radius of the spawn position
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, Random.Range(2, 5));
            bool clear = true;
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Block")
                {
                    clear = false;
                }
            }
            if (clear)
            {
                Instantiate(randomBlock, spawnPosition, Quaternion.identity);
            }
        }
    }
}
