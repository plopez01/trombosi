using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FadeablePanel : FadeableComponent
{
    private FadeableComponent[] components;

    void Start()
    {
        var cs = GetComponentsInChildren<FadeableComponent>(true);
        List<FadeableComponent> list = new();
        foreach (FadeableComponent c in cs)
        {
            if (c != this)
            {
                list.Add(c);
            }
        }
        if (list.Count == 0)
            Debug.LogError("Empty component list in " + this.name);
        components = list.ToArray();
    }
    public override void setAlpha(float alpha)
    {
        print("Setting opacity of " + name + " to " + alpha);
        foreach (FadeableComponent component in components)
        {
            component.setAlpha(alpha);
        }
    }

    void Update()
    {
        
    }
}
