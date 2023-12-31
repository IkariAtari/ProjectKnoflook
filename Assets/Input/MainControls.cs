//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Input/MainControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MainControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControls"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""fc8812fa-b9c5-485f-8a7e-0be8957b8922"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""46de5638-a9f9-4929-b875-1768d36d8be6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Button"",
                    ""id"": ""cfdad275-a05b-4a9c-bdd3-43a400f3ec74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d73bdfd0-130c-4f4e-9849-8a91b2114960"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""60441b1b-edb3-4991-8a01-67ba6e0f141e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d69f9cdb-308b-46bf-a025-ef22bdecadc1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7b56c863-8922-43af-abf6-4be9ae77ce3b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""be7e326d-18e0-4cf0-bf05-cf1997831868"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fbb4cd52-2c42-4fac-b3a4-9a84cdffa342"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GUIControl"",
            ""id"": ""f17a42ab-524a-42bd-a737-62c0deea9b41"",
            ""actions"": [
                {
                    ""name"": ""ToggleInventory"",
                    ""type"": ""Button"",
                    ""id"": ""1bbe9637-9656-43b6-8938-7194ea770c83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ToggleDebug"",
                    ""type"": ""Button"",
                    ""id"": ""e2f6a846-6fb3-4980-8889-b2c68c5c32df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bde6a879-9266-4a09-8d22-f5bcb16309e4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6104d0dd-6661-4e54-87d6-724330e629a1"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Movement = m_PlayerControls.FindAction("Movement", throwIfNotFound: true);
        m_PlayerControls_Mouse = m_PlayerControls.FindAction("Mouse", throwIfNotFound: true);
        // GUIControl
        m_GUIControl = asset.FindActionMap("GUIControl", throwIfNotFound: true);
        m_GUIControl_ToggleInventory = m_GUIControl.FindAction("ToggleInventory", throwIfNotFound: true);
        m_GUIControl_ToggleDebug = m_GUIControl.FindAction("ToggleDebug", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private List<IPlayerControlsActions> m_PlayerControlsActionsCallbackInterfaces = new List<IPlayerControlsActions>();
    private readonly InputAction m_PlayerControls_Movement;
    private readonly InputAction m_PlayerControls_Mouse;
    public struct PlayerControlsActions
    {
        private @MainControls m_Wrapper;
        public PlayerControlsActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
        public InputAction @Mouse => m_Wrapper.m_PlayerControls_Mouse;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Mouse.started += instance.OnMouse;
            @Mouse.performed += instance.OnMouse;
            @Mouse.canceled += instance.OnMouse;
        }

        private void UnregisterCallbacks(IPlayerControlsActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Mouse.started -= instance.OnMouse;
            @Mouse.performed -= instance.OnMouse;
            @Mouse.canceled -= instance.OnMouse;
        }

        public void RemoveCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // GUIControl
    private readonly InputActionMap m_GUIControl;
    private List<IGUIControlActions> m_GUIControlActionsCallbackInterfaces = new List<IGUIControlActions>();
    private readonly InputAction m_GUIControl_ToggleInventory;
    private readonly InputAction m_GUIControl_ToggleDebug;
    public struct GUIControlActions
    {
        private @MainControls m_Wrapper;
        public GUIControlActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleInventory => m_Wrapper.m_GUIControl_ToggleInventory;
        public InputAction @ToggleDebug => m_Wrapper.m_GUIControl_ToggleDebug;
        public InputActionMap Get() { return m_Wrapper.m_GUIControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GUIControlActions set) { return set.Get(); }
        public void AddCallbacks(IGUIControlActions instance)
        {
            if (instance == null || m_Wrapper.m_GUIControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GUIControlActionsCallbackInterfaces.Add(instance);
            @ToggleInventory.started += instance.OnToggleInventory;
            @ToggleInventory.performed += instance.OnToggleInventory;
            @ToggleInventory.canceled += instance.OnToggleInventory;
            @ToggleDebug.started += instance.OnToggleDebug;
            @ToggleDebug.performed += instance.OnToggleDebug;
            @ToggleDebug.canceled += instance.OnToggleDebug;
        }

        private void UnregisterCallbacks(IGUIControlActions instance)
        {
            @ToggleInventory.started -= instance.OnToggleInventory;
            @ToggleInventory.performed -= instance.OnToggleInventory;
            @ToggleInventory.canceled -= instance.OnToggleInventory;
            @ToggleDebug.started -= instance.OnToggleDebug;
            @ToggleDebug.performed -= instance.OnToggleDebug;
            @ToggleDebug.canceled -= instance.OnToggleDebug;
        }

        public void RemoveCallbacks(IGUIControlActions instance)
        {
            if (m_Wrapper.m_GUIControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGUIControlActions instance)
        {
            foreach (var item in m_Wrapper.m_GUIControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GUIControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GUIControlActions @GUIControl => new GUIControlActions(this);
    public interface IPlayerControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
    }
    public interface IGUIControlActions
    {
        void OnToggleInventory(InputAction.CallbackContext context);
        void OnToggleDebug(InputAction.CallbackContext context);
    }
}
