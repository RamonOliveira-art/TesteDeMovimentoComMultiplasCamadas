using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private IMovimentBehavior _movimento;
    private IJumpBehavior _salto;
    private InputBehavior _inputMovimento;
    private Vector2 _direcaoMovimento; 

    private void Awake()
    {
        _movimento = GetComponent<MovimentoPadrao>();
        _inputMovimento = new InputMovimento();
        _salto = GetComponent<SaltoPadrao>();

    }
    private void Update()
    {
        _salto.Jump = Input.GetKeyDown(KeyCode.Space);
    }
    private void FixedUpdate()
    {
        _movimento.Movimento(_inputMovimento);
        _salto.Pular();

    }

}
