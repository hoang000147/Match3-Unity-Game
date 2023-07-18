using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Normal Item DB", menuName = "Databases/Normal Item DB")]
public class NormalItemDB : ScriptableObject
{
    [field: SerializeField] public Sprite[] SpritesList { get; private set;}
}
