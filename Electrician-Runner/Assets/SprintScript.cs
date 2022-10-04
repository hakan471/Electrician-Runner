using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintScript : MonoBehaviour
{
    public GameObject busbar;
    Animator animator;
    [SerializeField] private AnimatorOverrideController[] animatorOverrides;
    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Move.speed = 0.4f;
            Coin.moveSpeed = 34;
            animator.runtimeAnimatorController = animatorOverrides[0];
            busbar.SetActive(true);
        }
    }
}
