using UnityEngine;

public class ItemPiacker : MonoBehaviour
{
    [SerializeField] private Transform _holdPoint;
    [SerializeField] private LayerMask _pickupLayer;
    [SerializeField] private float _pickupRadius = 1.5f;

    private Inventory _inventory;
  
    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        PickupFirstFoundItem();
    }

    private void PickupFirstFoundItem()
    {
        if (_inventory.HasItem) return;

        Collider[] items = Physics.OverlapSphere(transform.position, _pickupRadius, _pickupLayer);

        foreach (Collider collider in items)
        {
            Item item = collider.GetComponent<Item>();
            _inventory.PickupItem(item, _holdPoint);
            break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _pickupRadius);
    }
}

