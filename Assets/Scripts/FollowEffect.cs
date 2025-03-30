using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEffect : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private Transform _target;

    private void Awake()
    {
        Hero hero = FindObjectOfType<Hero>();

        _target = hero.transform;
    }

    private void Update()
    {
        if (_target != null)
        {
            transform.position = _target.position + _offset;
        }
    }
}
