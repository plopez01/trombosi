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
    private float fadeStartTime;

    public void changeToPanel(FadeablePanel panel)
    {
        fadeStartTime = Time.unscaledTime;
        alpha = 0;
        fadingOutPanel = this.currentPanel;
        print("Fading " + currentPanel + " into " + panel);
        this.currentPanel = panel;
    }
    private void Start()
    {
        fadeStartTime = Time.unscaledTime + 5;
        //print(currentPanel);
        // Workaround para no va si no está activo al inicio
        foreach (FadeablePanel p in GetComponentsInChildren<FadeablePanel>())
        {
            p.gameObject.SetActive(true);
            if (p != currentPanel)
                p.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (alpha < 1)
        {
            alpha = Mathf.Min(1, alpha + (Time.unscaledTime - fadeStartTime)/2);
            currentPanel.setAlpha(alpha);
            if (fadingOutPanel != null)
                fadingOutPanel.setAlpha(1- alpha);
        }
    }
}
