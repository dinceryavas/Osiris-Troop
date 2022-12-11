using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSInput : MonoBehaviour, ISSInputs
{
    public float horizontal => Input.GetAxisRaw("Horizontal");
    public float vertical => Input.GetAxisRaw("Vertical");
    public float hover => Input.GetAxisRaw("Hover");
    public float roll => Input.GetAxisRaw("Roll");
    public float speedup => Input.GetAxisRaw("Fire3");

}
