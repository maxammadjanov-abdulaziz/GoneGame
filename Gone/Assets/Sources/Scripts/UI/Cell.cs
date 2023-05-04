using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int _cellID;

    public void OnPointerDown(PointerEventData eventData)
    {
        Inventory.Instance.EquipItem(_cellID);
     
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    
    }

}
