using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool HasItem => CurrentItem;
    public Item CurrentItem { get; private set; }

    public void PickupItem(Item item, Transform holdPoint)
    {
        if (HasItem) return;

        CurrentItem = item;
        item.Tied(holdPoint);
    }

    public void UseCurrentItem()
    {
        CurrentItem.PlayUseEffects();

        CurrentItem.ActivateAndConsume();
    }
}
