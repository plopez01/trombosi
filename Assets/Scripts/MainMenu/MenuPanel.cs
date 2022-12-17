using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : FadeableComponent
{
    private FadeableComponent[] components;

    // Start is called before the first frame update
    void Start()
    {
        components = GetComponentsInChildren<FadeableComponent>(true);
    }
    public override void setAlpha(float alpha)
    {
        foreach (FadeableComponent component in components)
        {
            component.setAlpha(alpha);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
