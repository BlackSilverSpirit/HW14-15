using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _cooldown;

    [SerializeField] private List<ShootItem> _shotingItemPrefabs;
    [SerializeField] private List<SpeedItem> _speedItemPrefabs;
    [SerializeField] private List<HealthItem> _healthItemPrefabs;

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

        int randomType = Random.Range(0, 3);

        if (randomType == 0 && _shotingItemPrefabs.Count > 0)
        {
            ShootItem coin = Instantiate(_shotingItemPrefabs[Random.Range(0, _shotingItemPrefabs.Count)], spawnPoint.Position, Quaternion.identity);
            spawnPoint.Occupy(coin);
        }
        else if (randomType == 1 && _speedItemPrefabs.Count > 0)
        {
            HealthItem barrel = Instantiate(_healthItemPrefabs[Random.Range(0, _healthItemPrefabs.Count)], spawnPoint.Position, Quaternion.identity);
            spawnPoint.Occupy(barrel);
        }
        else if (_healthItemPrefabs.Count > 0)
        {
            SpeedItem arrow = Instantiate(_speedItemPrefabs[Random.Range(0, _shotingItemPrefabs.Count)], spawnPoint.Position, Quaternion.identity);
            spawnPoint.Occupy(arrow);
        }
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