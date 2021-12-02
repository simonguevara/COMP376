using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [Tooltip("if you have 10 total mobs and 5 enemy prefabs, 2 of each enemy will be spawned")]
    int TotalMobs;
    int mobsKilled;
    [SerializeField] GameObject gates;
    [SerializeField] RectTransform boundaries;

    
    [SerializeField] GameObject[] enemyPrefabs;
    [Header("mob count for slot 0->0th enemy prefab, and so on")] 
    [SerializeField] int[] mobCountInOrder;

    Stack<GameObject> killTracker = new Stack<GameObject>();

    bool triggeredSpawnZone = false;
    private void Start()
    {
        for (int i = 0; i < mobCountInOrder.Length; i++)
            TotalMobs += mobCountInOrder[i];
    }
    private void Update()
    {
        if (triggeredSpawnZone)
        {
            spawnMobs();
            if (mobsKilled >= TotalMobs)
                Destroy(gameObject);
            else if (killTracker.Peek() == null)
            {
                killTracker.Pop();
                mobsKilled++;
            }
        }
    }

    int enemyPrefabIndex = 0;
    int mobsspawned = 0;
    void spawnMobs() {
        if (mobsspawned >= TotalMobs)
            return;
        for (enemyPrefabIndex = 0; enemyPrefabIndex < mobCountInOrder.Length; enemyPrefabIndex++) {
            for (int i = 0; i < mobCountInOrder[enemyPrefabIndex]; i++) {
                Vector3[] v = new Vector3[4];
                boundaries.GetWorldCorners(v);

                Vector3 spawnposition = new Vector3(Random.Range(v[0].x, v[2].x), Random.Range(v[0].y, v[1].y));
                spawnposition.z = -1;

                GameObject enemy = Instantiate(enemyPrefabs[(enemyPrefabIndex % enemyPrefabs.Length)], spawnposition, Quaternion.identity);
                killTracker.Push(enemy);
                mobsspawned++;
            }
        }
          /*  for (int i = 0; i < TotalMobs; i++){

            

        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggeredSpawnZone && collision.tag == "Player") {
            gates.SetActive(true);
            triggeredSpawnZone = true;
        }
    }
}
