using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_jogaeCtrl : MonoBehaviour
{
    private PlayerCtrl _playerctrl;
    private GameUI _gameUI;


    // Start is called before the first frame update
    void Start()
    {
        _playerctrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        _gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.transform.tag == "Player" && _playerctrl.Mouse_R == true)
        {
            Debug.Log("조개 잡았다");
            _gameUI.DispScore(5);
            Destroy(gameObject);

        }
    }
   
}
