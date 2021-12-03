// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""0be8f20c-2f66-40fe-8ba9-0fe7a111816e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d0f4481e-0717-477f-96c7-21401990eb75"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""999c5bf0-d7c0-4125-9409-a1781748d41e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""00f250b6-a97a-422e-a004-e0404479dca5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""07368214-1b91-402e-8fcc-03c7bc33ab1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""6d205a09-86a9-44c1-a2a2-cf55c85ddfb4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EMP"",
                    ""type"": ""Button"",
                    ""id"": ""2389d5b7-d729-4187-8125-9dfe378fc278"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Recall"",
                    ""type"": ""Button"",
                    ""id"": ""f45e4042-13a1-4af7-8dd0-a86c15aa0af6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RedPortal"",
                    ""type"": ""Button"",
                    ""id"": ""68dc13a8-038d-4d08-b6c3-b53d35bf61a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BluePortal"",
                    ""type"": ""Button"",
                    ""id"": ""96501b3a-481f-479b-b062-e351a0b40c71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll Down"",
                    ""type"": ""Button"",
                    ""id"": ""c823e9f3-769b-47a9-8b8d-2f72451062a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fdd931ad-a4b0-40de-adef-8843b06ae56d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""be45939d-e0bc-4b80-b478-664dcafa8f8a"",
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
                    ""id"": ""59933282-f242-4d2c-831e-d8ecf93a4cca"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2cea4651-f8c0-4335-95ed-f79362324248"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b4eb40a6-f5f3-4f09-bf70-71309f8dfdbe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""31f5ea55-a0b2-4d2b-938c-3719b2ebb308"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e780b4f4-7ade-41b3-a6a1-246a9be72f22"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b296bb02-8387-4d1a-a055-57f94a62f270"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8389aaa-0a78-4453-83d4-acbf578a7560"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b17d1383-0e45-4624-84c1-0bd189d996c9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0b1fb42-97c7-46ed-b3a8-f48e12968f22"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df3128a6-91df-430d-98f5-46bd0e49db56"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef1ba2a4-8a3e-416a-b2a1-e0933232927b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7ff5567-bb79-4719-90a9-c2cc4bf0ab4c"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38d7a042-4b2f-4f33-8b71-1df6db7473b6"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""EMP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7346a4da-cf15-424e-be6e-f93b2e0932dc"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""EMP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9512aa06-94b0-4797-8ce4-4cc1ba930571"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Recall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0da3d13-3838-481a-a22b-18adddadfc4a"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Recall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d45e7fcf-44c2-4c39-ad08-2640d456b485"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""RedPortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e644036b-b02a-4062-9368-d5e8c5e7dd54"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""RedPortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57d42af5-3511-4b74-a276-4fd670cd36d9"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""BluePortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66e930e9-9f68-4f7a-aec7-b6f5c6fa8cfa"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""BluePortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6730d5ad-69f5-41ed-a2b0-d22c71e8b09c"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Scroll Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7619d1b-878c-4ff9-b93d-8e8e82bb3d6a"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Scroll Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": []
        },
        {
            ""name"": ""MKB"",
            ""bindingGroup"": ""MKB"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_Movement = m_Controls.FindAction("Movement", throwIfNotFound: true);
        m_Controls_Aim = m_Controls.FindAction("Aim", throwIfNotFound: true);
        m_Controls_Shoot = m_Controls.FindAction("Shoot", throwIfNotFound: true);
        m_Controls_Dash = m_Controls.FindAction("Dash", throwIfNotFound: true);
        m_Controls_Shield = m_Controls.FindAction("Shield", throwIfNotFound: true);
        m_Controls_EMP = m_Controls.FindAction("EMP", throwIfNotFound: true);
        m_Controls_Recall = m_Controls.FindAction("Recall", throwIfNotFound: true);
        m_Controls_RedPortal = m_Controls.FindAction("RedPortal", throwIfNotFound: true);
        m_Controls_BluePortal = m_Controls.FindAction("BluePortal", throwIfNotFound: true);
        m_Controls_ScrollDown = m_Controls.FindAction("Scroll Down", throwIfNotFound: true);
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_Movement;
    private readonly InputAction m_Controls_Aim;
    private readonly InputAction m_Controls_Shoot;
    private readonly InputAction m_Controls_Dash;
    private readonly InputAction m_Controls_Shield;
    private readonly InputAction m_Controls_EMP;
    private readonly InputAction m_Controls_Recall;
    private readonly InputAction m_Controls_RedPortal;
    private readonly InputAction m_Controls_BluePortal;
    private readonly InputAction m_Controls_ScrollDown;
    public struct ControlsActions
    {
        private @PlayerControls m_Wrapper;
        public ControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Controls_Movement;
        public InputAction @Aim => m_Wrapper.m_Controls_Aim;
        public InputAction @Shoot => m_Wrapper.m_Controls_Shoot;
        public InputAction @Dash => m_Wrapper.m_Controls_Dash;
        public InputAction @Shield => m_Wrapper.m_Controls_Shield;
        public InputAction @EMP => m_Wrapper.m_Controls_EMP;
        public InputAction @Recall => m_Wrapper.m_Controls_Recall;
        public InputAction @RedPortal => m_Wrapper.m_Controls_RedPortal;
        public InputAction @BluePortal => m_Wrapper.m_Controls_BluePortal;
        public InputAction @ScrollDown => m_Wrapper.m_Controls_ScrollDown;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Aim.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnShoot;
                @Dash.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDash;
                @Shield.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnShield;
                @EMP.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnEMP;
                @EMP.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnEMP;
                @EMP.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnEMP;
                @Recall.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRecall;
                @Recall.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRecall;
                @Recall.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRecall;
                @RedPortal.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRedPortal;
                @RedPortal.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRedPortal;
                @RedPortal.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRedPortal;
                @BluePortal.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnBluePortal;
                @BluePortal.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnBluePortal;
                @BluePortal.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnBluePortal;
                @ScrollDown.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnScrollDown;
                @ScrollDown.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnScrollDown;
                @ScrollDown.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnScrollDown;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
                @EMP.started += instance.OnEMP;
                @EMP.performed += instance.OnEMP;
                @EMP.canceled += instance.OnEMP;
                @Recall.started += instance.OnRecall;
                @Recall.performed += instance.OnRecall;
                @Recall.canceled += instance.OnRecall;
                @RedPortal.started += instance.OnRedPortal;
                @RedPortal.performed += instance.OnRedPortal;
                @RedPortal.canceled += instance.OnRedPortal;
                @BluePortal.started += instance.OnBluePortal;
                @BluePortal.performed += instance.OnBluePortal;
                @BluePortal.canceled += instance.OnBluePortal;
                @ScrollDown.started += instance.OnScrollDown;
                @ScrollDown.performed += instance.OnScrollDown;
                @ScrollDown.canceled += instance.OnScrollDown;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_MKBSchemeIndex = -1;
    public InputControlScheme MKBScheme
    {
        get
        {
            if (m_MKBSchemeIndex == -1) m_MKBSchemeIndex = asset.FindControlSchemeIndex("MKB");
            return asset.controlSchemes[m_MKBSchemeIndex];
        }
    }
    public interface IControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
        void OnEMP(InputAction.CallbackContext context);
        void OnRecall(InputAction.CallbackContext context);
        void OnRedPortal(InputAction.CallbackContext context);
        void OnBluePortal(InputAction.CallbackContext context);
        void OnScrollDown(InputAction.CallbackContext context);
    }
}