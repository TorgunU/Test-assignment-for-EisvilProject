using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected float spawnDelay;
    [SerializeField] protected bool IsEnemySpawn;
    [SerializeField] protected float spawnRadius;

    protected Camera _mainCamera;

    private void OnEnable()
    {
        IsEnemySpawn = true;
    }

    private void Start()
    {
        _mainCamera = Camera.main;

        StartCoroutine(SpawnEnemy());
    }

    protected IEnumerator SpawnEnemy()
    {
        while(IsEnemySpawn)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    protected Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomDirection = Random.insideUnitCircle.normalized;

        float spawnDistance = spawnRadius + _mainCamera.orthographicSize;
        Vector3 spawnPosiiton = _mainCamera.transform.position + randomDirection * spawnDistance;
        spawnPosiiton.z = 0f;

        return spawnPosiiton;
    }
}