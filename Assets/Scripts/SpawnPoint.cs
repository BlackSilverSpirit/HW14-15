using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Coin _coin;
    private Arrow _arrow;
    private Barrel _barrel;

    public Vector3 Position => transform.position;

    public bool IsEmpty => _coin == null && _arrow == null && _barrel == null;

    public void Occupy(Component obj)
    {
        switch (obj)
        {
            case Coin coin:
                _coin = coin;
                break;
            case Arrow arrow:
                _arrow = arrow;
                break;
            case Barrel barrel:
                _barrel = barrel;
                break;
            default:
                throw new System.ArgumentException("Unsupported object type");
        }
    }
}
