using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayers : MonoBehaviour
{
    public bool _lookAtPl2;
    private PlayersController _player1;
    private PlayersController _player2;
    private SmoothCameraFollow _camera;

    private void Start()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player_1").GetComponent<PlayersController>();
        _player2 = GameObject.FindGameObjectWithTag("Player_2").GetComponent<PlayersController>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothCameraFollow>();

        GetComponent<InvisibleObjForPlayer>().HideObjsForPl2();
        GetComponent<InvisibleObjForPlayer>().ShowObjsForPl1();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayerChange();

        if (!_lookAtPl2)
        {
            _player1.canMove = true;
            _player2.canMove = false;
            _camera.target = _player1.gameObject.transform;
            _camera.offset = new Vector3(0, 4, -10);
        }
        else
        {
            _player1.canMove = false;
            _player2.canMove = true;
            _camera.target = _player2.gameObject.transform;
            _camera.offset = new Vector3(0, 4, 10);
        }
    }

    public void PlayerChange()
    {
        if (!_lookAtPl2)
        {
            GetComponent<InvisibleObjForPlayer>().HideObjsForPl1();
            GetComponent<InvisibleObjForPlayer>().ShowObjsForPl2();
            _lookAtPl2 = true;
        }
        else
        {
            GetComponent<InvisibleObjForPlayer>().HideObjsForPl2();
            GetComponent<InvisibleObjForPlayer>().ShowObjsForPl1();
            _lookAtPl2 = false;
        }
    }
}
