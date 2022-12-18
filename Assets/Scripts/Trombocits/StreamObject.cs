using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StreamObject : MonoBehaviour
{
    protected GameManager gameManager;

    protected Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Init();
    }

    protected abstract void Init();


    // Update is called once per frame
    protected void StreamPhysics()
    {
        rigidbody.AddForce(gameManager.bloodStream.Force, ForceMode2D.Force);
        if (gameManager.ValveOpen)
        {
            rigidbody.drag = gameManager.bloodStream.Drag * Mathf.Pow(1 - gameManager.AnimationPercentage, 2) + gameManager.bloodStream.BaseDrag;
        } else
        {
            rigidbody.drag = gameManager.bloodStream.Drag * Mathf.Pow(gameManager.AnimationPercentage, 2) + gameManager.bloodStream.BaseDrag;
        }
    }

    public void SetGameManager(GameManager _gm)
    {
        gameManager = _gm;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer") Destroy(gameObject);
    }
}
