using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump3 : MonoBehaviour
{
    bool flag = false;
    bool flag2 = false;
    float artis = 0.001f, artis2 = 0.001f;
    float artis3 = 0.001f, artis4 = 0.001f;
    Animator animator;
    GameObject player;
    [SerializeField] private AnimatorOverrideController[] animatorOverrides;
    private void Start()
    {
        flag = false;
        flag2 = false;
        artis = 0.01f;
        artis2 = 0.01f;
        artis3 = 0.01f;
        artis4 = 0.01f;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (flag)
        {
            animator.runtimeAnimatorController = animatorOverrides[1];
            if (Move.playerY < 3f && !flag2)
            {
                if (Move.playerY > 0.3f && Move.playerY < 0.8f)
                {
                    transform.localScale = new Vector3(transform.localScale.x, 1.5f, transform.localScale.z);
                }
                Move.playerY += Time.deltaTime + artis2;
                artis2 += artis;
            }
            else
            {
                if (player.transform.position.y <= 0.3f)
                {
                    flag = false;
                    animator.runtimeAnimatorController = animatorOverrides[0];
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x, 0.7f, transform.localScale.z);
                    flag2 = true;
                    Move.playerY -= Time.deltaTime + artis4;
                    artis4 += artis3;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            flag = true;
        }
    }
}
