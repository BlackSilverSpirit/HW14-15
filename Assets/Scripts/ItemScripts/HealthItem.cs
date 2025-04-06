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
            Debug.Log($"������������� {_healAmount} ��������");
        }
        else
        {
            Debug.Log("PlayerHealth �� ��������!");
        }
    }
}
