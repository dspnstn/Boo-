using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public void MoveAside()
    {
        Vector3 offset = new Vector3(0.7f, 0f, 0f);
        transform.position -= offset;
    }
}
