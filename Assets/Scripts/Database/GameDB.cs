using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game DB", menuName = "Databases/Game DB")]
public class GameDB : ScriptableObject
{
    [field: SerializeField] public NormalItemDB NormalItemDB { get; private set; }
    [field: SerializeField] public BonusItemDB BonusItemDB { get; private set; }

    // Prefabs
    [field: SerializeField] public GameObject NormalItemPrefab { get; private set; }
    [field: SerializeField] public GameObject CellBackgroundPrefab { get; private set; }
}
