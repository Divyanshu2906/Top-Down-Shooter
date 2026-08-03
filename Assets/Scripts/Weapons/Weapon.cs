using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    InputActions inputActions;
    [SerializeField] Transform firepoint;
    [SerializeField] GameObject BulletPrefab;

    void Awake()
    {
        inputActions = new InputActions();
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        if (inputActions.Player.Fire.triggered)
        {
            Instantiate(BulletPrefab, firepoint.position, firepoint.rotation);
        }
    }
}
