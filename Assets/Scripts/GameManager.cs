using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Range(0.1f, 4)] private float pulseInterval;

    [SerializeField] private int tromboAmount = 20;

    [SerializeField, Range(1, 10)] private float closedDrag;

    [SerializeField] private Animator valveAnimator;

    [SerializeField] private TromboSpawner tromboSpawner;

    private float timer = 0;
    private bool valveOpen = false;

    public float Drag
    {
        get { return closedDrag; }
    }

    public bool ValveOpen
    {
        get { return valveOpen; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        valveAnimator.speed = 1 / pulseInterval;
        if (Time.unscaledTime - timer >= pulseInterval)
        {
            timer = Time.unscaledTime;
            valveOpen = !valveOpen;

            if (!valveOpen)
            {
                tromboSpawner.Spawn(tromboAmount, this);
            }
            valveAnimator.SetBool("Open", valveOpen);
            Debug.Log("Valve open: " + valveOpen);
        }
    }
}
