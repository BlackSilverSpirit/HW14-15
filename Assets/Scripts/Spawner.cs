using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _cooldown;

    [Header("Item Prefabs")]
    [SerializeField] private ShootItem _shotingItemPrefabs;
    [SerializeField] private SpeedItem _speedItemPrefabs;
    [SerializeField] private HealthItem _healthItemPrefabs;

    [Header("Spawn Probabilities")]
    [SerializeField][Range(0, 1)] private float _shootingItemChance = 0.4f;
    [SerializeField][Range(0, 1)] private float _healthItemChance = 0.3f;
    [SerializeField][Range(0, 1)] private float _speedItemChance = 0.3f;


    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _cooldown)
        {
            TrySpawn();
            _timer = 0;
        }
    }

    private void TrySpawn()
    {
        List<SpawnPoint> emptyPoints = GetEmptyPoints();

        if (emptyPoints.Count == 0)
        {
            _timer = 0;
            return;
        }

        SpawnPoint spawnPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];

        float randomValue = Random.Range(0f, 1f);
        float cumulative = 0f;

        cumulative += _shootingItemChance;
        if (randomValue <= cumulative)
        {
            SpawnShootItem(spawnPoint);
            return;
        }
        cumulative += _healthItemChance;
        if (randomValue <= cumulative)
        {
            SpawnHealthItem(spawnPoint);
            return;
        }
        else
        {
            SpawnSpeedItem(spawnPoint);
            return;
        }
    }


    private void SpawnShootItem(SpawnPoint spawnPoint)
    {
        ShootItem coin = Instantiate(_shotingItemPrefabs, spawnPoint.Position, Quaternion.identity);
        spawnPoint.Occupy(coin);
    }

    private void SpawnHealthItem(SpawnPoint spawnPoint)
    {
        HealthItem barrel = Instantiate(_healthItemPrefabs, spawnPoint.Position, Quaternion.identity);
        spawnPoint.Occupy(barrel);
    }

    private void SpawnSpeedItem(SpawnPoint spawnPoint)
    {
        SpeedItem arrow = Instantiate(_speedItemPrefabs, spawnPoint.Position, Quaternion.identity);
        spawnPoint.Occupy(arrow);
    }


    private List<SpawnPoint> GetEmptyPoints()
    {
        List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

        foreach (SpawnPoint point in _spawnPoints)
            if (point.IsEmpty)
                emptyPoints.Add(point);
        return emptyPoints;
    }
}