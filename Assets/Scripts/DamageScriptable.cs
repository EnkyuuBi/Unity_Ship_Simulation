using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Scriptable Object", menuName = "Scriptable Objects/Damage")]
public class DamageScriptable : ScriptableObject
{
    [SerializeField] public int damage;
}
