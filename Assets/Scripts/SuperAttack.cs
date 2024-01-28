using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAttack : MonoBehaviour, IAttack
{
     public int superAttackValue = 10;
    public GameObject circlePrefab;
    public float growDuration = 2f;
    public float attackDelay = 1f;
    public float afterDelay;
    public ParticleSystem particleSystem;
    public RagdollController ragdollController;

    public void Attack(Transform target)
    {
        StartCoroutine(GrowAndAttack(target));
        GetComponent<Animator>().SetTrigger("Super1");
    }

    IEnumerator GrowAndAttack(Transform target)
    {
        GameObject circle = Instantiate(circlePrefab, transform.position, Quaternion.identity);

        float timer = 0f;
        float initialScale = 0f;

        while (timer < growDuration)
        {
            float scale = Mathf.Lerp(initialScale, 30f, timer / growDuration);
            circle.transform.localScale = new Vector3(scale, 0.66f, scale);
            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(attackDelay);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 15f);
        foreach (var hitCollider in hitColliders)
        {
            Stat targetStat = hitCollider.GetComponent<Stat>();
            if (targetStat != null)
            {
                // Применяем урон к цели
                targetStat.TakeDamage(20*GameManager.Instance.curLvl);
                ragdollController.ActivateRagdollForDuration(3f);
            }
        }

        Destroy(circle);
        particleSystem.Play();
        yield return new WaitForSeconds(afterDelay);
        GetComponent<Controller>().canDefaultAttack = true;
        Debug.Log("Суперудар!1");
    }
}