using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will handle all input
/// </summary>
public class PlayerInput : MonoBehaviour
{
    private static PlayerInput instance;

    public static PlayerInput Instance
    {
        get;
        private set;
    }

    public MainControls mainControls;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);

            return;
        }
        else
        {
            Instance = this;
        }

        mainControls = new MainControls();
    }

    private void OnEnable()
    {
        mainControls.Enable();
    }

    private void OnDisable()
    {
        mainControls.Disable();
    }
}
