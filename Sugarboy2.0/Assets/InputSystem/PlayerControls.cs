// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerControls.inputactions'

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
            ""name"": ""Gameplay"",
            ""id"": ""9ddceb61-c6cc-4141-9c24-76fb0866d220"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""131ea4d8-ae88-481a-ae1f-44979a5d93d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""78fe6daf-9be9-4d8d-bc6c-ac02ff3ec42a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delete Clones"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ca712626-3c8d-4181-b8bc-913a6cf7e3fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RestartGame"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6fe30098-6b5d-416e-9a7b-ea30d0e4784f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchCamera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dd0c393e-77a9-4c04-8f74-5aa43264b52a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartRecording"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d0dc2ae5-8d74-45bf-9a0b-6e697ae2bdfd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""c5833270-e539-474d-8228-46684ccd503e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpawnNormalClone"",
                    ""type"": ""Button"",
                    ""id"": ""dad68ae0-4027-4155-aa4d-43feea33954f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""f6e195ea-86f0-4544-aac6-1aef437f41ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard xAxis"",
                    ""id"": ""cdcb9396-ce2c-42bc-a3be-713333cfecec"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ac0c61c7-157d-42b4-8cf9-42966a8bb870"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""00dfed3d-1494-4297-8a33-8b3022bd406c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller xAxis"",
                    ""id"": ""9dc2bea4-7869-47fc-9ed0-c62c5f442cb0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e483577b-c9a1-4cdf-97ae-0cfd3ce501b4"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9836456e-0a13-4f7d-a714-1a73abf184ba"",
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
                    ""id"": ""3a4cdaa6-3eb4-45a6-b26c-06d1116156b5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d94b35c2-43de-4abc-9115-8cea026e2d49"",
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
                    ""id"": ""02c2b04b-83da-477f-a564-949edcecd1af"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delete Clones"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46d3d4eb-17a7-45b8-be11-ba50019ba784"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delete Clones"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da228b67-d94a-430c-bdac-dbdc3503608c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RestartGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""987ab619-505f-4a69-acb3-7f7311d5172a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RestartGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f5d094d-1542-4dca-8b5d-2eb8f192b7e8"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Tap(duration=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bdfce59-6f1a-4303-9c6e-a4a49d7b1f3d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""446fa108-1cf4-4832-858a-3c44bc08b490"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartRecording"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8228ff6d-701a-47b6-bbb7-6315f46c4a99"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartRecording"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e65c9c3b-e7c3-4f28-a961-a835f57fbbd1"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""823729aa-de14-4efb-af6d-864a95a0571d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbff293e-f0d7-42b9-afe9-5a4ffcfa7eb9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpawnNormalClone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ec22b9e-e378-4c71-ac84-20f9149cd10a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_DeleteClones = m_Gameplay.FindAction("Delete Clones", throwIfNotFound: true);
        m_Gameplay_RestartGame = m_Gameplay.FindAction("RestartGame", throwIfNotFound: true);
        m_Gameplay_SwitchCamera = m_Gameplay.FindAction("SwitchCamera", throwIfNotFound: true);
        m_Gameplay_StartRecording = m_Gameplay.FindAction("StartRecording", throwIfNotFound: true);
        m_Gameplay_PauseGame = m_Gameplay.FindAction("PauseGame", throwIfNotFound: true);
        m_Gameplay_SpawnNormalClone = m_Gameplay.FindAction("SpawnNormalClone", throwIfNotFound: true);
        m_Gameplay_Use = m_Gameplay.FindAction("Use", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_DeleteClones;
    private readonly InputAction m_Gameplay_RestartGame;
    private readonly InputAction m_Gameplay_SwitchCamera;
    private readonly InputAction m_Gameplay_StartRecording;
    private readonly InputAction m_Gameplay_PauseGame;
    private readonly InputAction m_Gameplay_SpawnNormalClone;
    private readonly InputAction m_Gameplay_Use;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @DeleteClones => m_Wrapper.m_Gameplay_DeleteClones;
        public InputAction @RestartGame => m_Wrapper.m_Gameplay_RestartGame;
        public InputAction @SwitchCamera => m_Wrapper.m_Gameplay_SwitchCamera;
        public InputAction @StartRecording => m_Wrapper.m_Gameplay_StartRecording;
        public InputAction @PauseGame => m_Wrapper.m_Gameplay_PauseGame;
        public InputAction @SpawnNormalClone => m_Wrapper.m_Gameplay_SpawnNormalClone;
        public InputAction @Use => m_Wrapper.m_Gameplay_Use;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @DeleteClones.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeleteClones;
                @DeleteClones.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeleteClones;
                @DeleteClones.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeleteClones;
                @RestartGame.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestartGame;
                @RestartGame.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestartGame;
                @RestartGame.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestartGame;
                @SwitchCamera.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchCamera;
                @SwitchCamera.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchCamera;
                @SwitchCamera.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchCamera;
                @StartRecording.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStartRecording;
                @StartRecording.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStartRecording;
                @StartRecording.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStartRecording;
                @PauseGame.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @SpawnNormalClone.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawnNormalClone;
                @SpawnNormalClone.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawnNormalClone;
                @SpawnNormalClone.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawnNormalClone;
                @Use.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUse;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @DeleteClones.started += instance.OnDeleteClones;
                @DeleteClones.performed += instance.OnDeleteClones;
                @DeleteClones.canceled += instance.OnDeleteClones;
                @RestartGame.started += instance.OnRestartGame;
                @RestartGame.performed += instance.OnRestartGame;
                @RestartGame.canceled += instance.OnRestartGame;
                @SwitchCamera.started += instance.OnSwitchCamera;
                @SwitchCamera.performed += instance.OnSwitchCamera;
                @SwitchCamera.canceled += instance.OnSwitchCamera;
                @StartRecording.started += instance.OnStartRecording;
                @StartRecording.performed += instance.OnStartRecording;
                @StartRecording.canceled += instance.OnStartRecording;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @SpawnNormalClone.started += instance.OnSpawnNormalClone;
                @SpawnNormalClone.performed += instance.OnSpawnNormalClone;
                @SpawnNormalClone.canceled += instance.OnSpawnNormalClone;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDeleteClones(InputAction.CallbackContext context);
        void OnRestartGame(InputAction.CallbackContext context);
        void OnSwitchCamera(InputAction.CallbackContext context);
        void OnStartRecording(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnSpawnNormalClone(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
    }
}
