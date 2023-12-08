using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Main GUI manager, will do the toggling between GUI sections etc
/// TODO: Make it better I guess
/// </summary>
public class GUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject InventoryPanel;

    [SerializeField]
    private GameObject DebugPanel;

    private void Start()
    {
        //PlayerInput.Instance.mainControls.GUIControl.ToggleInventory.performed += TogglePanel(InventoryPanel);
    }

    private void Update()
    {
        bool ToggleInventory = PlayerInput.Instance.mainControls.GUIControl.ToggleInventory.WasPressedThisFrame();
        bool ToggleDebug = PlayerInput.Instance.mainControls.GUIControl.ToggleDebug.WasPressedThisFrame();

        if (ToggleInventory)
            TogglePanel(InventoryPanel);

        if (ToggleDebug)
            TogglePanel(DebugPanel);
    }

    private void TogglePanel(GameObject Panel)
    { 
        Panel.SetActive(!Panel.activeSelf);
    }
}