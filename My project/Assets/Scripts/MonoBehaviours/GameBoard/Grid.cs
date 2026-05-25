using Scripts.CellLogic;
using Scripts.Factories;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameBoardLogic
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] private Vector2Int m_CellSize;
        [SerializeField] private float m_spacing;

        [Space]

        [SerializeField] private Cell m_prefab;

        [Space]

        [SerializeField] private Transform m_root;

        [Space]

        [SerializeField] private List<Cell> m_cells;

        private readonly GameBoardFactory m_factory = new();

        private void OnValidate()
        {
            m_CellSize = new((int)Mathf.Clamp(m_CellSize.x, 0, Mathf.Infinity), (int)Mathf.Clamp(m_CellSize.y, 0, Mathf.Infinity));
            m_spacing = Mathf.Clamp(m_spacing, 0, Mathf.Infinity);

            if (m_root == null)
            {
                m_root = transform;
            }
        }

        [ContextMenu("Create")]
        public void Create()
        {
            Clear();

            m_cells = m_factory.Create(m_prefab, m_CellSize, m_spacing, m_root);
        }

        [ContextMenu("Clear")]
        public void Clear()
        {
            for (int i = 0; i < m_cells.Count;)
            {
                DestroyImmediate(m_cells[i].GameObject);

                m_cells.RemoveAt(i);
            }
        }
    }
}
