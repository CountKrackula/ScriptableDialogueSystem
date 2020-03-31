using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="newActorData", menuName = "Actor Data")]
public class ActorData : ScriptableObject
{
    public string ActorName;
    public int Strength;
    public int Intellegence;
}
