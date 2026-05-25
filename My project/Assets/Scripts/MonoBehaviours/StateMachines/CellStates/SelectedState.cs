using Scripts.CellLogic;
using Scripts.StateMachines;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.StateMachines.CellStates
{
    public class SelectedState : IState
    {
        private readonly StateMachine m_stateMachine;
        private readonly Cell m_cell;

        public SelectedState(StateMachine stateMachine, Cell cell)
        {
            m_stateMachine = stateMachine;
            m_cell = cell;
        }

        public void Enter()
        {
            m_cell.PointerClick += UnSelect;
        }

        public void Exit()
        {
            m_cell.PointerClick -= UnSelect;
        }

        public void Update()
        {
        }

        private void UnSelect(PointerEventData eventData)
        {
            m_stateMachine.ChangeState(m_cell.DefaultState);
        }
    }
}
