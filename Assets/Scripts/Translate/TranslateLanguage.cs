using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslateLanguage : MonoBehaviour
{
    public GameObject[] _Txts;
    private Saves _saves;

    private Dictionary<string, string> translationsEn;
    private Dictionary<string, string> translationsRu;

    private GameObject[] _gmLang;

    private void Awake()
    {
        _gmLang = GameObject.FindGameObjectsWithTag("gmLang");
    }

    void Start()
    {

        _saves = GetComponent<Saves>();
        // ������������� ����������� ������� � ����������
        translationsEn = new Dictionary<string, string>
        {
            {"Menu_label", "Menu"},
            {"Settings_Txt", "Settings"},
            {"SoundLabel_Txt", "Sound"},
            {"Resume_But_Txt", "Play"},
            {"Lang_Txt", "Language"},
            {"Die_Txt", "Failed"},
            {"Die_But_Txt", "Again"},
            {"Win_Txt", "Win"},
            {"Win_But_Txt", "Next level"},
            {"HealthPl1_Txt", "Health sheep"},
            {"HealthPl2_Txt", "Health bear"},
            {"Move_Training_Txt", "Movement - \nA,D, left arrow, right arrow"},
            {"Jump_Training_Txt", "Jump - W, up arrow"},
            {"ChangePl_Training_Txt", "Character change - space, "},
            {"Win_Training_Txt", "To win, reach the collapsed wall with one of the characters"},
            {"MoveBox_Training_Txt", "The game involves moving objects"},
            {"Obstacles_Training_Txt", "Obstacles. they can reduce the player's health. if the health of one of the animals reaches the minimum, you lose"},
            {"Button_Training_Txt", "to open some walls, you must press the button"},
            {"ActiveButton_Training_Txt", "there are buttons that must be pressed continuously to open the wall"}
        };
        // ������������� �������� ������� � ����������
        translationsRu = new Dictionary<string, string>
        {
            {"Menu_label", "����"},
            {"Settings_Txt", "���������"},
            {"SoundLabel_Txt", "�����"},
            {"Resume_But_Txt", "������"},
            {"Lang_Txt", "����"},
            {"Die_Txt", "�����"},
            {"Die_But_Txt", "������"},
            {"Win_Txt", "������"},
            {"Win_But_Txt", "��������� �������"},
            {"HealthPl1_Txt", "�������� ������"},
            {"HealthPl2_Txt", "�������� �������"},
            {"Move_Training_Txt", "�������� - \n�,�, ������� �����, ������� ������"},
            {"Jump_Training_Txt", "������ - �, ������� �����"},
            {"ChangePl_Training_Txt", "����� ��������� - ������, "},
            {"Win_Training_Txt", "��� ������ ����� �� ����������� ����� ����� �� ����������"},
            {"MoveBox_Training_Txt", "� ���� ������������� ��������� �������"},
            {"Obstacles_Training_Txt", "�����������. ��� ����� ��������� �������� ������. ���� �������� ������ �� �������� ��������� ��������, �� ����������"},
            {"Button_Training_Txt", "����� ������� ��������� �����, ���������� ������ ������"},
            {"ActiveButton_Training_Txt", "������ ������, ������� ���������� �������� ���������, ����� ��������� �����"}
        };
        // ���������� ��������� ����
        UpdateAllText();  // ���������� ����� "hello" ��� ������
    }
    public void SetLanguage()
    {
        if (_saves._lang == "ru")
            _saves._lang = "en";
        else
            _saves._lang = "ru";
        UpdateAllText();  // �������� ����� ��� ����� �����
        _saves.Save();

    }

    public void UpdateAllText()
    {
        for (int i = 0; i < _Txts.Length; i++)
        {
            if (translationsRu.ContainsKey(_Txts[i].name) && translationsEn.ContainsKey(_Txts[i].name))
            {
                if (_saves._lang == "ru")
                {
                    _Txts[i].GetComponent<TMP_Text>().text = translationsRu[_Txts[i].name];
                }
                else
                {
                    _Txts[i].GetComponent<TMP_Text>().text = translationsEn[_Txts[i].name];
                }
            }
            else
            {
                _Txts[i].GetComponent<TMP_Text>().text = "Translation not found";
            }
        }
        foreach (var item in _gmLang)
        {
            item.GetComponent<TMP_Text>().text = UpdateCurText(item);
        }
    }

    public string UpdateCurText(GameObject gm)
    {
        if (translationsEn.ContainsKey(gm.name) && translationsRu.ContainsKey(gm.name))
        {
            if (_saves._lang == "ru")
            {
                return translationsRu[gm.name];
            }
            else
            {
                return translationsEn[gm.name];
            }
        }
        else
            return "Not found key";
    }
}
