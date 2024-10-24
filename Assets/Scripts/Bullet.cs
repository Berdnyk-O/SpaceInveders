using Assets.Scripts;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4f;

    private float _damage = 10;

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.TryGetComponent(out IDestroyableObject enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }
}
