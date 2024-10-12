using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerThxYvan3D : MonoBehaviour {
    [SerializeField] private float _xPower = 30;
    [SerializeField] private float _zPower = 100;
    private Rigidbody _rb;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    public void Deplacement(InputAction.CallbackContext ctx) {
        Debug.Log(ctx.ReadValue<Vector3>());

        Vector3 vec = ctx.ReadValue<Vector3>();
        vec.x = vec.x * _xPower;
        vec.z = vec.y * _zPower;
        vec.y = 0;
        _rb.velocity = vec;
    }
}
