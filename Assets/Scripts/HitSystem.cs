using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSystem : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodys = null;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void EnableRagedoll()
    {
        foreach (Rigidbody rb in _rigidbodys)
        {
            rb.isKinematic = false;
        }

        Time.timeScale = 0.3f;
    }

}
