using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletData _bulletData = null;
    [SerializeField] private float speed = 1;
    private Vector3 _target = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    private Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_target != null)
        {
            _rigidbody.velocity = direction.normalized * speed;
        }
    }

    public void Shoot(Vector3 target)
    {
        _target = target;
        direction = _target - transform.position;
    }

    public void OnCollisionEnter(Collision collision)
    {      
        float force = _bulletData.Force;
        direction = direction.normalized * force;
        collision.gameObject.GetComponentInParent<HitSystem>().EnableRagedoll();
        collision.rigidbody.AddForceAtPosition(direction, transform.position);
        Destroy(gameObject);
    }
}
