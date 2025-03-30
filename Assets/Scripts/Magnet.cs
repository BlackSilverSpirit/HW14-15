using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;
    [SerializeField] private float pickupRadius = 1.5f;

    private GameObject _currentItem;
    [SerializeField] private bool _isCarryingItem;

    private void Update()
    {
        if (!_isCarryingItem)
        {
            CheckForItems();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                UseItem();
            }
        }
    }

    private void CheckForItems()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, pickupRadius, LayerMask.GetMask("Pickable"));

        foreach (Collider objectCollider in nearbyObjects)
        {
            if (objectCollider.CompareTag("CollectableItem"))
            {
                TryPickupItem(objectCollider.gameObject);
                break;
            }
        }
    }

    private void UseItem()
    {
        if (_currentItem == null) return;

        CollectableItem collectedItem = _currentItem.GetComponent<CollectableItem>();

        collectedItem.Use();

        _currentItem = null;
        _isCarryingItem = false;
    }

    private void TryPickupItem(GameObject item)
    {
        CollectableItem collectable = item.GetComponent<CollectableItem>();

        bool canPickup = collectable != null && !collectable.IsPickedUp;

        if (canPickup)
        {
            _currentItem = item;
            _isCarryingItem = true;

            collectable.PickUp(holdPoint);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}

