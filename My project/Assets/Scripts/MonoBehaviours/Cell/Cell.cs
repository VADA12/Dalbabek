using Scripts.StateMachines;
using Scripts.StateMachines.CellStates;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.CellLogic
{
    public class Cell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public event StateHandler StateChanged;
        public event PointerStateHandler PointerChanged;

        public event PointerHandler PointerClick;

        public delegate void StateHandler(IState state, IState oldstate, Cell sender);
        public delegate void CellHandler(Cell sender);

        public delegate void PointerStateHandler(bool pointerEnter, Cell sender);
        public delegate void PointerHandler(PointerEventData eventData);

        [Header("Data")]
        [SerializeField] private Vector2Int m_position;

        [Header("Components")]
        [SerializeField] private GameObject m_gameObject;

        private StateMachine m_stateMachine;

        private DefaultState m_defaultState;
        private SelectedState m_selectedState;

        private bool m_pointerEnter;

        public GameObject GameObject => m_gameObject;

        public IState CurrentState => m_stateMachine.CurrentState;

        public DefaultState DefaultState => m_defaultState;
        public SelectedState SelectedState => m_selectedState;

        public bool PointerEnter => m_pointerEnter;

        private void Awake()
        {
            m_stateMachine = new();

            m_stateMachine.OnStateChanged += (state, oldstate) => StateChanged?.Invoke(state, oldstate, this);

            m_defaultState = new(m_stateMachine, this);
            m_selectedState = new(m_stateMachine, this);

            m_stateMachine.Initialize(m_defaultState);
        }

        private void OnValidate()
        {
            if(m_gameObject == null)
            {
                m_gameObject = gameObject;
            }
        }

        public void Initialize(Vector2Int position)
        {
            m_position = position;

            m_gameObject.name = $"x: {position.x}, y: {position.y}";
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PointerClick?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_pointerEnter = true;

            PointerChanged?.Invoke(PointerEnter, this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_pointerEnter = false;

            PointerChanged?.Invoke(m_pointerEnter, this);
        }
    }
}
