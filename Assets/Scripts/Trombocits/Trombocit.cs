using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trombocit : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Vector2 initialForce;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(initialForce, ForceMode2D.Impulse);
        if (!gameManager.ValveOpen)
        {
            rigidbody.drag = gameManager.Drag;
        } else
        {
            rigidbody.drag = 0;
        }
    }

    public void SetGameManager(GameManager _gm)
    {
        gameManager = _gm;
    }
}
