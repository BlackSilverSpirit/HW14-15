using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    public void Heal(int heal)
    {
        _health += heal;

        Debug.Log($"HP = {_health}");
    }

}
