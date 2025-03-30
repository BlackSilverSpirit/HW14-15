using UnityEngine;

public class HealthItem : CollectableItem
{
    [SerializeField] private float _destroyTime = 10f;

    [SerializeField] private int _healAmount;

    private void Update()
    {
        DestroyObject(_destroyTime);
    }

    protected override void ApplyBonus()
    {
        Debug.Log("����� �� �����");

        PlayerHealth health = FindObjectOfType<PlayerHealth>();
        if (health != null)
        {
            health.Heal(_healAmount);
            Debug.Log($"������������� {_healAmount} ��������");
        }
    }
}
