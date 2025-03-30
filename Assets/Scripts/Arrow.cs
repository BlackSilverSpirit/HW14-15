using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : CollectableItem
{
    [SerializeField] private float _destroyTime;
    [SerializeField] private float speedMultiplier = 1.2f;

    private void Update()
    {
        DestroyObject(_destroyTime);
    }

    protected override void ApplyBonus()
    {

        Hero hero = FindObjectOfType<Hero>();
        if (hero != null)
        {
            hero.IncreaseSpeed(speedMultiplier);
            Debug.Log($"Скорость увеличена в {speedMultiplier} раза");
        }
    }
}
