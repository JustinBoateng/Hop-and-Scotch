// GENERATED AUTOMATICALLY FROM 'Assets/Gameplay Type 2/Scripts/Movements/InputSystem2.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem2 : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem2()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem2"",
    ""maps"": [
        {
            ""name"": ""PlayerOne"",
            ""id"": ""577d3213-be5f-4473-8c3f-f9fbcf417902"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""cf8a9e2d-f69a-4f8f-9fec-009aa852c3f8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f94d17cb-d1cd-4771-8848-21837acad14c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.03,pressPoint=1)""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fdb784fd-3b30-4ad3-8980-704260a57914"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""f5177965-fc2b-47d0-b83f-b025e881e793"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""HomingHopA"",
                    ""type"": ""Button"",
                    ""id"": ""4bcb4f11-57d9-4882-8cf4-3f26b63fcd7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""HomingHopB"",
                    ""type"": ""Button"",
                    ""id"": ""893faac3-1f4d-4d77-b82d-c559706c3294"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""HomingHopX"",
                    ""type"": ""Button"",
                    ""id"": ""30d6501b-5a47-459c-a81f-0ef52f428502"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""HomingHopY"",
                    ""type"": ""Button"",
                    ""id"": ""cb3a690c-f3e9-4bd5-a74a-a2070123104a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""4c683e52-1c2d-42ee-aa96-9c7ff8db464f"",
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
                    ""id"": ""f06dc575-95ce-4165-bd12-bb252dcd7c41"",
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
                    ""id"": ""dea02a69-eb66-4450-9940-cbb28e55fae4"",
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
                    ""id"": ""de9896e4-89ce-4393-8102-3a6f7eaf68ed"",
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
                    ""id"": ""f086c213-a8ca-4672-99ea-285c5f846021"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""87a04b01-9286-4e8c-bfd9-b6a7275101ff"",
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
                    ""id"": ""cb75a32f-b6e8-4606-840e-b9882ee5b2ba"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""21d395a9-1fa5-4461-ab0a-d01c9e8a956d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ac17572e-9a12-4588-a444-308cfe37d822"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d5b0b3ea-f095-4194-87ba-4357e78af42e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller Left Analog"",
                    ""id"": ""319ff68d-573f-4743-b77d-449fa97bb4d6"",
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
                    ""id"": ""e4a62e33-3756-47f7-bf04-b6f8fa49469c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5f479fd4-a0fc-4cad-9a7e-e6ca501bfde0"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d1393ff4-c4ab-42c4-9538-c2aa3086a594"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""02c79db1-f020-4f3f-8ef1-7fbacbca0c7e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""210cc942-88c0-44dd-9bc8-7407bb729505"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14bc610e-df4f-425f-932b-ce9845d72bfb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a2472d6-4da3-4678-a3fb-694aa630c801"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a14d862-d4dc-4aec-980d-908593b559d2"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9ff5c48-62e2-4f8d-8448-0d75c3dcd5c4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3f09194-c20d-4f14-bf94-a067876aa16c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bae4d2c2-a18b-49cd-8056-5096a77f9016"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d3fc10b-fc90-483d-b3a5-4f28a6b64094"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5453e0b-9ffa-4a85-b99b-4754c9f7eb1b"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b7b0eef-09c0-446e-b021-9909b9f4bd70"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cecda3e6-6237-437e-b216-98f586a141e3"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40143f0d-68f4-491e-8cce-87971673a18e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e27ce873-7d4a-40fa-b88a-12c6304d2204"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82ab4bac-1a89-4660-b236-f8f7be219569"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79ad82f9-ed56-4390-b5c7-c6fb7eeb713e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93fd7b6e-f1c3-4711-8387-528a12fcc1d7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0360c49-1181-4e6a-a60c-962dbfe71bef"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5438906a-73cd-4fb6-b7c2-ed183b711dd5"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingHopY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerOne
        m_PlayerOne = asset.FindActionMap("PlayerOne", throwIfNotFound: true);
        m_PlayerOne_Movement = m_PlayerOne.FindAction("Movement", throwIfNotFound: true);
        m_PlayerOne_Jump = m_PlayerOne.FindAction("Jump", throwIfNotFound: true);
        m_PlayerOne_Dash = m_PlayerOne.FindAction("Dash", throwIfNotFound: true);
        m_PlayerOne_LockOn = m_PlayerOne.FindAction("LockOn", throwIfNotFound: true);
        m_PlayerOne_HomingHopA = m_PlayerOne.FindAction("HomingHopA", throwIfNotFound: true);
        m_PlayerOne_HomingHopB = m_PlayerOne.FindAction("HomingHopB", throwIfNotFound: true);
        m_PlayerOne_HomingHopX = m_PlayerOne.FindAction("HomingHopX", throwIfNotFound: true);
        m_PlayerOne_HomingHopY = m_PlayerOne.FindAction("HomingHopY", throwIfNotFound: true);
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

    // PlayerOne
    private readonly InputActionMap m_PlayerOne;
    private IPlayerOneActions m_PlayerOneActionsCallbackInterface;
    private readonly InputAction m_PlayerOne_Movement;
    private readonly InputAction m_PlayerOne_Jump;
    private readonly InputAction m_PlayerOne_Dash;
    private readonly InputAction m_PlayerOne_LockOn;
    private readonly InputAction m_PlayerOne_HomingHopA;
    private readonly InputAction m_PlayerOne_HomingHopB;
    private readonly InputAction m_PlayerOne_HomingHopX;
    private readonly InputAction m_PlayerOne_HomingHopY;
    public struct PlayerOneActions
    {
        private @InputSystem2 m_Wrapper;
        public PlayerOneActions(@InputSystem2 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerOne_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerOne_Jump;
        public InputAction @Dash => m_Wrapper.m_PlayerOne_Dash;
        public InputAction @LockOn => m_Wrapper.m_PlayerOne_LockOn;
        public InputAction @HomingHopA => m_Wrapper.m_PlayerOne_HomingHopA;
        public InputAction @HomingHopB => m_Wrapper.m_PlayerOne_HomingHopB;
        public InputAction @HomingHopX => m_Wrapper.m_PlayerOne_HomingHopX;
        public InputAction @HomingHopY => m_Wrapper.m_PlayerOne_HomingHopY;
        public InputActionMap Get() { return m_Wrapper.m_PlayerOne; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerOneActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerOneActions instance)
        {
            if (m_Wrapper.m_PlayerOneActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnDash;
                @LockOn.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnLockOn;
                @HomingHopA.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopA;
                @HomingHopA.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopA;
                @HomingHopA.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopA;
                @HomingHopB.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopB;
                @HomingHopB.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopB;
                @HomingHopB.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopB;
                @HomingHopX.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopX;
                @HomingHopX.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopX;
                @HomingHopX.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopX;
                @HomingHopY.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopY;
                @HomingHopY.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopY;
                @HomingHopY.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnHomingHopY;
            }
            m_Wrapper.m_PlayerOneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @HomingHopA.started += instance.OnHomingHopA;
                @HomingHopA.performed += instance.OnHomingHopA;
                @HomingHopA.canceled += instance.OnHomingHopA;
                @HomingHopB.started += instance.OnHomingHopB;
                @HomingHopB.performed += instance.OnHomingHopB;
                @HomingHopB.canceled += instance.OnHomingHopB;
                @HomingHopX.started += instance.OnHomingHopX;
                @HomingHopX.performed += instance.OnHomingHopX;
                @HomingHopX.canceled += instance.OnHomingHopX;
                @HomingHopY.started += instance.OnHomingHopY;
                @HomingHopY.performed += instance.OnHomingHopY;
                @HomingHopY.canceled += instance.OnHomingHopY;
            }
        }
    }
    public PlayerOneActions @PlayerOne => new PlayerOneActions(this);
    public interface IPlayerOneActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnHomingHopA(InputAction.CallbackContext context);
        void OnHomingHopB(InputAction.CallbackContext context);
        void OnHomingHopX(InputAction.CallbackContext context);
        void OnHomingHopY(InputAction.CallbackContext context);
    }
}
