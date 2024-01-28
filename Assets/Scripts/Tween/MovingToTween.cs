using UnityEngine;
using DG.Tweening;

public class MovingToTween : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public float duration = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveAndRotateToTarget();
        }
    }

    void MoveAndRotateToTarget()
    {
        transform.DOMove(targetPosition, duration)
            .SetEase(Ease.Linear)  
            .OnComplete(() => Debug.Log("Перемещение завершено")); 

        transform.DORotate(targetRotation, duration)
            .SetEase(Ease.Linear); 
    }
}