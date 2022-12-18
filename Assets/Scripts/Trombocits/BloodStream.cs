using UnityEngine;

public class BloodStream : MonoBehaviour
{
    [SerializeField] private float closedDrag;

    [SerializeField] private float baseDrag;

    [SerializeField] private float streamForce;

    [SerializeField] private float turbulence;

    public Vector2 Force
    {
        get { return new  Vector2(Random.Range(-turbulence, turbulence), streamForce); }
    }

    public float Drag
    {
        get { return closedDrag; }
    }

    public float BaseDrag
    {
        get { return baseDrag; }
    }
}
