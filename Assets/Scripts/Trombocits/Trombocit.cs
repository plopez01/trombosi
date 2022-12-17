using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trombocit : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(gameManager.bloodStream.Force, ForceMode2D.Force);
        if (gameManager.ValveOpen)
        {
            rigidbody.drag = gameManager.bloodStream.Drag * (1-gameManager.AnimationPercentage) * (1 - gameManager.AnimationPercentage);
        } else
        {
            rigidbody.drag = gameManager.bloodStream.Drag * gameManager.AnimationPercentage * gameManager.AnimationPercentage;
        }
    }

    public void SetGameManager(GameManager _gm)
    {
        gameManager = _gm;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer") Destroy(gameObject);
    }

}
