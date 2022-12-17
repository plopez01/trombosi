using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Range(0.1f, 4)] private float pulseInterval;

    [SerializeField, Range(0, 1)] private float _intervalDelay;

    [SerializeField, Range(0, 1)] private float stickChance;

    [SerializeField, Range(0.5f, 1)] private float tromboBreakDist;

    [SerializeField] private Transform tromboPos;

    [SerializeField] private float stickForceMult = 1;

    [SerializeField] private Animator valveAnimator;

    [SerializeField] private TromboSpawner tromboSpawner;

    private BloodStream _bloodStream;

    private float timer = 0;

    private bool valveOpen = false;

    private float intervalDelay;

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

    public float StickChance
    {
        get { return stickChance; }
    }

    public float BreakDistance
    {
        get { return tromboBreakDist; }
    }

    public float StickForceMultiplier
    {
        get { return stickForceMult; }
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
        intervalDelay = pulseInterval * _intervalDelay;
            
        if (Time.unscaledTime - timer >= pulseInterval + intervalDelay)
        {
            timer = Time.unscaledTime;
            valveOpen = !valveOpen;

            if (!valveOpen)
            {
                tromboSpawner.Spawn(this);
            }
            valveAnimator.SetBool("Open", valveOpen);
            Debug.Log("Valve open: " + valveOpen);
        }
       

    }
}
