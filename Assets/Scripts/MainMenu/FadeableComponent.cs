using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FadeableComponent : MonoBehaviour
{
    private float alpha = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public abstract void setAlpha(float alpha);

    // Update is called once per frame
    void Update()
    {
        
    }
}
