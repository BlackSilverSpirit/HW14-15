using UnityEngine;

public class ShootItem : CollectableItem
{
    [SerializeField] private float _destroyTime;

    [SerializeField] private Shooting _shootItemPrefab;
    [SerializeField] private float _shootItemSpeed = 10f;
    [SerializeField] private float _shootItemLifetime = 3f;

    private void Update()
    {
        DestroyObject(_destroyTime);
    }

    protected override void ApplyBonus()
    {
        Hero hero = FindObjectOfType<Hero>();
        if (hero != null && _shootItemPrefab != null)
        {
            Vector3 spawnPosition = hero.transform.position + hero.transform.forward;

            Shooting newProjectile = Instantiate(_shootItemPrefab, spawnPosition, hero.transform.rotation);

            newProjectile.Initialize(_shootItemSpeed, _shootItemLifetime);
              
            Debug.Log("Выстрел произведен!");
        }
    }
}
