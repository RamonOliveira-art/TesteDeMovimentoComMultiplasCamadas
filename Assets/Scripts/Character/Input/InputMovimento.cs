using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovimento : InputBehavior
{
    public Vector2 Inputs
    {
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
