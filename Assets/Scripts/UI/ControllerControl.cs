using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerControl : MonoBehaviour
{
    public GameObject startButton;

    public void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(startButton);
    }
}
