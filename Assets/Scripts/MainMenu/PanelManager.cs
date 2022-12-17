using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject currentPanel;

    public void changeToPanel(GameObject panel)
    {
        currentPanel.SetActive(false);
        panel.SetActive(true);
        this.currentPanel = panel;
    }
}
