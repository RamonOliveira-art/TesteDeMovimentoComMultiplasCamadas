using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoPadrao : MonoBehaviour, IJumpBehavior
{
    private bool _jump;
    private Rigidbody _rb;

    public float _forcaSalto;
    public bool Jump { get => _jump; set => _jump = value; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Pular()
    {
        if (!_jump) return;
        _jump = false;
        _rb.AddForce(Vector3.up * _forcaSalto, ForceMode.Impulse);
    }
}
