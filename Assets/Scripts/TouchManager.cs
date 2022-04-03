using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public GameManager gameManager;

    private PlayerController player;

    void Start()
    {
        player = GameObject.Find("Jerry").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!gameManager.inGame)
                {
                    gameManager.StartGame(); return;
                }

                player.muscles[0].bone.AddForce(new Vector2(0, 15));


            }
        }
    }
}
