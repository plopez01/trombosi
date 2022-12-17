using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private FadeableComponent currentPanel; // fading in panel
    private FadeableComponent fadingOutPanel;
    private float alpha = 0;
    private float fadeStartTime = 0;

    public void changeToPanel(FadeableComponent panel)
    {
        //panel.gameObject.SetActive(true);
        //currentPanel.gameObject.SetActive(false);
        //panel.gameObject.SetActive(true);
        fadeStartTime = Time.unscaledTime;
        alpha = 0;
        fadingOutPanel = this.currentPanel;
        this.currentPanel = panel;
    }

    void Update()
    {
        if (alpha < 1)
        {
            alpha += (fadeStartTime - Time.unscaledTime) * 5;
            currentPanel.setAlpha(alpha);
            fadingOutPanel.setAlpha(1 - alpha);
        }
    }
}
