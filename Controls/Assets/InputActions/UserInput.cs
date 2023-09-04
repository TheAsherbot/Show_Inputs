//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/InputActions/UserInput.inputactions
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

public partial class @UserInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @UserInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UserInput"",
    ""maps"": [
        {
            ""name"": ""StanderdController"",
            ""id"": ""c3668ad5-efd3-4713-b747-bf3ef6206970"",
            ""actions"": [
                {
                    ""name"": ""ButtonNorth"",
                    ""type"": ""Button"",
                    ""id"": ""a8fb8cf4-1a43-40dc-bc3d-b2066cf0753d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ButtonSouth"",
                    ""type"": ""Button"",
                    ""id"": ""a1cc74c4-e475-43ef-ab93-12f61f431595"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ButtonEast"",
                    ""type"": ""Button"",
                    ""id"": ""623d9dfc-1477-4399-b608-5d7d3fcef8d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ButtonWest"",
                    ""type"": ""Button"",
                    ""id"": ""ee3ddc40-36eb-4fa4-94c4-50703beb5317"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""5ba48494-28cc-4710-9848-3578529f17d5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Value"",
                    ""id"": ""2c145315-26ce-4938-bd26-ad42634c72c2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DPad"",
                    ""type"": ""Value"",
                    ""id"": ""7042ff15-da3c-40f0-aaa5-65329fde0f73"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ZL"",
                    ""type"": ""Button"",
                    ""id"": ""ced445df-fa24-4987-a30f-e3b291b328cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""L"",
                    ""type"": ""Button"",
                    ""id"": ""a2647eee-eca5-42c4-b59b-3aae119884c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""R"",
                    ""type"": ""Button"",
                    ""id"": ""0dd1b119-0669-49bc-b8cf-5f059e62e847"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ZR"",
                    ""type"": ""Button"",
                    ""id"": ""6b7b4697-07ab-4dd5-94cb-6900ba3fe74d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""f1e1abb3-a583-4964-993e-31744f11c6c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""aaf5dae1-22b1-45b8-951f-5ccb73deb105"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Home"",
                    ""type"": ""Button"",
                    ""id"": ""714cf66c-7adb-411d-b9f0-19401ac160ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f502584f-bb47-4e96-b069-cecd8673ab27"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47986c0f-c2a5-47dc-b707-7c71db31ed63"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ZR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e1e97b9-0846-4c9b-afdd-ed3a2b40f6c6"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66c61393-a3d0-495a-b3a5-34c4e33825b8"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6645d61b-28d5-4d45-af97-291b015fa2d5"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0aae9930-ee01-4955-a9a0-513b71545653"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ZL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ccdb007-4807-45c9-a460-228da6592d22"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""deceb86d-8f87-4fea-93f2-53c2fa568f21"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7843f88-ddc4-4757-8224-2fae6031fd7d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ButtonWest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78d9ae8b-a5ad-4417-90f5-dd9566d7cd19"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ButtonEast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4461f662-2ac2-48d0-9176-121457eb0f27"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ButtonSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63ae0c03-6e63-4a12-84ba-dd910899b538"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ButtonNorth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ec0fd7a-7ae7-4093-ab94-7e71dde061db"",
                    ""path"": ""<SwitchProControllerHID>/home"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Home"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69b50542-4d97-4a7d-a905-b9421eb040a5"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Options"",
            ""id"": ""4e53ea01-51e8-4d21-8b34-d236cbff3a1b"",
            ""actions"": [
                {
                    ""name"": ""Shift"",
                    ""type"": ""Button"",
                    ""id"": ""edd1b348-e0a7-47d8-9e28-10470f7f1504"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""90fd5554-460d-4a32-8cfc-784454834a5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cedf2fe7-f50c-42c4-8c80-e83f4237b33c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBorad"",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d3aeb0e-57dd-41cb-800d-f90488dc4887"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBorad"",
                    ""action"": ""Escape"",
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
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyBorad"",
            ""bindingGroup"": ""KeyBorad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // StanderdController
        m_StanderdController = asset.FindActionMap("StanderdController", throwIfNotFound: true);
        m_StanderdController_ButtonNorth = m_StanderdController.FindAction("ButtonNorth", throwIfNotFound: true);
        m_StanderdController_ButtonSouth = m_StanderdController.FindAction("ButtonSouth", throwIfNotFound: true);
        m_StanderdController_ButtonEast = m_StanderdController.FindAction("ButtonEast", throwIfNotFound: true);
        m_StanderdController_ButtonWest = m_StanderdController.FindAction("ButtonWest", throwIfNotFound: true);
        m_StanderdController_LeftStick = m_StanderdController.FindAction("LeftStick", throwIfNotFound: true);
        m_StanderdController_RightStick = m_StanderdController.FindAction("RightStick", throwIfNotFound: true);
        m_StanderdController_DPad = m_StanderdController.FindAction("DPad", throwIfNotFound: true);
        m_StanderdController_ZL = m_StanderdController.FindAction("ZL", throwIfNotFound: true);
        m_StanderdController_L = m_StanderdController.FindAction("L", throwIfNotFound: true);
        m_StanderdController_R = m_StanderdController.FindAction("R", throwIfNotFound: true);
        m_StanderdController_ZR = m_StanderdController.FindAction("ZR", throwIfNotFound: true);
        m_StanderdController_Select = m_StanderdController.FindAction("Select", throwIfNotFound: true);
        m_StanderdController_Start = m_StanderdController.FindAction("Start", throwIfNotFound: true);
        m_StanderdController_Home = m_StanderdController.FindAction("Home", throwIfNotFound: true);
        // Options
        m_Options = asset.FindActionMap("Options", throwIfNotFound: true);
        m_Options_Shift = m_Options.FindAction("Shift", throwIfNotFound: true);
        m_Options_Escape = m_Options.FindAction("Escape", throwIfNotFound: true);
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

    // StanderdController
    private readonly InputActionMap m_StanderdController;
    private List<IStanderdControllerActions> m_StanderdControllerActionsCallbackInterfaces = new List<IStanderdControllerActions>();
    private readonly InputAction m_StanderdController_ButtonNorth;
    private readonly InputAction m_StanderdController_ButtonSouth;
    private readonly InputAction m_StanderdController_ButtonEast;
    private readonly InputAction m_StanderdController_ButtonWest;
    private readonly InputAction m_StanderdController_LeftStick;
    private readonly InputAction m_StanderdController_RightStick;
    private readonly InputAction m_StanderdController_DPad;
    private readonly InputAction m_StanderdController_ZL;
    private readonly InputAction m_StanderdController_L;
    private readonly InputAction m_StanderdController_R;
    private readonly InputAction m_StanderdController_ZR;
    private readonly InputAction m_StanderdController_Select;
    private readonly InputAction m_StanderdController_Start;
    private readonly InputAction m_StanderdController_Home;
    public struct StanderdControllerActions
    {
        private @UserInput m_Wrapper;
        public StanderdControllerActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ButtonNorth => m_Wrapper.m_StanderdController_ButtonNorth;
        public InputAction @ButtonSouth => m_Wrapper.m_StanderdController_ButtonSouth;
        public InputAction @ButtonEast => m_Wrapper.m_StanderdController_ButtonEast;
        public InputAction @ButtonWest => m_Wrapper.m_StanderdController_ButtonWest;
        public InputAction @LeftStick => m_Wrapper.m_StanderdController_LeftStick;
        public InputAction @RightStick => m_Wrapper.m_StanderdController_RightStick;
        public InputAction @DPad => m_Wrapper.m_StanderdController_DPad;
        public InputAction @ZL => m_Wrapper.m_StanderdController_ZL;
        public InputAction @L => m_Wrapper.m_StanderdController_L;
        public InputAction @R => m_Wrapper.m_StanderdController_R;
        public InputAction @ZR => m_Wrapper.m_StanderdController_ZR;
        public InputAction @Select => m_Wrapper.m_StanderdController_Select;
        public InputAction @Start => m_Wrapper.m_StanderdController_Start;
        public InputAction @Home => m_Wrapper.m_StanderdController_Home;
        public InputActionMap Get() { return m_Wrapper.m_StanderdController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StanderdControllerActions set) { return set.Get(); }
        public void AddCallbacks(IStanderdControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_StanderdControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_StanderdControllerActionsCallbackInterfaces.Add(instance);
            @ButtonNorth.started += instance.OnButtonNorth;
            @ButtonNorth.performed += instance.OnButtonNorth;
            @ButtonNorth.canceled += instance.OnButtonNorth;
            @ButtonSouth.started += instance.OnButtonSouth;
            @ButtonSouth.performed += instance.OnButtonSouth;
            @ButtonSouth.canceled += instance.OnButtonSouth;
            @ButtonEast.started += instance.OnButtonEast;
            @ButtonEast.performed += instance.OnButtonEast;
            @ButtonEast.canceled += instance.OnButtonEast;
            @ButtonWest.started += instance.OnButtonWest;
            @ButtonWest.performed += instance.OnButtonWest;
            @ButtonWest.canceled += instance.OnButtonWest;
            @LeftStick.started += instance.OnLeftStick;
            @LeftStick.performed += instance.OnLeftStick;
            @LeftStick.canceled += instance.OnLeftStick;
            @RightStick.started += instance.OnRightStick;
            @RightStick.performed += instance.OnRightStick;
            @RightStick.canceled += instance.OnRightStick;
            @DPad.started += instance.OnDPad;
            @DPad.performed += instance.OnDPad;
            @DPad.canceled += instance.OnDPad;
            @ZL.started += instance.OnZL;
            @ZL.performed += instance.OnZL;
            @ZL.canceled += instance.OnZL;
            @L.started += instance.OnL;
            @L.performed += instance.OnL;
            @L.canceled += instance.OnL;
            @R.started += instance.OnR;
            @R.performed += instance.OnR;
            @R.canceled += instance.OnR;
            @ZR.started += instance.OnZR;
            @ZR.performed += instance.OnZR;
            @ZR.canceled += instance.OnZR;
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
            @Start.started += instance.OnStart;
            @Start.performed += instance.OnStart;
            @Start.canceled += instance.OnStart;
            @Home.started += instance.OnHome;
            @Home.performed += instance.OnHome;
            @Home.canceled += instance.OnHome;
        }

        private void UnregisterCallbacks(IStanderdControllerActions instance)
        {
            @ButtonNorth.started -= instance.OnButtonNorth;
            @ButtonNorth.performed -= instance.OnButtonNorth;
            @ButtonNorth.canceled -= instance.OnButtonNorth;
            @ButtonSouth.started -= instance.OnButtonSouth;
            @ButtonSouth.performed -= instance.OnButtonSouth;
            @ButtonSouth.canceled -= instance.OnButtonSouth;
            @ButtonEast.started -= instance.OnButtonEast;
            @ButtonEast.performed -= instance.OnButtonEast;
            @ButtonEast.canceled -= instance.OnButtonEast;
            @ButtonWest.started -= instance.OnButtonWest;
            @ButtonWest.performed -= instance.OnButtonWest;
            @ButtonWest.canceled -= instance.OnButtonWest;
            @LeftStick.started -= instance.OnLeftStick;
            @LeftStick.performed -= instance.OnLeftStick;
            @LeftStick.canceled -= instance.OnLeftStick;
            @RightStick.started -= instance.OnRightStick;
            @RightStick.performed -= instance.OnRightStick;
            @RightStick.canceled -= instance.OnRightStick;
            @DPad.started -= instance.OnDPad;
            @DPad.performed -= instance.OnDPad;
            @DPad.canceled -= instance.OnDPad;
            @ZL.started -= instance.OnZL;
            @ZL.performed -= instance.OnZL;
            @ZL.canceled -= instance.OnZL;
            @L.started -= instance.OnL;
            @L.performed -= instance.OnL;
            @L.canceled -= instance.OnL;
            @R.started -= instance.OnR;
            @R.performed -= instance.OnR;
            @R.canceled -= instance.OnR;
            @ZR.started -= instance.OnZR;
            @ZR.performed -= instance.OnZR;
            @ZR.canceled -= instance.OnZR;
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
            @Start.started -= instance.OnStart;
            @Start.performed -= instance.OnStart;
            @Start.canceled -= instance.OnStart;
            @Home.started -= instance.OnHome;
            @Home.performed -= instance.OnHome;
            @Home.canceled -= instance.OnHome;
        }

        public void RemoveCallbacks(IStanderdControllerActions instance)
        {
            if (m_Wrapper.m_StanderdControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IStanderdControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_StanderdControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_StanderdControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public StanderdControllerActions @StanderdController => new StanderdControllerActions(this);

    // Options
    private readonly InputActionMap m_Options;
    private List<IOptionsActions> m_OptionsActionsCallbackInterfaces = new List<IOptionsActions>();
    private readonly InputAction m_Options_Shift;
    private readonly InputAction m_Options_Escape;
    public struct OptionsActions
    {
        private @UserInput m_Wrapper;
        public OptionsActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shift => m_Wrapper.m_Options_Shift;
        public InputAction @Escape => m_Wrapper.m_Options_Escape;
        public InputActionMap Get() { return m_Wrapper.m_Options; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OptionsActions set) { return set.Get(); }
        public void AddCallbacks(IOptionsActions instance)
        {
            if (instance == null || m_Wrapper.m_OptionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_OptionsActionsCallbackInterfaces.Add(instance);
            @Shift.started += instance.OnShift;
            @Shift.performed += instance.OnShift;
            @Shift.canceled += instance.OnShift;
            @Escape.started += instance.OnEscape;
            @Escape.performed += instance.OnEscape;
            @Escape.canceled += instance.OnEscape;
        }

        private void UnregisterCallbacks(IOptionsActions instance)
        {
            @Shift.started -= instance.OnShift;
            @Shift.performed -= instance.OnShift;
            @Shift.canceled -= instance.OnShift;
            @Escape.started -= instance.OnEscape;
            @Escape.performed -= instance.OnEscape;
            @Escape.canceled -= instance.OnEscape;
        }

        public void RemoveCallbacks(IOptionsActions instance)
        {
            if (m_Wrapper.m_OptionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IOptionsActions instance)
        {
            foreach (var item in m_Wrapper.m_OptionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_OptionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public OptionsActions @Options => new OptionsActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_KeyBoradSchemeIndex = -1;
    public InputControlScheme KeyBoradScheme
    {
        get
        {
            if (m_KeyBoradSchemeIndex == -1) m_KeyBoradSchemeIndex = asset.FindControlSchemeIndex("KeyBorad");
            return asset.controlSchemes[m_KeyBoradSchemeIndex];
        }
    }
    public interface IStanderdControllerActions
    {
        void OnButtonNorth(InputAction.CallbackContext context);
        void OnButtonSouth(InputAction.CallbackContext context);
        void OnButtonEast(InputAction.CallbackContext context);
        void OnButtonWest(InputAction.CallbackContext context);
        void OnLeftStick(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
        void OnDPad(InputAction.CallbackContext context);
        void OnZL(InputAction.CallbackContext context);
        void OnL(InputAction.CallbackContext context);
        void OnR(InputAction.CallbackContext context);
        void OnZR(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnHome(InputAction.CallbackContext context);
    }
    public interface IOptionsActions
    {
        void OnShift(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
}
