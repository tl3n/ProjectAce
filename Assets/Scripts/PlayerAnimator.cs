using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerMovement;
using UnityEngine.U2D;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    public SpriteRenderer sprite; //very questionable public, probably should refactor to private
    [SerializeField] private PlayerMovement player;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        
        animator.SetInteger("movementState", (int)player.returnMovementState());
    }
}
