using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Anticoag", menuName = "Anticoagulant", order = 1)]
public class Anticoagulant : ScriptableObject
{
    public string name = "Epic anticoagulant";
    public Color color = Color.blue;
    public float effectivity = 0.6f;
    public int penetration = 1;

    public bool active = true;
}
