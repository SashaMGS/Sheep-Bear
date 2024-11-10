using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsScript : MonoBehaviour
{
    public bool _hotKeys;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && _hotKeys)
        {
            PlayerPrefs.DeleteAll();
            gameObject.GetComponent<Saves>()._currentLevel = 1;
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.Y) && _hotKeys)
        {
            gameObject.GetComponent<Saves>()._maxLevel = 10;
            SceneManager.LoadScene("Menu");
        }
    }

    public void GoMenu()
    {
        gameObject.GetComponent<Saves>().Save();
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        gameObject.GetComponent<Saves>().Save();
        SceneManager.LoadScene(gameObject.GetComponent<Saves>()._currentLevel);
    }

    public void StartNewLevel()
    {
        Saves _saves = gameObject.GetComponent<Saves>();
        if (_saves._currentLevel < 10)
        {
            if (_saves._currentLevel == _saves._maxLevel)
            {
                _saves._currentLevel++;
                _saves._maxLevel++;
            }
            else if (_saves._currentLevel < _saves._maxLevel)
                _saves._currentLevel++;
            _saves.Save();
            SceneManager.LoadScene("Game");
        }
        else
            GoMenu();
    }

    public void MuteAudio()
    {
        GameObject.FindGameObjectWithTag("AudioObj").GetComponent<AudioSource>().mute = true;
    }
    public void UnMuteAudio()
    {
        GameObject.FindGameObjectWithTag("AudioObj").GetComponent<AudioSource>().mute = false;
    }
}
