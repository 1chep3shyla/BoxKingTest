using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DefaultAttack : MonoBehaviour, IAttack
{
    public int dmg;
    public float attackRange = 4f;
    public float Delay;
    public float attackCooldown = 0.14f;
    public float multiply;
    public GameObject particleAttackPrefab; 
    public GameObject textMeshPrefab;
    public Transform attackSpawn;
    private bool canAttack = true;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack(Transform target)
    {
        if(!GameManager.Instance.end)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if (distanceToPlayer < attackRange && canAttack)
            {
                StartCoroutine(AttackCoroutine(target));  
                canAttack = false;
            }
        }

    }

    private IEnumerator AttackCoroutine(Transform target)
    {
            animator.SetTrigger("Attack");      
            if(particleAttackPrefab !=null)
            {
                yield return new WaitForSeconds(Delay);

                int totalDMG = (int)((float)dmg * multiply);

                GameObject particleAttackInstance = Instantiate(particleAttackPrefab, attackSpawn.position, Quaternion.identity);

                Vector3 textOffset = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), Random.Range(-1f,1f));
                GameObject textMeshDmg = Instantiate(textMeshPrefab, attackSpawn.position + textOffset, Quaternion.identity);
                textMeshDmg.GetComponent<TextMeshPro>().text = totalDMG.ToString("");
                target.gameObject.GetComponent<Stat>().TakeDamage(totalDMG);

                Destroy(particleAttackInstance, 0.5f);
                Destroy(textMeshDmg, 0.5f);

                yield return new WaitForSeconds(Delay);

                GameObject particleAttackInstance1 = Instantiate(particleAttackPrefab, attackSpawn.position, Quaternion.identity);

                Vector3 textOffset1 = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), Random.Range(-1f,1f));
                GameObject textMeshDmg1 = Instantiate(textMeshPrefab, attackSpawn.position + textOffset1, Quaternion.identity);
                textMeshDmg1.GetComponent<TextMeshPro>().text = totalDMG.ToString("");
                target.gameObject.GetComponent<Stat>().TakeDamage(totalDMG);
                GameManager.Instance.money +=2;
                Destroy(particleAttackInstance1, 0.5f);
                Destroy(textMeshDmg1, 0.5f);
            }
            else
            {
                yield return new WaitForSeconds(Delay);
                int totalDMG = dmg;
                target.gameObject.GetComponent<Stat>().TakeDamage(totalDMG);
                yield return new WaitForSeconds(Delay);
                target.gameObject.GetComponent<Stat>().TakeDamage(totalDMG);
            }
            multiply += 0.1f;
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}