using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public CameraSetting cameraSetting;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = target.position;

    }
    private void LateUpdate()
    {
        transform.position = target.position + cameraSetting.offset;
    }

}
