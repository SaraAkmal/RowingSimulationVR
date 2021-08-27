using UnityEngine;
using System;


public class Twist:MonoBehaviour
{
    public float twist = 10.0f;
    
    
    public void Update() {
    transform.Rotate(Vector3.back*twist*Time.deltaTime);
    }
}