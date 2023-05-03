using UnityEngine;

public class InputMobile : MonoBehaviour, IInputSystem
{
    public float GetHorizontal()
    {
        Debug.LogError("No mobile control");
        return 0;
    }

    public float GetVertical()
    {
        Debug.LogError("No mobile control");
        return 0;
    }
}
