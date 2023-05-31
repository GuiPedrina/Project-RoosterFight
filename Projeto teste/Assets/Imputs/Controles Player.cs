//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Imputs/Controles Player.inputactions
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

public partial class @ControlesPlayer: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlesPlayer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controles Player"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""599ad91c-49c9-4698-91d0-ff6e3d158f02"",
            ""actions"": [
                {
                    ""name"": ""Movimentacao"",
                    ""type"": ""Value"",
                    ""id"": ""4af94549-4b83-4041-95d0-567f819c058a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f5ee63c2-a1df-434e-aa60-53dbf0b5a391"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AtkMeele"",
                    ""type"": ""Button"",
                    ""id"": ""41e7f1de-d3a7-43a8-9178-5b55fd66b48e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AtkRanged"",
                    ""type"": ""Button"",
                    ""id"": ""e58fc5db-8a98-4aeb-a7c5-a20655f94cac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Movimento"",
                    ""id"": ""eeafe6ff-abe3-422a-b615-8bb49e804848"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ad4358e5-26d9-4976-b07a-3003bdd81618"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""58891e46-11b7-4c18-8210-100020654837"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0b657964-6d1b-44ef-a160-000986fa2d49"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f1b39600-c6d7-42b9-92e8-aa2c4b527aef"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""720b3964-f1f7-4c62-acf5-dbde4489468a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1356fd4d-1bea-43f5-81ae-802abc180f36"",
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
                    ""id"": ""81dd6ff7-15ef-4555-99f1-249bf32c67d5"",
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
                    ""id"": ""901c555a-b5fb-4ccd-bdf9-73af30392397"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtkMeele"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04198942-b152-4edf-80b8-6bec23d65371"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtkMeele"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0078e94c-a632-4509-afbd-c91eed7eceff"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtkRanged"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34fd344c-3702-4d4f-974d-2f0c140b8088"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtkRanged"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""b5353125-3b9d-491d-9dc6-a4b555835a50"",
            ""actions"": [
                {
                    ""name"": ""Movimentacao"",
                    ""type"": ""Value"",
                    ""id"": ""1cfe677b-8eb8-4a01-98f8-18395930f96a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""978bc484-6b3d-44f6-9022-8709067116ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MeeleAtk"",
                    ""type"": ""Button"",
                    ""id"": ""c2071726-2391-4afc-8ef2-5e33543fcc6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""movimentoP2"",
                    ""id"": ""54f3a4da-bae9-4ed2-9c10-3739d49a182f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5b2fc3fe-1b41-492d-b0fc-07401f5022f3"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""92542c28-bd58-475f-aee5-969cf32fe4ab"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bab0e733-977c-432e-a983-aa0d6113ad03"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9e1cf30a-36cb-4cae-a06e-84f24ec9f84f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""18966fd4-d1e5-49f0-8ce1-91e1e393a498"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimentacao"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f9ba905-6f3c-4969-8ef2-782c354a9fb1"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86469a66-3d59-4b14-9b24-d54f48217d5d"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MeeleAtk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movimentacao = m_Player.FindAction("Movimentacao", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_AtkMeele = m_Player.FindAction("AtkMeele", throwIfNotFound: true);
        m_Player_AtkRanged = m_Player.FindAction("AtkRanged", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Movimentacao = m_Player2.FindAction("Movimentacao", throwIfNotFound: true);
        m_Player2_Jump = m_Player2.FindAction("Jump", throwIfNotFound: true);
        m_Player2_MeeleAtk = m_Player2.FindAction("MeeleAtk", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Movimentacao;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_AtkMeele;
    private readonly InputAction m_Player_AtkRanged;
    public struct PlayerActions
    {
        private @ControlesPlayer m_Wrapper;
        public PlayerActions(@ControlesPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movimentacao => m_Wrapper.m_Player_Movimentacao;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @AtkMeele => m_Wrapper.m_Player_AtkMeele;
        public InputAction @AtkRanged => m_Wrapper.m_Player_AtkRanged;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Movimentacao.started += instance.OnMovimentacao;
            @Movimentacao.performed += instance.OnMovimentacao;
            @Movimentacao.canceled += instance.OnMovimentacao;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @AtkMeele.started += instance.OnAtkMeele;
            @AtkMeele.performed += instance.OnAtkMeele;
            @AtkMeele.canceled += instance.OnAtkMeele;
            @AtkRanged.started += instance.OnAtkRanged;
            @AtkRanged.performed += instance.OnAtkRanged;
            @AtkRanged.canceled += instance.OnAtkRanged;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Movimentacao.started -= instance.OnMovimentacao;
            @Movimentacao.performed -= instance.OnMovimentacao;
            @Movimentacao.canceled -= instance.OnMovimentacao;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @AtkMeele.started -= instance.OnAtkMeele;
            @AtkMeele.performed -= instance.OnAtkMeele;
            @AtkMeele.canceled -= instance.OnAtkMeele;
            @AtkRanged.started -= instance.OnAtkRanged;
            @AtkRanged.performed -= instance.OnAtkRanged;
            @AtkRanged.canceled -= instance.OnAtkRanged;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private List<IPlayer2Actions> m_Player2ActionsCallbackInterfaces = new List<IPlayer2Actions>();
    private readonly InputAction m_Player2_Movimentacao;
    private readonly InputAction m_Player2_Jump;
    private readonly InputAction m_Player2_MeeleAtk;
    public struct Player2Actions
    {
        private @ControlesPlayer m_Wrapper;
        public Player2Actions(@ControlesPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movimentacao => m_Wrapper.m_Player2_Movimentacao;
        public InputAction @Jump => m_Wrapper.m_Player2_Jump;
        public InputAction @MeeleAtk => m_Wrapper.m_Player2_MeeleAtk;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void AddCallbacks(IPlayer2Actions instance)
        {
            if (instance == null || m_Wrapper.m_Player2ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player2ActionsCallbackInterfaces.Add(instance);
            @Movimentacao.started += instance.OnMovimentacao;
            @Movimentacao.performed += instance.OnMovimentacao;
            @Movimentacao.canceled += instance.OnMovimentacao;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @MeeleAtk.started += instance.OnMeeleAtk;
            @MeeleAtk.performed += instance.OnMeeleAtk;
            @MeeleAtk.canceled += instance.OnMeeleAtk;
        }

        private void UnregisterCallbacks(IPlayer2Actions instance)
        {
            @Movimentacao.started -= instance.OnMovimentacao;
            @Movimentacao.performed -= instance.OnMovimentacao;
            @Movimentacao.canceled -= instance.OnMovimentacao;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @MeeleAtk.started -= instance.OnMeeleAtk;
            @MeeleAtk.performed -= instance.OnMeeleAtk;
            @MeeleAtk.canceled -= instance.OnMeeleAtk;
        }

        public void RemoveCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer2Actions instance)
        {
            foreach (var item in m_Wrapper.m_Player2ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player2ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
    public interface IPlayerActions
    {
        void OnMovimentacao(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAtkMeele(InputAction.CallbackContext context);
        void OnAtkRanged(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMovimentacao(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMeeleAtk(InputAction.CallbackContext context);
    }
}
