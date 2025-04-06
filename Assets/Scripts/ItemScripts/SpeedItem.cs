using UnityEngine;

public class SpeedItem : Item
{
    [SerializeField] private float speedMultiplier = 1.2f;

    protected override void ApplyBonus(GameObject owner)
    {
        if (owner.GetComponent<Hero>() != null)
        {
            owner.GetComponent<Hero>().IncreaseSpeed(speedMultiplier);
            Debug.Log($"Скорость увеличена в {speedMultiplier} раза");
        }
    }
}
