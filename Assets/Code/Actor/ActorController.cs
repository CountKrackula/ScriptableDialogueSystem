using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public ActorData Data;

    protected virtual void Start()
    {
        if(Data == null)
        {
            Data = ScriptableObject.CreateInstance<ActorData>();
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
}
