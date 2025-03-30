using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private ShootItem _coin;
    private SpeedItem _arrow;
    private HealthItem _barrel;

    public Vector3 Position => transform.position;

    public bool IsEmpty => _coin == null && _arrow == null && _barrel == null;

    public void Occupy(Component obj)
    {
        switch (obj)
        {
            case ShootItem coin:
                _coin = coin;
                break;
            case SpeedItem arrow:
                _arrow = arrow;
                break;
            case HealthItem barrel:
                _barrel = barrel;
                break;
            default:
                throw new System.ArgumentException("Unsupported object type");
        }
    }
}
