using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_boomctrl : MonoBehaviour
{
    private S_CamShake s_cam;
    private PlayerCtrl _playerctrl;

    private AudioSource audioSource;

    public GameObject explosion;

    private MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mesh = GetComponent<MeshRenderer>();
        s_cam = GameObject.Find("Main Camera").GetComponent<S_CamShake>();
        _playerctrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Player")
        {
            
            s_cam.VibrateForTime(1.5f);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            Instantiate(explosion, transform.position, transform.rotation);
            Invoke("playerInit", 1.5f);

            mesh.enabled=false;

        }
    }

    void playerInit()
    {

        if((int)_playerctrl.playerState==2)
        {
            _playerctrl.High_Mouse();
            Destroy(gameObject);
        }
        else
        {
            _playerctrl.PlayerInit();
            Destroy(gameObject);
        }

    }
}
