using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnticoagSpawner : Spawner
{
    [SerializeField] private int iterations = 10;

    public void SpawnAnticoagulantAgents(GameManager gm, AnticoagulantData anticoagData)
    {
        StartCoroutine(SpawnCycle(gm, anticoagData));
    }

    IEnumerator SpawnCycle(GameManager gm, AnticoagulantData anticoagData)
    {
        for (int i = 0; i < iterations; i++)
        {
            for (int j = 0; j < anticoagData.amount; j++)
            {
                GameObject agent = Instantiate(prefab, Vector2.zero, Quaternion.identity, transform);
                agent.transform.localPosition = new Vector2(Random.Range(-area.x, area.x), Random.Range(-area.y, area.y));
                Anticoagulant anticoag = agent.GetComponent<Anticoagulant>();
                anticoag.SetGameManager(gm);
                anticoag.LoadData(anticoagData);
            }
            yield return new WaitForSeconds(anticoagData.duration * gm.PulseInterval / iterations);
        } 
    }
}
