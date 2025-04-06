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

    public void UseCurrentItem(GameObject owner)
    {
        CurrentItem.PlayUseEffects();

        CurrentItem.ActivateAndConsume(owner);
    }
}
