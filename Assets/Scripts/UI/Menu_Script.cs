using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    public bool _canKeyDown = true;
    public bool _onPause;
    public GameObject _panMenu;
    public GameObject _panUI;
    public GameObject _panDie;
    public GameObject _panWin;
    void Start()
    {
        Time.timeScale = 1f;
        _panDie.SetActive(false);
        _panMenu.SetActive(false);
        _panWin.SetActive(false);
        _panUI.SetActive(true);
        _onPause = false;
        GetComponent<Saves>().Save();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.P)) && _canKeyDown)
        {
            if (!_onPause)
                Pause();
            else
                UnPause();
        }
    }

    public void Pause()
    {
        _panMenu.SetActive(true);
        _panUI.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        _onPause = true;
    }

    public void UnPause()
    {
        _panMenu.SetActive(false);
        _panUI.SetActive(true);
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        _onPause = false;
        GetComponent<Saves>().Save();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameObject.scene.name);
    }
    public void Die()
    {
        _canKeyDown = false;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _panUI.SetActive(false);
        _panDie.SetActive(true);
    }

    public void Win()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _panUI.SetActive(false);
        _panWin.SetActive(true);
    }
}
