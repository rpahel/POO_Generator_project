using UnityEngine;
using TMPro;

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

    private GameObject[] _savedSheetsbuttons; // TU T ES ARRETE ICI 
    private SheetScript[] _sheetScripts = new SheetScript[3];
    private int _selectedSheetNb;
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
        GlobalManager.GameInstance.GenerateBasicInfo();
        
        int i = 0;
        _buttonFirstGeneration.SetActive(false);
        foreach(var button in _buttonsGenerate)
        {
            button.SetActive(true);
        }
        foreach(var spot in _generatorSheetSpots)
        {
            GameObject newSheet = Instantiate(_sheet, spot);
            _sheetScripts[i] = newSheet.GetComponent<SheetScript>();
            _sheetScripts[i]._sheetNb = i;
            _sheetScripts[i].UpdateBasicInfo();
            i++;
        }
    }

    public void GenerateCharacters()
    {
        GlobalManager.GameInstance.GenerateBasicInfo();
        for(int i = 0; i < _sheetScripts.Length; i++)
        {
            _sheetScripts[i].UpdateBasicInfo();
        }
    }

    public void GenerateTraits()
    {
        GlobalManager.GameInstance.GenerateTraits();
        for (int i = 0; i < _sheetScripts.Length; i++)
        {
            _sheetScripts[i].UpdateTraits();
        }
    }

    public void GenerateEquipment()
    {
        GlobalManager.GameInstance.GenerateEquipment();
        for (int i = 0; i < _sheetScripts.Length; i++)
        {
            _sheetScripts[i].UpdateEquipment();
        }
    }

    public void SavedSheets()
    {
        _generatorScreen.SetActive(false);
        _savedSheetsScreen.SetActive(true);
        for(int i = 0; i < GlobalManager.GameInstance._keptCharacters.Count; i++)
        {
            GameObject newButton = Instantiate(_buttonSavedSheet, _buttonSavedSheetsSpots[i]);
            newButton.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = GlobalManager.GameInstance._keptCharacters[i].GetCharacteristics.Find(x => x.Name == "characterName").Value;
        }
    }

    public void ShowSelectedSheet(int sheetNb)
    {
        _selectedSheetNb = sheetNb;
        _generatorScreen.SetActive(false);
        _selectedSheetScreen.SetActive(true);
        GameObject newSheet = Instantiate(_sheet, _selectedSheetSpot);
        SheetScript selectedSheet = newSheet.GetComponent<SheetScript>();
        selectedSheet._sheetNb = sheetNb;
        selectedSheet.UpdateBasicInfo();
        selectedSheet.UpdateEquipment();
        selectedSheet.UpdateTraits();
    }

    public void KeepSheet()
    {
        if(GlobalManager.GameInstance._keptCharacters.Count == 10)
        {
            //GlobalManager.GameInstance._keptCharacters.RemoveAt(0);
            GlobalManager.GameInstance._keptCharacters.Clear();
        }

        GlobalManager.GameInstance._keptCharacters.Add(GlobalManager.GameInstance.GeneratedCharacters[_selectedSheetNb]);
    }

    public void Back()
    {
        _generatorScreen.SetActive(true);
        _selectedSheetScreen.SetActive(false);
        _savedSheetsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
