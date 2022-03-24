using UnityEngine;
using UnityEngine.AI;

public class touch_movement_player : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private NavMeshAgent _myagent;

    private bool is_moving = false;

    [SerializeField]
    private int lvl;

    [SerializeField]
    private float detection_lvl = 0;

    private player_animation _player_animation;

    private GameManager _gamemanager;

    private UI_Manager UI_handler;
    void Start()
    {
        _myagent = GetComponent<NavMeshAgent>();
        UI_handler = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _player_animation = GameObject.Find("LowpolyNinjaCrouch_Idle").GetComponent<player_animation>();
        _gamemanager = GameObject.Find("gamemanager").GetComponent<GameManager>();

        _gamemanager.currnetlvl(lvl);
    }

    void Update()
    {
        playermovement();
    }

    private void playermovement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                _myagent.SetDestination(hit.point);
                is_moving = true;
            }
        }
        if(_myagent.remainingDistance <= _myagent.stoppingDistance)
        {
            _player_animation.stop_move();
        }
        else
        {
            _player_animation.movement();
        }
    }

    public void detection()
    {
        detection_lvl = detection_lvl + Time.deltaTime;
        UI_handler._detection(detection_lvl);

        if(detection_lvl >= 2.0f)
        {
            UI_handler._busted();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "lvl passed")
        {
            UI_handler.lvl_passed();
            _gamemanager.next_lvl(lvl + 1);
        }
    }
}
