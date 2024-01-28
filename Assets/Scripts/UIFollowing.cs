using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowing : MonoBehaviour
{
     public float speed = 5f; // Скорость движения HealthBar
    public Transform target; // Целевой объект, за которым будет двигаться HealthBar
    public Vector2 offset = new Vector2(0f, 20f); // Смещение HealthBar относительно цели

    private RectTransform healthBarRectTransform;

    void Start()
    {
        healthBarRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (target != null)
        {
            MoveHealthBar();
        }
    }

    void MoveHealthBar()
    {
        Vector2 targetScreenPosition = Camera.main.WorldToScreenPoint(target.position);

        targetScreenPosition += offset;

        Vector2 newPosition = Vector2.Lerp(healthBarRectTransform.anchoredPosition, targetScreenPosition, Time.deltaTime * speed);
        healthBarRectTransform.anchoredPosition = newPosition;
    }
}