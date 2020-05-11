using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _mobSpawners;
    [SerializeField] private GameObject _enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnMobs());
    }

    private IEnumerator SpawnMobs()
    {
        while (true)
        {
            foreach (var spawner in _mobSpawners)
            {
                Instantiate(_enemyPrefab, spawner.position, Quaternion.identity);

                yield return new WaitForSeconds(2);
            }
        }
    }
}
