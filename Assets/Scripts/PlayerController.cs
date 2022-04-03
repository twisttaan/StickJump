using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public _Muscle[] muscles;
    private GameManager gameManager;
    public bool ragdoll = false;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    IEnumerator Jump()
    {
        if (ragdoll) yield break;

        foreach (var muscle in muscles)
        {
            muscle.Jump();
        }
    }


    private void Update()
    {
        if (!ragdoll)
        {
            foreach (_Muscle muscle in muscles)
            {
                muscle.ActivateMuscle();
            }
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (gameManager.inGame)
                {
                    print("Jumping!");
                    StartCoroutine(Jump());
                }
            }
        }

        if (gameManager.inGame)
        {
            muscles[0].bone.AddForce(new Vector2(15, 0));
        }
    }
}
[System.Serializable]
public class _Muscle
{
    public Rigidbody2D bone;
    public float restRotation;
    public float force;

    public void ActivateMuscle()
    {
        bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restRotation, force * Time.deltaTime));
    }

    public void Jump()
    {
        bone.AddForce(new Vector2(0, 510));
    }
}