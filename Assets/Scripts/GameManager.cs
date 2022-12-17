using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Range(0.1f, 4)] private float pulseInterval;

    [SerializeField] private Animator valveAnimator;

    private float timer = 0;
    private bool valveOpen = false;


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


            valveAnimator.SetBool("Open", valveOpen);
            Debug.Log("Valve open: " + valveOpen);
        }
    }
}
