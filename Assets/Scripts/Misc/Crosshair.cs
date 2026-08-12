using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
   RectTransform crosshair;

    void Awake()
    {
        crosshair = GetComponent<RectTransform>();
    }

    void Update()
    {
        crosshair.position = Mouse.current.position.ReadValue(); // this makes the crosshair image move with the mouse
    }
}
