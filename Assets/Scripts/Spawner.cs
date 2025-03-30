using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _cooldown;

    [SerializeField] private List<Coin> _coinPrefabs;
    [SerializeField] private List<Arrow> _arrowPrefabs;
    [SerializeField] private List<Barrel> _barrelPrefabs;

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

        if (randomType == 0 && _coinPrefabs.Count > 0)
        {
            Coin coin = Instantiate(_coinPrefabs[Random.Range(0, _coinPrefabs.Count)], spawnPoint.Position, Quaternion.identity);
            spawnPoint.Occupy(coin);
        }
        else if (randomType == 1 && _arrowPrefabs.Count > 0)
        {
            Barrel barrel = Instantiate(_barrelPrefabs[Random.Range(0, _barrelPrefabs.Count)], spawnPoint.Position, Quaternion.identity);
            spawnPoint.Occupy(barrel);
        }
        else if (_barrelPrefabs.Count > 0)
        {
            Arrow arrow = Instantiate(_arrowPrefabs[Random.Range(0, _coinPrefabs.Count)], spawnPoint.Position, Quaternion.identity);
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