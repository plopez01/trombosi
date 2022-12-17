using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TromboSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tromboPrefab;
    [SerializeField] private Vector2 area;
    

    public void Spawn(int amount, GameManager gm)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject tromobcit = Instantiate(tromboPrefab, Vector2.zero, Quaternion.identity, transform);
            tromobcit.transform.localPosition = new Vector2(Random.Range(-area.x, area.x), Random.Range(-area.y, area.y));
            tromobcit.GetComponent<Trombocit>().SetGameManager(gm);
        }
    }
}
