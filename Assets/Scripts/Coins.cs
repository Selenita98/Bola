using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField]
    float rotationY = 150f;
   

    
    void Update()
    {
        transform.Rotate(rotationY * Time.deltaTime, 0.0f, 0.0f);
    }
}
