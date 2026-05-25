using UnityEngine;
namespace Scripts.StateMachines
{
    public class StateMachine
    {
        public event StateHandler OnStateChanged;
        public delegate void StateHandler(IState state, IState oldState);


        private IState m_curentState;
        private IState m_oldState;

        public IState CurrentState => m_curentState;
        public IState OldState => m_oldState;

        public void ChangeState(IState state)
        {
            m_oldState = m_curentState;
            
            m_curentState.Exit();

            m_curentState = state;

            state.Enter();

            OnStateChanged?.Invoke(CurrentState, OldState);

        }

        public void Initialize(IState startState)
        {
            m_curentState = startState;

            startState.Enter();
        }

        public void Update()
        {
            m_curentState.Update();
        }
    }
}
