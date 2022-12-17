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
    private Button button;
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }
    
    public override void setAlpha(float alpha)
    {
        if (alpha == 0)
        {
            button.enabled = false;
        } else if (alpha == 1)
        {
            button.enabled = true;
        }
        image.color = image.color.WithAlpha(alpha);
        text.color = text.color.WithAlpha(alpha);
    }

    void Update()
    {
    }
}
