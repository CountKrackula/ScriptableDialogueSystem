using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public float moveRate;
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * moveRate;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * moveRate;
        transform.position += new Vector3(x, 0, z);
        //transform.Translate(x, 0, z,Space.World);
    }

}
