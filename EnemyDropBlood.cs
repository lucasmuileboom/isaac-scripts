using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropBlood : MonoBehaviour
{
    [SerializeField] private GameObject[] blood;
    [SerializeField] private GameObject[] bloodondead;
    [SerializeField] private GameObject[] Bodypartondead;
    [SerializeField] private float bloodtimer;
    private float timer = 0;
    [SerializeField]private float dropdistance;

    void Start ()
    {
        timer = bloodtimer;
    }
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            DropBlood();
            timer = bloodtimer;
        }
    }
    public void DropBloodOnDeath()
    {
        Instantiate(bloodondead[Random.Range(0, bloodondead.Length)], transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(Bodypartondead[Random.Range(0, Bodypartondead.Length)], new Vector3(transform.position.x - Random.Range(-dropdistance, dropdistance), transform.position.y - Random.Range(-dropdistance, dropdistance), transform.position.z), Quaternion.Euler(0, 0, 0));
    }
    private void DropBlood()
    {
        Instantiate(blood[Random.Range(0, blood.Length)],transform.position, Quaternion.Euler(0,0,0));//moet nog het bot laten dropen       
    }
}
