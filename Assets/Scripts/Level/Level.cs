using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelGenerator), typeof(BoxGrid))]
public class Level : MonoBehaviour
{
    public UnityTaskAction OnGameStarted;
    public UnityTaskAction OnGameEnded;
    public UnityTaskAction OnNewLevelStarted;

    [SerializeField]
    private List<LevelData> _startingLevels;

    private BoxGrid _grid;
    private LevelGenerator _levelGerenrator;
    private Queue<LevelData> _levelQueue;
    private GameObject[] _gameContent;

    private void Awake()
    {
        _grid = GetComponent<BoxGrid>();
        _levelGerenrator = GetComponent<LevelGenerator>();
    }

    private void Start()
    {
        ReStartGame();
    }

    private async void ReStartGame()
    {
        _levelQueue = new Queue<LevelData>(_startingLevels);
        await OnGameStarted?.TaskInvoke();
        StartNextLevel();
    }

    public async void StartNextLevel()
    {
        if (_levelQueue.Count == 0)
        {
            await OnGameEnded?.TaskInvoke();
            ReStartGame();
        }
        else
        {
            await OnNewLevelStarted?.TaskInvoke();

            DestroyAnArray(_gameContent);
            _gameContent = _levelGerenrator.GenerateCards(_levelQueue.Dequeue(), level: this);
            _grid.SetContent(_gameContent);      
        }
    }


    private void DestroyAnArray(GameObject[] gameObjects)
    {
        if (gameObjects != null)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }
        }
    }
}
