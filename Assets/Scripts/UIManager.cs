using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject _sheet;
    [SerializeField]
    private GameObject _buttonSavedSheet;
    [Space(20)]

    [Header("Generator Screen")]
    [SerializeField]
    private GameObject _generatorScreen;
    [SerializeField]
    private GameObject _buttonFirstGeneration;
    [SerializeField]
    private GameObject[] _buttonsGenerate;
    [SerializeField]
    private RectTransform[] _generatorSheetSpots;
    [Space(20)]

    [Header("Selected Sheet Screen")]
    [SerializeField]
    private GameObject _selectedSheetScreen;
    [SerializeField]
    private RectTransform _selectedSheetSpot;
    [Space(20)]

    [Header("Saved Sheets Screen")]
    [SerializeField]
    private GameObject _savedSheetsScreen;
    [SerializeField]
    private RectTransform[] _buttonSavedSheetsSpots;

    private void Awake()
    {
        _generatorScreen.SetActive(true);
        _buttonFirstGeneration.SetActive(true);
        foreach (var button in _buttonsGenerate)
        {
            button.SetActive(false);
        }
        _selectedSheetScreen.SetActive(false);
        _savedSheetsScreen.SetActive(false);
    }

    public void FirstGenerate()
    {
        int i = 0;
        _buttonFirstGeneration.SetActive(false);
        foreach(var button in _buttonsGenerate)
        {
            button.SetActive(true);
        }
        foreach(var spot in _generatorSheetSpots)
        {
            GameObject newSheet = Instantiate(_sheet, spot);
            newSheet.GetComponent<SheetScript>()._sheetNb = i++;
        }
    }

    public void GenerateCharacters()
    {
        //
    }

    public void GenerateTraits()
    {
        //
    }

    public void GenerateEquipment()
    {
        //
    }

    public void SavedSheets()
    {
        _generatorScreen.SetActive(false);
        _savedSheetsScreen.SetActive(true);
        foreach(var spot in _buttonSavedSheetsSpots)
        {
            Instantiate(_buttonSavedSheet, spot);
        }
    }
}
