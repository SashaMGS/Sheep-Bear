using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;

public class Ui_Script : MonoBehaviour
{
    public bool _isMobileInput;

    public TMP_Text _curLevelTxt;

    public Slider _sliderHpPl1;
    public Slider _sliderHpPl2;

    private HpScript _hpPl1;
    private HpScript _hpPl2;

    public GameObject _mobileInput;

    public TMP_Text _soundTxt;
    public Slider _soundSlider;

    private AudioSource _audioSource;

    private void Awake()
    {
        //_isMobileInput = YandexGame.EnvironmentData.isMobile;
    }

    private void Start()
    {
        _audioSource = GameObject.FindGameObjectWithTag("AudioObj").GetComponent<AudioSource>();
        _soundSlider.value = GetComponent<Saves>()._audio;
        _mobileInput.SetActive(_isMobileInput);

        _curLevelTxt.text = GetComponent<Saves>()._currentLevel.ToString();

        _hpPl1 = GameObject.FindGameObjectWithTag("Player_1").GetComponent<HpScript>();
        _hpPl2 = GameObject.FindGameObjectWithTag("Player_2").GetComponent<HpScript>();

        _sliderHpPl1.maxValue = _hpPl1._hp;
        _sliderHpPl2.maxValue = _hpPl2._hp;
    }

    private void Update()
    {
        if (_hpPl1 != null)
            _sliderHpPl1.value = _hpPl1._hp;
        if (_hpPl2 != null)
            _sliderHpPl2.value = _hpPl2._hp;

        _soundTxt.text = _soundSlider.value.ToString("0.0");
        GetComponent<Saves>()._audio = _soundSlider.value;
        _audioSource.volume = GetComponent<Saves>()._audio;
    }
}
