using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float offsetRotation;
    private Rigidbody rb;
    [SerializeField]
    private GameObject armature;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(GameManager.Instance.work)
        {
        MoveCharacter();
        }
    }

    void MoveCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput > 0)
        {
            RotateAnimation(-90);
            armature.transform.localRotation = new Quaternion(0,-offsetRotation,0,1);
        }
        else if (horizontalInput < 0)
        {
            RotateAnimation(90);
            armature.transform.localRotation = new Quaternion(0,offsetRotation,0,1);
        }
        else
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            armature.transform.localRotation = new Quaternion(0,0,0,1);
        }

        if (verticalInput > 0)
        {
            animator.SetBool("Forward", true);
            animator.SetBool("Back", false);
        }
        else if (verticalInput < 0)
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Back", true);
        }
        else
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Back", false);
        }

        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        Vector3 movement = (forwardMovement + rightMovement).normalized;

        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);
    }

    void RotateAnimation(float rotationAmount)
    {
        animator.SetBool("Right", rotationAmount < 0);
        animator.SetBool("Left", rotationAmount > 0);

    }
}