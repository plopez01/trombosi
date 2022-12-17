using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScriptedButton : FadeableComponent
{
    private TextMeshProUGUI text;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponent<Image>();
    }
    
    public override void setAlpha(float alpha)
    {
        image.color = image.color.WithAlpha(alpha);
        text.color = text.color.WithAlpha(alpha);
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime
        // Time.unscaledTime
    }
}
