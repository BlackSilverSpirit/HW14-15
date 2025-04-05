using UnityEngine;

public class SpeedItem : Item
{
    [SerializeField] private float speedMultiplier = 1.2f;

    protected override void ApplyBonus()
    {
        if (base.Hero != null)
        {
            base.Hero.IncreaseSpeed(speedMultiplier);
            Debug.Log($"Скорость увеличена в {speedMultiplier} раза");
        }
    }
}
