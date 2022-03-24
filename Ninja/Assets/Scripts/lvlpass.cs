using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlpass : MonoBehaviour
{
    private GameManager _gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        _gamemanager = GameObject.Find("gamemanager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(_gamemanager.current_lvl == 2)
            {
                _gamemanager.menu();
            }
            else
            _gamemanager.next_lvl(1 + _gamemanager.current_lvl);
        }
    }
}
