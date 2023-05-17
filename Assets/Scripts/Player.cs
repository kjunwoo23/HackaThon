using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float playerSize;
    public float playerSpeed;
    public bool isWalk;
    public Animator animator;
    public bool move = true;
    // Start is called before the first frame update
    public GameObject[] location;

    void Start()
    {
        instance = this;
        transform.position = new Vector2(getPositionX(PlayerPrefs.GetInt("savePoint")), -2);
    }

    float getPositionX(int index)
    {
        return location[index].transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && move)
        {
            if (EffectManager.instance.effectSounds[1].source.isPlaying != true)
                EffectManager.instance.effectSounds[1].source.Play();
            animator.SetBool("walking", true);
            transform.position += new Vector3(1, 0, 0) * playerSpeed * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 0) * playerSize;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && move)
        {
            if (EffectManager.instance.effectSounds[1].source.isPlaying != true)
                EffectManager.instance.effectSounds[1].source.Play();
            animator.SetBool("walking", true);
            transform.position += new Vector3(-1, 0, 0) * playerSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 0) * playerSize;
        }
        else
        {
            EffectManager.instance.effectSounds[1].source.Stop();
            animator.SetBool("walking", false);

        }
    }
}
