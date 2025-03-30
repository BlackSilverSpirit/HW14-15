using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Coin : CollectableItem
{
    [SerializeField] private float _destroyTime;

    [SerializeField] private CoinShoot _coinShootPrefab;
    [SerializeField] private float _coinShootSpeed = 10f;
    [SerializeField] private float _coinShootLifetime = 3f;

    private void Update()
    {
        DestroyObject(_destroyTime);
    }

    protected override void ApplyBonus()
    {
        Hero hero = FindObjectOfType<Hero>();
        if (hero != null && _coinShootPrefab != null)
        {
            Vector3 spawnPosition = hero.transform.position + hero.transform.forward;

            CoinShoot newProjectile = Instantiate(_coinShootPrefab, spawnPosition, hero.transform.rotation);

            newProjectile.Initialize(_coinShootSpeed, _coinShootLifetime);
              
            Debug.Log("Выстрел произведен!");
        }
    }
}
