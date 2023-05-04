using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _slotsCount;

    public IItem[] SlotsItem { get; private set; }
    public IItemMelee SlotEquipItemMelee { get; private set; }
    public IItemDistantBattle SlotEquipItemDistantBattle { get; private set; }

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

    public void EquipItem(int slotID)
    {
        if (slotID >= SlotsItem.Length) return;

        

        ItemEventInvoke();
    }

    private void ItemEventInvoke()
    {
        ItemEvent?.Invoke();
    }
}
