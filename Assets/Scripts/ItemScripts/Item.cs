using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private Vector3 holdOffset = new Vector3(0, 0.5f, 0);

    [SerializeField] private EffectCreateScripts _collectEffect;
    [SerializeField] private EffectCreateScripts _useEffectPrefab;

    [SerializeField] private float _destroyTime;

    private Transform _targetParent;
    private Collider _collider;

    private float _timer;

    public bool IsPickedUp { get; private set; }

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    protected virtual void Update()
    {
        if (IsPickedUp)
        {
            Vector3 targetPosition = holdOffset;

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime);
        }

        DestroyObject(_destroyTime);
    }

    public void ActivateAndConsume(GameObject owner)
    {
        ApplyBonus(owner);
        Destroy(gameObject);
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

    public void Tied(Transform parent)
    {
        IsPickedUp = true;
        _targetParent = parent;

        PlayCollectEffects();

        _collider.enabled = false;

        transform.SetParent(_targetParent);
    }

    public void PlayUseEffects()
    {
        EffectCreateScripts effect = Instantiate(_useEffectPrefab, transform.position, Quaternion.identity);
    }

    public void PlayCollectEffects()
    {
        EffectCreateScripts effect = Instantiate(_collectEffect, transform.position, Quaternion.identity);
    }
    
    protected abstract void ApplyBonus(GameObject owner);
}
