using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public TMP_Text _curLvl_Txt;
    public GameObject[] _lockLvls;
    [HideInInspector] public Saves _saves;

    public TMP_Text _soundTxt;
    public Slider _soundSlider;

    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GameObject.FindGameObjectWithTag("AudioObj").GetComponent<AudioSource>();
        _saves = GetComponent<Saves>();
        _curLvl_Txt.text = _saves._maxLevel.ToString();
        _soundSlider.value = _saves._audio;

        for (int i = 0; i < _lockLvls.Length; i++)
        {
            if(_saves._maxLevel - 2 >= i)
                _lockLvls[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        _soundTxt.text = _soundSlider.value.ToString("0.0");
        _saves._audio = _soundSlider.value;
        _audioSource.volume = _saves._audio;
    }

    public void GoLevel(int level)
    {
        if (_saves._maxLevel >= level)
        {
            _saves._currentLevel = level;
            _saves.Save();
            SceneManager.LoadScene("Game");
        }
    }
}
