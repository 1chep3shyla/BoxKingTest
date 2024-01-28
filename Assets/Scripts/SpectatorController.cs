using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorController : MonoBehaviour
{
    public string[] nameAnim;
    void Start()
    {
        GetComponent<Animator>().Play(nameAnim[Random.Range(0,nameAnim.Length)]);
    }
}
