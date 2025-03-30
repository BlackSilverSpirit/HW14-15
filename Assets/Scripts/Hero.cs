using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;
    [SerializeField] private float _rotationSpeed;

    private const string _horizontalAxisName = "Horizontal";
    private const string _verticalAxisName = "Vertical";

    private float _deadZone = 0.1f;
    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = _baseSpeed;
    }

    private void Update()
    {
        ProcessMovenent();
    }

    private void ProcessMovenent()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(_horizontalAxisName), 0, Input.GetAxisRaw(_verticalAxisName));

        bool isMoving = input.magnitude > _deadZone;


        if (isMoving == false)
            return;

        Vector3 normalizedInput = input.normalized;

        ProcessMoveTo(normalizedInput);

        ProcessRotateTo(normalizedInput);
    }

    public void IncreaseSpeed(float multiplier)
    {
        _currentSpeed *= multiplier;
        Debug.Log($"Speed = {_currentSpeed}");
    }

    protected void ProcessMoveTo(Vector3 direction)
    {
        transform.Translate(direction * _currentSpeed * Time.deltaTime, Space.World);
    }

    protected void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    public void OffCharacter()
    {
        gameObject.SetActive(false);
    }

    public void ActiveCharacter(Vector3 newPosition)
    {
        gameObject.SetActive(true);

        transform.position = newPosition;
    }
}
