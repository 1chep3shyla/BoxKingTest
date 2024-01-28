using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Transform attackerTransform;
   private Animator animator;
    private Rigidbody[] ragdollRigidbodies;
    private Collider[] ragdollColliders;
    private Rigidbody playerRigidbody;
    private Collider playerCollider;
    private const float SuperAttackForce = 100;

    void Start()
    {
        animator = GetComponent<Animator>();
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        SetRagdollEnabled(false);
    }

    void SetRagdollEnabled(bool isEnabled)
    {
        foreach (var rb in ragdollRigidbodies)
        {
            rb.isKinematic = !isEnabled;
        }


        foreach (var collider in ragdollColliders)
        {
            collider.enabled = isEnabled;
        }

        playerRigidbody.isKinematic = isEnabled;
        playerCollider.enabled = !isEnabled;

        animator.enabled = !isEnabled;
    }

    public void ActivateRagdollForDuration(float duration)
    {
        StartCoroutine(ActivateRagdollCoroutine(duration));
    }

    IEnumerator ActivateRagdollCoroutine(float duration)
    {
        Vector3 forceDirection = transform.position - attackerTransform.position;
        forceDirection.y = 0f; 

        Vector3 force = forceDirection.normalized * SuperAttackForce;

        playerRigidbody.velocity = Vector3.zero;

        playerRigidbody.AddForce(force/5, ForceMode.Impulse);
        yield return new WaitForSeconds(0.005f);
        SetRagdollEnabled(true);

        yield return new WaitForSeconds(duration);

        SetRagdollEnabled(false);
    }

}