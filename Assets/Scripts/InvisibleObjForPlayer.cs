using UnityEngine;

public class InvisibleObjForPlayer : MonoBehaviour
{
    public GameObject _forest;
    public GameObject _newAge;
    public GameObject[] _levels_packs;
    public GameObject[] _objsPl1;
    public GameObject[] _objsPl2;

    private void Start()
    {
        _forest.SetActive(false);
        _newAge.SetActive(false);
        if (GetComponent<Saves>()._currentLevel <= 5)
            _forest.SetActive(true);
        else
            _newAge.SetActive(true);
        for (int i = 0; i <= _levels_packs.Length; i++)
        {
            if (i < _levels_packs.Length)
                _levels_packs[i].SetActive(false);
            if (GetComponent<Saves>()._currentLevel == i)
                _levels_packs[i - 1].SetActive(true);
        }
    }

    public void HideObjsForPl1()
    {
        for (int i = 0; i < _objsPl1.Length; i++)
        {
            _objsPl1[i].SetActive(false);
        }
    }

    public void ShowObjsForPl1()
    {
        for (int i = 0; i < _objsPl1.Length; i++)
        {
            _objsPl1[i].SetActive(true);
        }
    }

    public void HideObjsForPl2()
    {
        for (int i = 0; i < _objsPl2.Length; i++)
        {
            _objsPl2[i].SetActive(false);
        }
    }

    public void ShowObjsForPl2()
    {
        for (int i = 0; i < _objsPl2.Length; i++)
        {
            _objsPl2[i].SetActive(true);
        }
    }
}
