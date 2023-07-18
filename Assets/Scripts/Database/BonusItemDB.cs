using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bonus Item DB", menuName = "Databases/Bonus Item DB")]
public class BonusItemDB : ScriptableObject
{
    [field: SerializeField] public BonusItemData[] ItemsList { get; private set; }

    private Dictionary<BonusItem.eBonusType, BonusItemData> ItemsDict;
    private void OnEnable()
    {
        if (ItemsDict == null)
        {
            ItemsDict = new Dictionary<BonusItem.eBonusType, BonusItemData>();

            foreach (var item in ItemsList)
            {
                ItemsDict.Add(item.eBonusType, item);
            }
        }
    }

    public BonusItemData GetBonusItemOfType(BonusItem.eBonusType bonusType)
    {
        if (ItemsDict == null)
            return null;

        return ItemsDict[bonusType];
    }
}

[Serializable]
public class BonusItemData
{
    [field: SerializeField] public BonusItem.eBonusType eBonusType { get; private set; }
    [field: SerializeField] public GameObject BonusItemPrefab { get; private set; }
}