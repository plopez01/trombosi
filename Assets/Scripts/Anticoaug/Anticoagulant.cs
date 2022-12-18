using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anticoagulant : StreamObject
{
    private SpriteRenderer spriteRenderer;

    private int penetration;

    private float effectivity;

    bool targeted;

    private float targetForce;

    protected override void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        StreamPhysics();
    }


    public void LoadData(AnticoagulantData data)
    {
        spriteRenderer.color = data.color;
        name = data.name;
        penetration = data.penetration;
        effectivity = data.effectivity;
        targeted = data.onlyAffectStuck;

        if (data.active)
        {
            CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();
            collider.radius = data.targetRange;
            collider.isTrigger = true;
            targetForce = data.force;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trombocit")
        {
            if (Random.Range(0f, 1f) <= effectivity)
            {
                Trombocit _trombo = collision.gameObject.GetComponent<Trombocit>();
                if (targeted || _trombo.stuck)
                {
                    _trombo.canStuck = false;
                    _trombo.stuck = false;
                    penetration--;
                }
                if (penetration == 0) Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Trombocit")
        {
            Trombocit _trombo = collision.gameObject.GetComponent<Trombocit>();
            if (targeted || _trombo.stuck)
            {
                rigidbody.AddForce((gameManager.TromboPosition - transform.position) * targetForce);
            }
        }
    }
}
