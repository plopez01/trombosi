using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodStream : MonoBehaviour
{
    [SerializeField] private float closedDrag;

    [SerializeField] private float baseDrag;

    [SerializeField] private Vector2 streamForce;

    public Vector2 Force
    {
        get { return streamForce; }
    }

    public float Drag
    {
        get { return closedDrag + baseDrag; }
    }
}
