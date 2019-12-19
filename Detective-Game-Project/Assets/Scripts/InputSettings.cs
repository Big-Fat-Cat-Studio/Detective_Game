// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSettings.inputactions'

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
        },
        {
            ""name"": ""Pipe"",
            ""id"": ""54305c06-6dbc-446a-b49f-fedf0e8956eb"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""05929e84-8b28-419e-9e86-9d5d09024c76"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""987626d0-1ceb-44ac-8b7e-2910ea3de494"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""709bb4a1-01a6-44f6-a489-6c4c883095cb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""fd4bc68a-42f2-473c-b60e-10737aef49e8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""ede759dc-57f9-4e24-aadc-8e6db9b81f80"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""d55fbe71-c473-478b-bc15-ec0335b8211a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Place"",
                    ""type"": ""Button"",
                    ""id"": ""a4ab00e4-e95c-4cd4-b920-482db26a0633"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""a1725aa7-7b6c-48fc-b0e2-15262785abe9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dd9483a7-a131-4621-a138-7e61ba8cfeba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64650c43-0265-44f1-a286-c11ef884ed80"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b3ce08a-697b-44ce-9d2f-82e7b160f607"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c86a935e-0205-4428-a0ac-7a67291dc0f2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53249797-946f-4084-8c9a-0ef23b134f46"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48aded56-90ee-4e09-a8a7-f4e2abb90475"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e3c7ce9-5807-45ec-9ee8-586b525b1f61"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""980bddd3-9cc4-49be-9de9-338562e20ce6"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b49db4af-4d2a-4959-9c75-18c486bf7939"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c4d30a6-4386-4583-8c85-3b833047b356"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8801ab11-d63a-4f22-b245-f876554c4327"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91cd4631-c0f0-41dd-9348-a5e9f29e4e1b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f12a28e-04a0-4efc-bdc1-a777a94e29e6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa80544c-b72f-4d7c-a4e4-1b8eaf8f0ca7"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea28a075-22bc-4957-85fa-b1085d865f8b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8a0d22d-b57a-485d-8173-39d5539ed9fc"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53f8a34e-3d56-4f5a-90bb-4e677b493988"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eabbea52-d8ab-4de4-b628-192b2c983bca"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b14956c-3d4e-4deb-8fba-2249dc7fada8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6ac35a7-03f6-4f30-8116-e0098cbae240"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Exit"",
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
        // Pipe
        m_Pipe = asset.FindActionMap("Pipe", throwIfNotFound: true);
        m_Pipe_Up = m_Pipe.FindAction("Up", throwIfNotFound: true);
        m_Pipe_Down = m_Pipe.FindAction("Down", throwIfNotFound: true);
        m_Pipe_Left = m_Pipe.FindAction("Left", throwIfNotFound: true);
        m_Pipe_Right = m_Pipe.FindAction("Right", throwIfNotFound: true);
        m_Pipe_RotateLeft = m_Pipe.FindAction("RotateLeft", throwIfNotFound: true);
        m_Pipe_RotateRight = m_Pipe.FindAction("RotateRight", throwIfNotFound: true);
        m_Pipe_Place = m_Pipe.FindAction("Place", throwIfNotFound: true);
        m_Pipe_Exit = m_Pipe.FindAction("Exit", throwIfNotFound: true);
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

    // Pipe
    private readonly InputActionMap m_Pipe;
    private IPipeActions m_PipeActionsCallbackInterface;
    private readonly InputAction m_Pipe_Up;
    private readonly InputAction m_Pipe_Down;
    private readonly InputAction m_Pipe_Left;
    private readonly InputAction m_Pipe_Right;
    private readonly InputAction m_Pipe_RotateLeft;
    private readonly InputAction m_Pipe_RotateRight;
    private readonly InputAction m_Pipe_Place;
    private readonly InputAction m_Pipe_Exit;
    public struct PipeActions
    {
        private @InputSettings m_Wrapper;
        public PipeActions(@InputSettings wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Pipe_Up;
        public InputAction @Down => m_Wrapper.m_Pipe_Down;
        public InputAction @Left => m_Wrapper.m_Pipe_Left;
        public InputAction @Right => m_Wrapper.m_Pipe_Right;
        public InputAction @RotateLeft => m_Wrapper.m_Pipe_RotateLeft;
        public InputAction @RotateRight => m_Wrapper.m_Pipe_RotateRight;
        public InputAction @Place => m_Wrapper.m_Pipe_Place;
        public InputAction @Exit => m_Wrapper.m_Pipe_Exit;
        public InputActionMap Get() { return m_Wrapper.m_Pipe; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PipeActions set) { return set.Get(); }
        public void SetCallbacks(IPipeActions instance)
        {
            if (m_Wrapper.m_PipeActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_PipeActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_PipeActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_PipeActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_PipeActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_PipeActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_PipeActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_PipeActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PipeActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PipeActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_PipeActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PipeActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PipeActionsCallbackInterface.OnRight;
                @RotateLeft.started -= m_Wrapper.m_PipeActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.performed -= m_Wrapper.m_PipeActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.canceled -= m_Wrapper.m_PipeActionsCallbackInterface.OnRotateLeft;
                @RotateRight.started -= m_Wrapper.m_PipeActionsCallbackInterface.OnRotateRight;
                @RotateRight.performed -= m_Wrapper.m_PipeActionsCallbackInterface.OnRotateRight;
                @RotateRight.canceled -= m_Wrapper.m_PipeActionsCallbackInterface.OnRotateRight;
                @Place.started -= m_Wrapper.m_PipeActionsCallbackInterface.OnPlace;
                @Place.performed -= m_Wrapper.m_PipeActionsCallbackInterface.OnPlace;
                @Place.canceled -= m_Wrapper.m_PipeActionsCallbackInterface.OnPlace;
                @Exit.started -= m_Wrapper.m_PipeActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_PipeActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_PipeActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_PipeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @RotateLeft.started += instance.OnRotateLeft;
                @RotateLeft.performed += instance.OnRotateLeft;
                @RotateLeft.canceled += instance.OnRotateLeft;
                @RotateRight.started += instance.OnRotateRight;
                @RotateRight.performed += instance.OnRotateRight;
                @RotateRight.canceled += instance.OnRotateRight;
                @Place.started += instance.OnPlace;
                @Place.performed += instance.OnPlace;
                @Place.canceled += instance.OnPlace;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public PipeActions @Pipe => new PipeActions(this);
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
    public interface IPipeActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnRotateLeft(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
        void OnPlace(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
}