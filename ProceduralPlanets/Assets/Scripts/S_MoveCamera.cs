using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MoveCamera : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Vector3.up * Time.deltaTime;
    }
}
