using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Range(0.1f, 4)] private float pulseInterval;

    [SerializeField] private float intervalDelay;

    [SerializeField] private int tromboAmount = 20;

    [SerializeField] private Animator valveAnimator;

    [SerializeField] private TromboSpawner tromboSpawner;

    private BloodStream _bloodStream;

    private float timer = 0;
    private float delayTimer = 0;
    private bool valveOpen = false;



    public BloodStream bloodStream
    {
        get { return _bloodStream; }
    }

    public bool ValveOpen
    {
        get { return valveOpen; }
    }

    public float AnimationPercentage
    {
        get { return (Time.unscaledTime - timer) / pulseInterval; }
    }


    // Start is called before the first frame update
    void Start()
    {
        _bloodStream = GetComponent<BloodStream>();
    }

    // Update is called once per frame
    void Update()
    {
        valveAnimator.speed = 1 / pulseInterval;
        if (Time.unscaledTime - delayTimer >= intervalDelay)
        {
            delayTimer = Time.unscaledTime;

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
}
