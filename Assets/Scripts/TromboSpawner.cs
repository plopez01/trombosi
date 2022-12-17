using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TromboSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tromboPrefab;
    [SerializeField] private Vector2 area;
    

    public void Spawn(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(tromboPrefab, new Vector2(Random.Range(-area.x, area.x), Random.Range(-area.y, area.y)), Quaternion.identity, transform);
        }
    }
}
