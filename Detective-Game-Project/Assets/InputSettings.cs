// GENERATED AUTOMATICALLY FROM 'Assets/InputSettings.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSettings : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @InputSettings()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSettings"",
    ""maps"": [
        {
            ""name"": ""Human"",
            ""id"": ""4d149846-b96e-4173-8c1b-2a48e978f363"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b4fb8e8d-ba1a-4069-abea-f656e7d00a93"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5ba6f419-8200-4eae-a90a-74eaf6bed8e4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""InteractHold"",
                    ""type"": ""Button"",
                    ""id"": ""00106eef-039f-422a-b2be-688f6763d971"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""4d865517-017e-4310-8011-58191cdc9035"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special2"",
                    ""type"": ""Button"",
                    ""id"": ""88c5f0c2-d103-4a4a-bd93-ca626de6675b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Swap"",
                    ""type"": ""Button"",
                    ""id"": ""87779882-cb1b-439b-9ede-0b6f3ae0ef51"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""baaf3dfc-f4a5-45f7-9e64-b01ac15a8aa2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""CameraMove"",
                    ""type"": ""Value"",
                    ""id"": ""95f0957c-ef42-4115-a604-eaafa0127971"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special3"",
                    ""type"": ""Button"",
                    ""id"": ""76e3405c-d792-4a70-9f11-6e7702d4f3b2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d0884050-824f-4223-a380-2354a7394d18"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""7aef15c3-b03e-403d-8de9-fef20050014e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0764f745-f73f-445e-8308-c8362dabc93d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d18716aa-7849-49a7-8f30-23f9c81ef345"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e688c6d9-e9d9-4577-b8aa-656bbf4a6804"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c326050f-b300-4e3a-b218-52ea2368ef22"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d3aff24d-3ac0-47cd-b6f5-8ce3bc05206b"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee108886-7aff-4834-b09a-cf5941c6a0f7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb850603-6660-4f15-912d-04a47d49823a"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Special2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd5d861b-09b0-4c6e-b0b5-98751e6a08e6"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Special2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe6d7c2b-f1d0-471e-9279-ebb682197fc8"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f51e84c-267f-408c-ba87-3aba8914ad19"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14893611-2e55-4320-943c-f34be2d4f705"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c22718c7-f0c9-4643-8675-267d295e6750"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b573b32-106f-4d77-ad49-ed8f84d462a5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,ScaleVector2(x=2,y=2)"",
                    ""groups"": ""Controller"",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02ec1b4c-3268-481b-9819-1199374841ba"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.05,y=0.05)"",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae90f678-055b-47f7-b35e-107648a2c87b"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""InteractHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d51f6bbe-96a0-46db-90f3-439c747b0de0"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""InteractHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ecc306d-331e-406f-b320-849b36e8674f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""535aa54b-b604-4b8b-bb5d-dda1157d28e8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a345b2d4-8ad5-4e6e-9658-33adf684fcb6"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ebd9dfc-65d0-4e56-982e-19b17c3abe05"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
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
        },
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
        }
    ]
}");
        // Human
        m_Human = asset.FindActionMap("Human", throwIfNotFound: true);
        m_Human_Move = m_Human.FindAction("Move", throwIfNotFound: true);
        m_Human_Interact = m_Human.FindAction("Interact", throwIfNotFound: true);
        m_Human_InteractHold = m_Human.FindAction("InteractHold", throwIfNotFound: true);
        m_Human_Special = m_Human.FindAction("Special", throwIfNotFound: true);
        m_Human_Special2 = m_Human.FindAction("Special2", throwIfNotFound: true);
        m_Human_Swap = m_Human.FindAction("Swap", throwIfNotFound: true);
        m_Human_Jump = m_Human.FindAction("Jump", throwIfNotFound: true);
        m_Human_CameraMove = m_Human.FindAction("CameraMove", throwIfNotFound: true);
        m_Human_Special3 = m_Human.FindAction("Special3", throwIfNotFound: true);
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

    // Human
    private readonly InputActionMap m_Human;
    private IHumanActions m_HumanActionsCallbackInterface;
    private readonly InputAction m_Human_Move;
    private readonly InputAction m_Human_Interact;
    private readonly InputAction m_Human_InteractHold;
    private readonly InputAction m_Human_Special;
    private readonly InputAction m_Human_Special2;
    private readonly InputAction m_Human_Swap;
    private readonly InputAction m_Human_Jump;
    private readonly InputAction m_Human_CameraMove;
    private readonly InputAction m_Human_Special3;
    public struct HumanActions
    {
        private @InputSettings m_Wrapper;
        public HumanActions(@InputSettings wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Human_Move;
        public InputAction @Interact => m_Wrapper.m_Human_Interact;
        public InputAction @InteractHold => m_Wrapper.m_Human_InteractHold;
        public InputAction @Special => m_Wrapper.m_Human_Special;
        public InputAction @Special2 => m_Wrapper.m_Human_Special2;
        public InputAction @Swap => m_Wrapper.m_Human_Swap;
        public InputAction @Jump => m_Wrapper.m_Human_Jump;
        public InputAction @CameraMove => m_Wrapper.m_Human_CameraMove;
        public InputAction @Special3 => m_Wrapper.m_Human_Special3;
        public InputActionMap Get() { return m_Wrapper.m_Human; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HumanActions set) { return set.Get(); }
        public void SetCallbacks(IHumanActions instance)
        {
            if (m_Wrapper.m_HumanActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_HumanActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_HumanActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_HumanActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_HumanActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_HumanActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_HumanActionsCallbackInterface.OnInteract;
                @InteractHold.started -= m_Wrapper.m_HumanActionsCallbackInterface.OnInteractHold;
                @InteractHold.performed -= m_Wrapper.m_HumanActionsCallbackInterface.OnInteractHold;
                @InteractHold.canceled -= m_Wrapper.m_HumanActionsCallbackInterface.OnInteractHold;
                @Special.started -= m_Wrapper.m_HumanActionsCallbackInterface.OnSpecial;
                @Special.performed -= m_Wrapper.m_HumanActionsCallbackInterface.OnSpecial;
                @Special.canceled -= m_Wrapper.m_HumanActionsCallbackInterface.OnSpecial;
                @Special2.started -= m_Wrapper.m_HumanActionsCallbackInterface.OnSpecial2;
                @Special2.performed -= m_Wrapper.m_HumanActionsCallbackInterface.OnSpecial2;
                @Special2.canceled -= m_Wrapper.m_HumanActionsCallbackInterface.OnSpecial2;
                @Swap.started -= m_Wrapper.m_HumanActionsCallbackInterface.OnSwap;
                @Swap.performed -= m_Wrapper.m_HumanActionsCallbackInterface.OnSwap;
                @Swap.canceled -= m_Wrapper.m_HumanActionsCallbackInterface.OnSwap;
                @Jump.started -= m_Wrapper.m_HumanActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_HumanActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_HumanActionsCallbackInterface.OnJump;
                @CameraMove.started -= m_Wrapper.m_HumanActionsCallbackInterface.OnCameraMove;
                @CameraMove.performed -= m_Wrapper.m_HumanActionsCallbackInterface.OnCameraMove;
                @CameraMove.canceled -= m_Wrapper.m_HumanActionsCallbackInterface.OnCameraMove;
                @Special3.started -= m_Wrapper.m_HumanActionsCallbackInterface.OnSpecial3;
                @Special3.performed -= m_Wrapper.m_HumanActionsCallbackInterface.OnSpecial3;
                @Special3.canceled -= m_Wrapper.m_HumanActionsCallbackInterface.OnSpecial3;
            }
            m_Wrapper.m_HumanActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @InteractHold.started += instance.OnInteractHold;
                @InteractHold.performed += instance.OnInteractHold;
                @InteractHold.canceled += instance.OnInteractHold;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
                @Special2.started += instance.OnSpecial2;
                @Special2.performed += instance.OnSpecial2;
                @Special2.canceled += instance.OnSpecial2;
                @Swap.started += instance.OnSwap;
                @Swap.performed += instance.OnSwap;
                @Swap.canceled += instance.OnSwap;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @CameraMove.started += instance.OnCameraMove;
                @CameraMove.performed += instance.OnCameraMove;
                @CameraMove.canceled += instance.OnCameraMove;
                @Special3.started += instance.OnSpecial3;
                @Special3.performed += instance.OnSpecial3;
                @Special3.canceled += instance.OnSpecial3;
            }
        }
    }
    public HumanActions @Human => new HumanActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IHumanActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnInteractHold(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
        void OnSpecial2(InputAction.CallbackContext context);
        void OnSwap(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCameraMove(InputAction.CallbackContext context);
        void OnSpecial3(InputAction.CallbackContext context);
    }
}