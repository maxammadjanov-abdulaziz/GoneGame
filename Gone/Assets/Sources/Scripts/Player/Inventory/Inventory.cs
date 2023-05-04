using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _slotsCount;

    public IItem[] SlotsItem { get; private set; }
    public static Inventory Instance;

    public event Action ItemEvent;

    private void Awake()
    {
        Instance = this;
        SlotsItem = new IItem[_slotsCount];
    }

    void Start()
    {
  
    }

    public bool TryAddItem(ItemObject item)
    {
        for (int i = 0; i < SlotsItem.Length; i++)
        {
            if(SlotsItem[i] == null)
            {
                SlotsItem[i] = item;
                ItemEventInvoke();
                Debug.Log(SlotsItem[i]);
                 return true;
            }
        }
        return false;
    }

    public void RemoveItem(int slotID)
    {
        if (slotID >= SlotsItem.Length) return;

        SlotsItem[slotID] = null;
        ItemEventInvoke();
    }

    private void ItemEventInvoke()
    {
        ItemEvent?.Invoke();
    }
}
