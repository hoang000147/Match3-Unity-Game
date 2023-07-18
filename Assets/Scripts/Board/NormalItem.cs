using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item
{
    public enum eNormalType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }

    public eNormalType ItemType;

    public void SetType(eNormalType type)
    {
        ItemType = type;
    }

    public override void SetView()
    {
        int prefabIndex = GetPrefabIndex();

        GameObject normalItem = GameObject.Instantiate(GameManager.Instance.GameDB.NormalItemPrefab);

        if (normalItem)
        {
            var spriteRenderer = normalItem.GetComponent<SpriteRenderer>();
            if (spriteRenderer)
                spriteRenderer.sprite = GameManager.Instance.GameDB.NormalItemDB.SpritesList[prefabIndex];

            View = normalItem.transform;
        }
    }

    protected override int GetPrefabIndex()
    {
        return (int)ItemType;
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
