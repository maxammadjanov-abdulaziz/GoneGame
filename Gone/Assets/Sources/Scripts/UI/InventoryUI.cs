using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Sprite _spriteNull;
    [SerializeField] private Image[] _imageSlots;

    public void Start()
    {
        if (_imageSlots.Length != Inventory.Instance.SlotsItem.Length)
            Debug.LogError("Array length does not match");

        Inventory.Instance.ItemEvent += RefreshUI;

        gameObject.SetActive(false);
    }

    public void RefreshUI()
    {
        if (Inventory.Instance == null) return;

        var tempInventory = Inventory.Instance;
       
        for (int i = 0; i < tempInventory.SlotsItem.Length; i++)
        {
            _imageSlots[i].sprite = tempInventory.SlotsItem[i] != null
                ? tempInventory.SlotsItem[i].MySprite 
                : _spriteNull;
        }
    }
}
