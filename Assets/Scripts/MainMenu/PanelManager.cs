using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private FadeablePanel currentPanel; // also fading in panel, nullable cuando cambiando a scene
    [SerializeField, Range(0, 3)] private float fadeTime;
    [SerializeField, Range(0, 3)] private float screenExtraWait;
    [SerializeField, Range(-30, 30)] private int verticalMove;
    private FadeablePanel fadingOutPanel;
    private AsyncOperation screenBeingOpened;
    private float alpha = 0;
    private float lastFadeTime;

    public void changeToPanel(FadeablePanel panel)
    {
        if (panel != null) panel.gameObject.SetActive(true);
        lastFadeTime = Time.unscaledTime;
        alpha = 0;
        fadingOutPanel = this.currentPanel;
        print("Fading " + currentPanel + " into " + panel);
        this.currentPanel = panel;
    }
    public void fadeToScreen(String screen)
    {
        lastFadeTime = Time.unscaledTime;
        alpha = 0;
        fadingOutPanel = this.currentPanel;
        print("Fading " + currentPanel + " into scene: " + screen);
        screenBeingOpened = SceneManager.LoadSceneAsync(screen);
        screenBeingOpened.allowSceneActivation = false;
        this.currentPanel = null;
    }

    private void Start()
    {
        lastFadeTime = Time.unscaledTime + 5;
        // Workaround para no va si no está activo al inicio
        foreach (FadeablePanel p in GetComponentsInChildren<FadeablePanel>(true))
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
            float diff = (Time.unscaledTime - lastFadeTime) / fadeTime;
            alpha = Mathf.Min(1, alpha + diff);
            lastFadeTime = Time.unscaledTime;
            if (currentPanel != null)
            {
                currentPanel.setAlpha(alpha);
                currentPanel.moveY(diff * verticalMove);
            }
            if (fadingOutPanel != null)
            {
                fadingOutPanel.setAlpha(1 - alpha);
                fadingOutPanel.moveY(-diff * verticalMove);
            }
        } else if (screenBeingOpened != null && (Time.unscaledTime - lastFadeTime) > screenExtraWait)
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
