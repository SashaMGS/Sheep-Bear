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
        // Инициализация английского словаря с переводами
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
        // Инициализация русского словаря с переводами
        translationsRu = new Dictionary<string, string>
        {
            {"Menu_label", "Меню"},
            {"Settings_Txt", "Настройки"},
            {"SoundLabel_Txt", "Звуки"},
            {"Resume_But_Txt", "Играть"},
            {"Lang_Txt", "Язык"},
            {"Die_Txt", "Погиб"},
            {"Die_But_Txt", "Заново"},
            {"Win_Txt", "Победа"},
            {"Win_But_Txt", "Следующий уровень"},
            {"HealthPl1_Txt", "Здоровье овечки"},
            {"HealthPl2_Txt", "Здоровье медведя"},
            {"Move_Training_Txt", "Движение - \nФ,В, стрелка влево, стрелка вправо"},
            {"Jump_Training_Txt", "Прыжок - Ц, стрелка вверх"},
            {"ChangePl_Training_Txt", "Смена персонажа - пробел, "},
            {"Win_Training_Txt", "Для победы дойди до разрушенной стены одним из персонажей"},
            {"MoveBox_Training_Txt", "В игре предусмотрены подвижные обьекты"},
            {"Obstacles_Training_Txt", "Препятствия. они могут уменьшать здоровья игрока. если здоровье одного из животных достигнет минимума, вы проиграете"},
            {"Button_Training_Txt", "чтобы открыть некоторые стены, необходимо нажать кнопку"},
            {"ActiveButton_Training_Txt", "бывают кнопки, которые необходимо зажимать постоянно, чтобы открылась стена"}
        };
        // Установите начальный язык
        UpdateAllText();  // Установите текст "hello" как пример
    }
    public void SetLanguage()
    {
        if (_saves._lang == "ru")
            _saves._lang = "en";
        else
            _saves._lang = "ru";
        UpdateAllText();  // Обновите текст при смене языка
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
