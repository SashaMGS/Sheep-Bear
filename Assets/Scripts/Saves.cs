using UnityEngine;

public class Saves : MonoBehaviour
{
    public int _coins;
    public float _audio;
    public string _lang;
    public int _currentLevel;
    public int _maxLevel;

    private void Awake()
    {
        LoadSave();
    }

    public void Save()
    {
        PlayerPrefs.SetString("lang", _lang);
        PlayerPrefs.SetInt("coins", _coins);
        PlayerPrefs.SetFloat("audio", _audio);
        PlayerPrefs.SetInt("currentLevel", _currentLevel);
        PlayerPrefs.SetInt("maxLevel", _maxLevel);
        PlayerPrefs.Save();
        Debug.Log("Save successfully");
    }

    public void LoadSave()
    {
        _lang = PlayerPrefs.GetString("lang", "ru");
        _coins = PlayerPrefs.GetInt("coins", 0);
        _currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        _maxLevel = PlayerPrefs.GetInt("maxLevel", 1);
        _audio = PlayerPrefs.GetFloat("audio", 0.5f);
        Debug.Log("Load successfully");
    }
}
