using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trombocit : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rigidbody;

    bool stuck = false;

    private Vector2 stuckPos;

    private float stuckDrag = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if we are stuck to another trombocit

        if (stuck)
        {
            rigidbody.AddForce((gameManager.TromboPosition - transform.position) * gameManager.StickForceMultiplier);
            // If we are stuck to a wall, check if distance is too great, if it is, unstuck it
            if (Vector2.Distance(stuckPos, transform.localPosition) >= gameManager.BreakDistance)
            {
                stuck = false;
            }
        }

        rigidbody.AddForce(gameManager.bloodStream.Force, ForceMode2D.Force);
        if (gameManager.ValveOpen)
        {
            rigidbody.drag = gameManager.bloodStream.Drag * Mathf.Pow(1-gameManager.AnimationPercentage, 2) + gameManager.bloodStream.BaseDrag + stuckDrag;
        } else
        {
            rigidbody.drag = gameManager.bloodStream.Drag * Mathf.Pow(gameManager.AnimationPercentage, 2) + gameManager.bloodStream.BaseDrag + stuckDrag;
        }
    }

    public void SetGameManager(GameManager _gm)
    {
        gameManager = _gm;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sticky" && !stuck)
        {
            if (Random.Range(0f, 1f) <= gameManager.StickChance)
            {
                stuck = true;
                stuckPos = transform.localPosition;
            }
        }

        if (collision.gameObject.tag == "Trombocit" && !stuck)
        {
            Trombocit _trombo = collision.gameObject.GetComponent<Trombocit>();
            if (_trombo.stuck)
            {
                stuck = true;
                stuckPos = transform.localPosition;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer") Destroy(gameObject);
    }

}
