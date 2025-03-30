using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinShoot : MonoBehaviour
{
    private float _speed;
    private float _lifetime;

    public void Initialize(float speed, float lifetime)
    {
        _speed = speed;
        _lifetime = lifetime;
        Destroy(gameObject, _lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
