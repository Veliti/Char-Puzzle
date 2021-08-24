using System;
using UnityEngine;

public class BoxGrid : MonoBehaviour
{
    public enum GridLayout
    {
        Vertical,
        Horizontal
    }

    [SerializeField]
    private GridLayout _layout;

    [SerializeField]
    private int _maxInRow, _maxInColumn;
    [SerializeField]
    private float _boxSize = 5f;
    private GameObject[] _content;

    public void SetContent(GameObject[] content)
    {
        ClearGrid();
        _content = content;
        UpdateGrid();
    }

    private void ClearGrid()
    {
        if (_content != null)
        {
            for (int i = 0; i < _content.Length; i++)
            {
                Destroy(_content[i]);
            }
        }
    }

    private void UpdateGrid()
    {
        int maxInLine;
        Vector3 centeringOffset;
        int lainsAmmount() => Mathf.CeilToInt((float)_content.Length / (float)maxInLine);
        switch (_layout)
        {
            case GridLayout.Vertical:
                maxInLine = _maxInColumn;
                centeringOffset = new Vector3(x: -(maxInLine - 1) * _boxSize / 2f, y: (lainsAmmount() - 1) * _boxSize / 2f);
                for (int i = 0; i < _content.Length; i++)
                {
                    _content[i].transform.position = new Vector3(x: (i % maxInLine) * _boxSize,
                                                                 y: -(i / maxInLine) * _boxSize) + centeringOffset;
                }
                break;

            case GridLayout.Horizontal:
                maxInLine = _maxInRow;
                centeringOffset = new Vector3(x: -(lainsAmmount() - 1) * _boxSize / 2f, y: (maxInLine - 1) * _boxSize / 2f);
                for (int i = 0; i < _content.Length; i++)
                {
                    _content[i].transform.position = new Vector3(x: (i / maxInLine) * _boxSize,
                                                                 y: -(i % maxInLine) * _boxSize) + centeringOffset;
                }
                break;
                
            default:
                return;
        }
    }
}


