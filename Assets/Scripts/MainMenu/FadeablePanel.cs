using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class FadeablePanel : FadeableComponent
{
    private SetAlpha[] alphers;
    delegate void SetAlpha(float alpha);

    void Start()
    {
        var cs = GetComponentsInChildren<FadeableComponent>(true);
        List<SetAlpha> alphersList = new();
        foreach (TextMeshProUGUI text in GetComponentsInChildren<TextMeshProUGUI>(true)) {
            alphersList.Add(alpha => text.color = text.color.WithAlpha(alpha));
        }
        foreach (Image text in GetComponentsInChildren<Image>(true)) {
            alphersList.Add(alpha => text.color = text.color.WithAlpha(alpha));
        }
        foreach (Button button in GetComponentsInChildren<Button>(true)) {
            alphersList.Add(alpha => {
                if (alpha == 0)
                    button.enabled = false;
                else if (alpha == 1)
                    button.enabled = true;
            });
        }
        if (alphersList.Count == 0)
            Debug.LogError("Empty component list in " + this.name);
        alphers = alphersList.ToArray();
    }

    public override void setAlpha(float alpha)
    {
        foreach (SetAlpha alpher in alphers)
        {
            alpher(alpha);
        }
    }

    public void moveY(float amount)
    {
        transform.Translate(new Vector2(0, amount));
    }
}
