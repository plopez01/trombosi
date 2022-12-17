using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvestigacionButton : MonoBehaviour
{
    [SerializeField] private bool tiered;
    [SerializeField] private string[] titles;
    [SerializeField] private string[] descs;
    [SerializeField] private int[] costs;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private UnityEvent handler;
    public int levelOffset;
    public int currentLevel;

    public void purchase()
    {
        handler.Invoke();
    }

    public string title
    {
        get { return titles[currentLevel]; }
    }
    public string desc
    {
        get { return descs[currentLevel]; }
    }
    public Sprite sprite
    {
        get { return sprites[currentLevel]; }
    }
    public int cost
    {
        get { return costs[currentLevel]; }
    }

    void Update()
    {
        
    }
}
