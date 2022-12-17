using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IPManager : MonoBehaviour
{
    [SerializeField] private int iPoints;
    [SerializeField] private TextMeshProUGUI[] displays;
    void Start()
    {
        updateDisplays();
    }

    void updateDisplays()
    {
        foreach (var text in displays)
        {
            text.text = iPoints.ToString();
        }
    }
    public int points
    {
        get { return iPoints; }
        set {
            iPoints = value;
            updateDisplays();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
