using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    [SerializeField] GameObject _owner;

    private KeyCode _useKey = KeyCode.F;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_useKey))
        {
            _inventory.UseCurrentItem(_owner);
        }
    }
}

