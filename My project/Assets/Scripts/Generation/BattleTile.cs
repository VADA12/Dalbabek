using UnityEngine;

public class BattleTile : MonoBehaviour
{
    public Vector2Int gridPos;
    public bool isWalkable = true;
    public GameObject currentUnit = null;

    public void SetHighlight(bool active, Color color)
    {
        GetComponent<Renderer>().material.color = active ? color : Color.white;
    }
}
