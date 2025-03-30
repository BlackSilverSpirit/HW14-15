using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    
    public int Health => _health;

    public void Heal(int heal)
    {
        _health += heal;

        Debug.Log($"HP = {_health}");
    }

}
