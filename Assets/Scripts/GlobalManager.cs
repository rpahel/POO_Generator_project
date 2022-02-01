using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    private static GameManager _gameInstance = null;
    private static UIManager _uiInstance = null;

    public static GameManager GameInstance { get => _gameInstance; }
    public static UIManager UIInstance { get => _uiInstance; }

    private void Awake()
    {
        _gameInstance = FindObjectOfType<GameManager>();
        _uiInstance = FindObjectOfType<UIManager>();

        if (_gameInstance)
        {
            Debug.Log("GameManager object found: " + _gameInstance.name);
        }
        else
        {
            Debug.Log("No GameManager object found.");
        }

        if (_uiInstance)
        {
            Debug.Log("UIManager object found: " + _uiInstance.name);
        }
        else
        {
            Debug.Log("No UIManager object found.");
        }
    }
}
