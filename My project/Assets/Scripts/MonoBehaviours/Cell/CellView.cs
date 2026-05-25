using UnityEngine;
using System.Collections;
using Scripts.CellLogic;
using Scripts.StateMachines;
using Scripts.StateMachines.CellStates;

namespace Scripts.Celllogic
{
    public class CellView : MonoBehaviour
    {
        [Header("Dat")]
        [SerializeField] private Color m_defaultColor = Color.white;
        [SerializeField] private Color m_enterColor = Color.white;
        [SerializeField] private Color m_selectedColor = Color.white;
        [SerializeField] private Color m_selectEnterColor = Color.white;

        [Header("Component")]
        [SerializeField] private SpriteRenderer m_spriteRenderer;
        [SerializeField] private Cell m_cell;

        private void OnEnable()
        {
            m_cell.StateChanged += (state, oldstate, sender) => SetColorByState(state, sender.PointerEnter);
            m_cell.PointerChanged += (pointerEnter, sender) => SetColorByState(sender.CurrentState, pointerEnter);
        }

        private void OnDisable()
        {
            m_cell.StateChanged += (state, oldstate, sender) => SetColorByState(state, sender.PointerEnter);
            m_cell.PointerChanged += (pointerEnter, sender) => SetColorByState(sender.CurrentState, pointerEnter);
        }

        private void OnValidate()
        {
            if(m_spriteRenderer == null)
            {
                m_spriteRenderer = GetComponent<SpriteRenderer>();
            }

            if (m_cell == null)
            {
                m_cell = GetComponent<Cell>();
            }
        }

        private void SetColorByState(IState cellState, bool pointerEnter)
        {
            m_spriteRenderer.color = (cellState, pointerEnter) switch
            {
                (DefaultState, true) => m_enterColor,
                (DefaultState, _) => m_defaultColor,
                (SelectedState, true) => m_selectEnterColor,
                (SelectedState, _) => m_selectedColor,
                _ => m_spriteRenderer.color,
            };
        }

    }
}
