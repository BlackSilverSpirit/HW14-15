using System.Buffers;
using UnityEngine;

public class HealthItem : Item
{
    [SerializeField] private int _healAmount;

    protected override void ApplyBonus(GameObject owner)
    {
        if (owner.GetComponent<Health>() != null)
        {
            owner.GetComponent<Health>().Heal(_healAmount);
            Debug.Log($"Восстановлено {_healAmount} здоровья");
        }
        else
        {
            Debug.Log("PlayerHealth не доступен!");
        }
    }
}
