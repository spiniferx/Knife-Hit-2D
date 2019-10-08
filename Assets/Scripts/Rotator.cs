using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed;

    void Update()
    {
        transform.position = new Vector2(0,1.96f);
        transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
    }
}
