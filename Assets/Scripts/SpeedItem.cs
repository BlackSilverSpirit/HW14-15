using UnityEngine;

public class SpeedItem : CollectableItem
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
