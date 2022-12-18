using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trombocit : StreamObject
{
    [HideInInspector] public bool stuck = false;

    [HideInInspector] public bool canStuck = true;

    private Vector2 stuckPos;

    // Update is called once per frame
    void Update()
    {
        //Check if we are stuck to another trombocit        
        if (stuck && canStuck)
        {
            rigidbody.AddForce((gameManager.TromboPosition - transform.position) * gameManager.StickForceMultiplier);
            // If we are stuck to a wall, check if distance is too great, if it is, unstuck it
            if (Vector2.Distance(stuckPos, transform.localPosition) >= gameManager.BreakDistance)
            {
                stuck = false;
            }
        }

        StreamPhysics();
    }


    protected override void Init()
    {

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
            if (Random.Range(0f, 1f) <= gameManager.StickChance)
            {
                Trombocit _trombo = collision.gameObject.GetComponent<Trombocit>();
                if (_trombo.stuck)
                {
                    stuck = true;
                    stuckPos = transform.localPosition;
                }
            }
        }
    }
}
