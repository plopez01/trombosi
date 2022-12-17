using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private FadeableComponent currentPanel; // fading in panel
    private FadeableComponent fadingOutPanel;
    private bool fadingIn = true;
    private float alpha = 0;

    public void changeToPanel(FadeableComponent panel)
    {
        panel.gameObject.SetActive(true);
        currentPanel.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);
        fadingOutPanel = this.currentPanel;
        this.currentPanel = panel;
    }

    void Update()
    {
        if (fadingIn)
        {

        } else
        {

        }
    }
}
