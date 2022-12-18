using UnityEngine;

public class TromboSpawner : Spawner
{
    [SerializeField] protected int amount;

    public void Spawn(GameManager gm)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject tromobcit = Instantiate(prefab, Vector2.zero, Quaternion.identity, transform);
            tromobcit.transform.localPosition = new Vector2(Random.Range(-area.x, area.x), Random.Range(-area.y, area.y));
            tromobcit.GetComponent<Trombocit>().SetGameManager(gm);
        }
    }
}
