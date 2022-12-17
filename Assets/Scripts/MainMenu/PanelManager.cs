using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PanelManager : MonoBehaviour
{
    [SerializeField] private FadeablePanel currentPanel; // fading in panel
    private FadeablePanel fadingOutPanel;
    private float alpha = 0;
    private float fadeStartTime = 0;

    public void changeToPanel(FadeablePanel panel)
    {
        fadeStartTime = Time.unscaledTime;
        alpha = 0;
        fadingOutPanel = this.currentPanel;
        print("Fading " + currentPanel + " into " + panel);
        this.currentPanel = panel;
    }

    void Update()
    {
        if (alpha < 1)
        {
            alpha += (Time.unscaledTime - fadeStartTime);
            currentPanel.setAlpha(Mathf.Max(0, 1 - alpha));
            if (fadingOutPanel != null)
                fadingOutPanel.setAlpha(Mathf.Min(1, alpha));
        }
    }
}
