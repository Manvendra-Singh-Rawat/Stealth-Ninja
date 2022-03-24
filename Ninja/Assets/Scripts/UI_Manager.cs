using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text lvl_pass;
    [SerializeField]
    private Text busted;

    [SerializeField]
    private Text detect;

    private GameManager _gamemanager;

    
    // Start is called before the first frame update
    void Start()
    {
        detect.text = "DETECTION: " + 0;
        _gamemanager = GameObject.Find("gamemanager").GetComponent<GameManager>();
        lvl_pass.gameObject.SetActive(false);
        busted.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lvl_passed()
    {
        lvl_pass.gameObject.SetActive(true);
    }

    public void _busted()
    {
        busted.gameObject.SetActive(true);
    }

    public void restart()
    {
        _gamemanager.restart();
    }

    public void start_the_game()
    {
        _gamemanager.startgame();
    }

    public void goto_menu()
    {
        _gamemanager.menu();
    }
    public void _detection(float asdf)
    {
        detect.text = "DETECTION: " + asdf;
    }
}
