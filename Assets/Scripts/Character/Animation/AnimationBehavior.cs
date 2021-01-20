using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehavior : MonoBehaviour, IAnimationBehavior
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        MovimentoPadrao.Movendo += ControleAnimacaoMovimento;
    }
    private void OnDisable()
    {
        MovimentoPadrao.Movendo -= ControleAnimacaoMovimento;
    }
    public void ControleAnimacaoMovimento(float velocidade, bool noChao)
    {
        _animator.SetBool("Grounded", noChao);
        _animator.SetFloat("MoveSpeed", velocidade);
    }
}
