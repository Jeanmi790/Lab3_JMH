using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotation = 0.54f;

    void Update()
    {
        transform.Rotate(0f, rotation, 0f);
    }
}
