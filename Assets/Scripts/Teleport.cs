using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Teleport : MonoBehaviour
{
    public CinemachineVirtualCamera cm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = new Vector3(-452.8f, -2.03f, 0);
            cm.transform.position = Player.instance.transform.position;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
