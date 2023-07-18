using System;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int BoardX { get; private set; }

    public int BoardY { get; private set; }

    public Item Item { get; private set; }

    public Cell NeighbourUp { get; set; }

    public Cell NeighbourRight { get; set; }

    public Cell NeighbourBottom { get; set; }

    public Cell NeighbourLeft { get; set; }


    public bool IsEmpty => Item == null;

    public void Setup(int cellX, int cellY)
    {
        this.BoardX = cellX;
        this.BoardY = cellY;
    }

    public bool IsNeighbour(Cell other)
    {
        return BoardX == other.BoardX && Mathf.Abs(BoardY - other.BoardY) == 1 ||
            BoardY == other.BoardY && Mathf.Abs(BoardX - other.BoardX) == 1;
    }

    public List<NormalItem.eNormalType> GetItemTypesInNeighbours()
    {
        List<NormalItem.eNormalType> results = new List<NormalItem.eNormalType>();

        if (IsCellValid(NeighbourBottom))
            results.Add(GetNormalItemTypeFromCell(NeighbourBottom));
        if (IsCellValid(NeighbourUp))
            results.Add(GetNormalItemTypeFromCell(NeighbourUp));
        if (IsCellValid(NeighbourRight))
            results.Add(GetNormalItemTypeFromCell(NeighbourRight));
        if (IsCellValid(NeighbourLeft))
            results.Add(GetNormalItemTypeFromCell(NeighbourLeft));

        return results;
    }

    private bool IsCellValid(Cell cell)
    {
        if (cell == null || cell.Item == null)
            return false;

        if (!(cell.Item is NormalItem))
            return false;

        return true;
    }

    private NormalItem.eNormalType GetNormalItemTypeFromCell(Cell cell)
    {
        NormalItem normalItem = (NormalItem)cell.Item;
        return normalItem.ItemType;
    }



    public void Free()
    {
        Item = null;
    }

    public void Assign(Item item)
    {
        Item = item;
        Item.SetCell(this);
    }

    public void ApplyItemPosition(bool withAppearAnimation)
    {
        Item.SetViewPosition(this.transform.position);

        if (withAppearAnimation)
        {
            Item.ShowAppearAnimation();
        }
    }

    internal void Clear()
    {
        if (Item != null)
        {
            Item.Clear();
            Item = null;
        }
    }

    internal bool IsSameType(Cell other)
    {
        return Item != null && other.Item != null && Item.IsSameType(other.Item);
    }

    internal void ExplodeItem()
    {
        if (Item == null) return;

        Item.ExplodeView();
        Item = null;
    }

    internal void AnimateItemForHint()
    {
        Item.AnimateForHint();
    }

    internal void StopHintAnimation()
    {
        Item.StopAnimateForHint();
    }

    internal void ApplyItemMoveToPosition()
    {
        Item.AnimationMoveToPosition();
    }
}
