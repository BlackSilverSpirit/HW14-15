using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class CollectableItem : MonoBehaviour
{
    [SerializeField] private GameObject _collectEffect;
    [SerializeField] private GameObject _useEffectPrefab;
    [SerializeField] private float _effectDuration = 2f;

    [SerializeField] private Vector3 holdOffset = new Vector3(0, 0.5f, 0);

    private Transform _targetParent;
    private Rigidbody _rigidbody;

    public bool IsPickedUp { get; private set; }

    private float _timer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void PickUp(Transform parent)
    {
        IsPickedUp = true;
        _targetParent = parent;

        GameObject effect = Instantiate(_collectEffect, transform.position, Quaternion.identity);
        Destroy(effect, _effectDuration);

        if (_rigidbody != null)
        {
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector3.zero;
        }

        GetComponent<Collider>().enabled = false;

        transform.SetParent(_targetParent);
    }

    public void Use()
    {
        if (_useEffectPrefab != null)
        {
            GameObject effect = Instantiate(_useEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, _effectDuration);
        }

        ApplyBonus();

        Destroy(gameObject);
    }

    protected abstract void ApplyBonus(); 

    protected virtual void FixedUpdate()
    {
        if (IsPickedUp)
        {
            Vector3 targetPosition = holdOffset;

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime);
        }
    }

    public void DestroyObject(float _destroyTime)
    {
        if (IsPickedUp == false)
        {
            _timer += Time.deltaTime;
            if (_timer >= _destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
