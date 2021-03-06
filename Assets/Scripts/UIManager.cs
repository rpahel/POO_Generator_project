using UnityEngine;
using TMPro;
using Data;

public class UIManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject _sheet;
    [SerializeField]
    private GameObject _buttonSavedSheet;
    [SerializeField]
    private GameObject _moreInfoBox;
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
    [SerializeField]
    private GameObject _keepButton;
    [Space(20)]

    [Header("Saved Sheets Screen")]
    [SerializeField]
    private GameObject _savedSheetsScreen;
    [SerializeField]
    private RectTransform[] _buttonSavedSheetsSpots;

    private GameObject[] _savedSheetsbuttons;
    private SheetScript[] _sheetScripts = new SheetScript[3];
    private int _selectedSheetNb;
    private GameObject _loadedKeptSheet;
    private GameObject _newInfoBox;

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

        _buttonFirstGeneration.SetActive(false);
        foreach(var button in _buttonsGenerate)
        {
            button.SetActive(true);
        }
        for(int i = 0; i < _generatorSheetSpots.Length; i++)
        {
            GameObject newSheet = Instantiate(_sheet, _generatorSheetSpots[i]);
            _sheetScripts[i] = newSheet.GetComponent<SheetScript>();
            _sheetScripts[i]._sheetNb = i;
            _sheetScripts[i].UpdateBasicInfo();
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
        _savedSheetsbuttons = new GameObject[GlobalManager.GameInstance._keptCharacters.Count];
        for(int i = 0; i < GlobalManager.GameInstance._keptCharacters.Count; i++)
        {
            GameObject newButton = Instantiate(_buttonSavedSheet, _buttonSavedSheetsSpots[i]);
            newButton.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = GlobalManager.GameInstance._keptCharacters[i].GetCharacteristics.Find(x => x.Name == "characterName").Value;
            newButton.GetComponent<KeptSheetButtonScript>()._buttonNb = i;
            _savedSheetsbuttons[i] = newButton;
        }
    }

    public void ShowSelectedSheet(int sheetNb)
    {
        _selectedSheetNb = sheetNb;
        _generatorScreen.SetActive(false);
        _selectedSheetScreen.SetActive(true);
        _keepButton.SetActive(true);
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
            GlobalManager.GameInstance._keptCharacters.RemoveAt(0);
        }

        Character keptCharacter = ObjectCopier.Clone(GlobalManager.GameInstance.GeneratedCharacters[_selectedSheetNb]);

        GlobalManager.GameInstance._keptCharacters.Add(keptCharacter);

        _keepButton.SetActive(false);
    }

    public void LoadKeptSheet(int position)
    {
        if (_loadedKeptSheet)
        {
            Destroy(_loadedKeptSheet);
        }

        _loadedKeptSheet = Instantiate(_sheet, _savedSheetsScreen.transform);
        _loadedKeptSheet.GetComponent<SheetScript>()._isLoadedSheet = true;
        _loadedKeptSheet.GetComponent<SheetScript>().LoadInfo(position);
    }

    public void CreateInfoBox(RectTransform location, string info)
    {
        _newInfoBox = Instantiate(_moreInfoBox, location);
        _newInfoBox.transform.SetParent(this.gameObject.transform, true);
        _newInfoBox.transform.GetChild(1).GetComponent<TMP_Text>().text = info;
    }

    public void DeleteInfoBox()
    {
        Destroy(_newInfoBox);
    }

    public void Back()
    {
        _generatorScreen.SetActive(true);
        _selectedSheetScreen.SetActive(false);
        _savedSheetsScreen.SetActive(false);

        if(_savedSheetsbuttons != null)
        {
            for (int i = 0; i < _savedSheetsbuttons.Length; i++)
            {
                if (_savedSheetsbuttons[i] != null)
                {
                    Destroy(_savedSheetsbuttons[i]);
                }
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
