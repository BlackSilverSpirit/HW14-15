using UnityEngine;

public class HealthItem : Item
{    
    [SerializeField] private int _healAmount;
        
    protected override void ApplyBonus()
    {
        if (base.HeroHealth != null)
        {
            base.HeroHealth.Heal(_healAmount);
            Debug.Log($"Восстановлено {_healAmount} здоровья");
        }
        else
        {
            Debug.Log("PlayerHealth не доступен!");
        }
    }
}
