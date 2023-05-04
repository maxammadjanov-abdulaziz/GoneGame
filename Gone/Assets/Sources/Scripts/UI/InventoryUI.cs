using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Sprite _spriteNull;
    [SerializeField] private GameObject _panelInventory;
    [SerializeField] private Image[] _imageSlots;

    public void Start()
    {
        if (_imageSlots.Length != Inventory.Instance.SlotsItem.Length)
            Debug.LogError("Array length does not match");

        Inventory.Instance.ItemEvent += RefreshUI;
        IInputSystem.EventDownTab += ActivatorPanelInventory;
        SetActivePanelInventory(false);
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

    private void ActivatorPanelInventory()
    {
        SetActivePanelInventory(!_panelInventory.activeSelf);
    }
    private void SetActivePanelInventory(bool active)
    {
        _panelInventory.SetActive(active);
    }
}
