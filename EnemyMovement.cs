using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private float settimer;
    private Animator animator;
    private float timer = 0;
    private Rigidbody2D _Rigidbody;
    private Vector2 move;
    private Vector2[] directions =
    {
        new Vector2(1, 0),
        new Vector2(-1, 0),
        new Vector2(0, 1),
        new Vector2(0, -1),
        new Vector2(1, 1).normalized,
        new Vector2(-1,-1).normalized,
        new Vector2(1, -1).normalized,
        new Vector2(-1, 1).normalized,
    };

    private void Awake ()
    {
        animator = GetComponent<Animator>();
        _Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GetDirection(Random.Range(0, 8));
            timer = settimer;
        }
        Move(); 
    }
    private void Move()
    {
        _Rigidbody.velocity = move * speed;
    }
    private void GetDirection(int direction)
    {
        move = directions[direction];
        if (direction == 2 || direction == 3)//down / up
        {
            animator.SetBool("up", true);
            animator.SetBool("left", false);
        }
        else//left / right
        {
            animator.SetBool("up", false);
            animator.SetBool("left", true);
            if (direction == 1 || direction == 5 || direction == 7)//left
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else//right
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}