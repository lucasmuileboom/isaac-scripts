using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyDeath;
    private EnemyDropBlood enemyDropBlood;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer SpriteRenderer;
    private int health = 10;
    private float timer;
    [SerializeField]
    private float colortimer;
    private bool timeron = false;

    private void Awake()
    {
        enemyDropBlood = GetComponent<EnemyDropBlood>();
        _rigidbody = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (timeron)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SpriteRenderer.color = Color.white;
                timeron = false;
            }
        }        
    }
    public void Takedamage(int damage, Vector2 startposision)
    {
        KnockBack(startposision);
        ChangeColor();
        health -= damage;
        if (health <= 0)//ga dood
        {
            Instantiate(enemyDeath, transform.position, Quaternion.Euler(0, 0, 0));
            enemyDropBlood.DropBloodOnDeath();            
            Destroy(this.gameObject);
        }
        //print(health);
    }
    private void KnockBack(Vector2 startposision)//hij telepoort te erg
    {
        float x = startposision.x - transform.position.x;
        float y = startposision.y - transform.position.y;
        _rigidbody.AddForce(new Vector2(-x,-y).normalized /5, ForceMode2D.Force);
    }
    private void ChangeColor()
    {
        SpriteRenderer.color = Color.red;
        timer = colortimer;
        timeron = true;
    }
} 