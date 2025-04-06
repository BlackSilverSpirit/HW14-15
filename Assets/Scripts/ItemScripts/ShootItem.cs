using UnityEngine;

public class ShootItem : Item
{
    [SerializeField] private Shooting _shootItemPrefab;
    [SerializeField] private float _shootItemSpeed = 10f;
    [SerializeField] private float _shootItemLifetime = 3f;

    protected override void ApplyBonus(GameObject owner)
    {
        if (owner.GetComponent<Hero>() != null && _shootItemPrefab != null)
        {
            Vector3 spawnPosition = owner.GetComponent<Hero>().transform.position + owner.GetComponent<Hero>().transform.forward;

            Shooting newProjectile = Instantiate(_shootItemPrefab, spawnPosition, owner.GetComponent<Hero>().transform.rotation);

            newProjectile.Initialize(_shootItemSpeed, _shootItemLifetime);

            Debug.Log("Выстрел произведен!");
        }
    }
}
