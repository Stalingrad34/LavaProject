using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Transform shootPoint = null; 

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject bul = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                bul.GetComponent<Bullet>().Shoot(hit.point);
                Debug.Log(Input.mousePosition);
            }
        }

    }
}
