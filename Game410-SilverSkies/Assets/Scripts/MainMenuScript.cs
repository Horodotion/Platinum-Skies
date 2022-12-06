using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour
{
    public InterfaceButton testButton;
    public GameObject panelTest;

    void Awake()
    {
        // testButton.OnPointerClick = () => TogglePanel;
        testButton.onPointerDownEvent.AddListener(TogglePanel);
    }

    public void TogglePanel()
    {
        if (panelTest.activeInHierarchy)
        {
            panelTest.SetActive(false);
        }
        else
        {
            panelTest.SetActive(true);
        }
    }
}
