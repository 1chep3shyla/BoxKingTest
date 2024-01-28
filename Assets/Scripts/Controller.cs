using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform target;
    public IAttack currentAttack;
    public float coldownSuper;
    [SerializeField]
    private bool playerIs;
    public bool canDefaultAttack;

    void Update()
    {
        if(GameManager.Instance.work)
        {
            coldownSuper -= Time.deltaTime;
            if(canDefaultAttack)
            {
                Vector3 lookDirection = target.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = rotation;
                currentAttack = GetComponent<DefaultAttack>();
                currentAttack.Attack(target);
            }
            if (coldownSuper <= 0 && !playerIs)
            {
                Super();
                coldownSuper = Random.Range(8f,15f);
            }
        }

    }
    public void Super()
    {
        int i = Random.Range(0,3);

        if( i == 0)
        {
            currentAttack = GetComponent<SuperAttack>();
        }
        else if( i == 1)
        {
            currentAttack = GetComponent<SuperAttack>();
        }
        else if( i == 2)
        {
            currentAttack = GetComponent<SuperAttack>();
        }
        canDefaultAttack = false;
        currentAttack.Attack(target);
    }
}