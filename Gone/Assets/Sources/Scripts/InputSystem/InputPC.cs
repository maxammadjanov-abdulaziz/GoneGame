using UnityEngine;

public class InputPC : MonoBehaviour, IInputSystem
{
    public float GetHorizontal() => Input.GetAxis("Horizontal");
    public float GetVertical() => Input.GetAxis("Vertical");

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.E)) IInputSystem.EventDownE?.Invoke(); 
    }

}
