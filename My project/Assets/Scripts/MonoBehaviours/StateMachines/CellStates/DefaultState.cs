using UnityEngine;
using Scripts.StateMachines;
using System.Collections;
using Scripts.CellLogic;
using UnityEngine.EventSystems;

namespace Scripts.StateMachines.CellStates
{
    public class DefaultState : IState
    {

        private readonly StateMachine m_stateMachine;
        private readonly Cell m_cell;

        public DefaultState(StateMachine stateMachine, Cell cell)
        {
            m_stateMachine = stateMachine;
            m_cell = cell;
        }
        public void Enter()
        {
            m_cell.PointerClick += Select;
        }

        public void Exit()
        {
            m_cell.PointerClick -= Select;
        }

        public void Update()
        {
        }

        private void Select(PointerEventData eventData)
        {
            m_stateMachine.ChangeState(m_cell.SelectedState);
        }
    }
}
