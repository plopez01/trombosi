using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PanelManager : MonoBehaviour
{
    [SerializeField] private FadeablePanel currentPanel; // fading in panel
    private FadeablePanel fadingOutPanel;
    private AsyncOperation screenBeingOpened;
    private float alpha = 0;
    private float fadeStartTime;

    public void changeToPanel(FadeablePanel panel)
    {
        panel.gameObject.SetActive(true);
        fadeStartTime = Time.unscaledTime;
        alpha = 0;
        fadingOutPanel = this.currentPanel;
        print("Fading " + currentPanel + " into " + panel);
        this.currentPanel = panel;
    }
    public void fadeToScreen(String screen)
    {
        fadeStartTime = Time.unscaledTime;
        alpha = 0;
        fadingOutPanel = this.currentPanel;
        print("Fading " + currentPanel + " into screen: " + screen);
        screenBeingOpened = SceneManager.LoadSceneAsync(screen);
        screenBeingOpened.allowSceneActivation = false;
        this.currentPanel = null;
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
            if (currentPanel != null) currentPanel.setAlpha(alpha);
            if (fadingOutPanel != null)
                fadingOutPanel.setAlpha(1- alpha);
        } else if (screenBeingOpened != null)
        {
            AsyncOperation op = screenBeingOpened;
            screenBeingOpened = null;
            op.allowSceneActivation = true;
        } else
        {
            if (fadingOutPanel != null) fadingOutPanel.gameObject.SetActive(false);
        }
    }
}
