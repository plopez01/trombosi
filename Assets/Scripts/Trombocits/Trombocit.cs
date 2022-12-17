using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trombocit : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rigidbody;

    private bool stuckWall = false;
    private bool stuckOther = false;
    private bool canStick = false;

    private Transform stickedTo;

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
        // Check if we are stuck to another trombocit
        if (stuckOther && stickedTo != null)
        {
            // If we are add stuck force
            rigidbody.AddForce((stickedTo.transform.position - transform.position) * gameManager.StickForceMultiplier);

            // If distance is too great break stuck
            if (Vector2.Distance(stickedTo.position, transform.position) >= gameManager.BreakDistance)
            {
                stuckOther = false;
                canStick = false;
            }
            return;
        }
        if (stuckWall)
        {
            // If we are stuck to a wall, check if distance is too great, if it is, unstuck it
            if (Vector2.Distance(stuckPos, transform.localPosition) >= gameManager.BreakDistance)
            {
                stuckWall = false;
                canStick = false;
                stuckDrag = 0;
            }
            return;
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
        if (collision.gameObject.tag == "Sticky" && !stuckWall)
        {
            if (Random.Range(0f, 1f) <= gameManager.StickChance)
            {
                transform.SetParent(collision.transform);
                rigidbody.drag = 100;
                stuckWall = true;
                canStick = true;
                stuckPos = transform.localPosition;
            }
        }

        if (collision.gameObject.tag == "Trombocit" && !stuckOther)
        {
            Trombocit _trombo = collision.gameObject.GetComponent<Trombocit>();
            if (_trombo.canStick)
            {
                canStick = true;
                stuckOther = true;
                stickedTo = collision.transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer") Destroy(gameObject);
    }

}
