using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnMove(float velocidade, bool noChao);
[RequireComponent(typeof(CapsuleCollider))]
public class MovimentoPadrao :MonoBehaviour, IMovimentBehavior
{
    public static OnMove Movendo;

    private Rigidbody _rb;
    private Camera _cameraMain;
    public bool _noChao;
    [SerializeField] private float _velocidade;
    private void Awake()
    {
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _cameraMain = Camera.main;
    }
    public void Movimento(InputBehavior input)
    {
        Vector3 direcao = _cameraMain.transform.TransformDirection(new Vector3(input.Inputs.x, 0, input.Inputs.y));

        direcao = (direcao.sqrMagnitude > 1) ? direcao.normalized : direcao;

        direcao.y = 0;

        RotacionarPersonagemDirecaoDemovimento(direcao);

        _rb.velocity = new Vector3(direcao.x * _velocidade, _rb.velocity.y, direcao.z * _velocidade);

        Movendo?.Invoke(direcao.magnitude, _noChao);
    }
    private void RotacionarPersonagemDirecaoDemovimento(Vector3 direcao)
    {
        if (direcao == Vector3.zero) return;

        transform.rotation = Quaternion.LookRotation(direcao);
    }
    void EvaluateCollision(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector3 normal = collision.GetContact(i).normal;

            _noChao |= normal.y >= 0.75;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
    }
    private void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
    }
    private void OnCollisionExit(Collision collision)
    {
        _noChao = false;
    }
}
