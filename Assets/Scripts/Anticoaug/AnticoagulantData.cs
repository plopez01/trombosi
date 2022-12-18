using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Anticoag", menuName = "Anticoagulant", order = 1)]
public class AnticoagulantData : ScriptableObject
{
    [Header("Aspect")]
    public Color color = Color.blue;

    [Header("Settings")]
    public float effectivity = 0.6f;
    public int penetration = 1;
    public bool onlyAffectStuck = false;

    [Header("Release")]
    public float duration = 10;

    public int amount = 10;

    [Header("Active Settings")]
    
    public bool active = true;

    public float force = 2;

    public float targetRange = 4;
}
