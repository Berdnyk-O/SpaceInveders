using Assets.Scripts;
using UnityEngine;

public class Player : MonoBehaviour, IDestroyableObject
{
    public float Healt = 30;

    public GameObject BulletPrefab;
    public Transform LaunchOffset;

    private float _speed = 8f;

    [SerializeField] private Rigidbody _rigidbody;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(BulletPrefab, LaunchOffset.position, transform.rotation);
        }
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _speed, _rigidbody.velocity.y);
    }

    public void TakeDamage(float damage)
    {
        Healt -= damage;
        if (Healt <= 0)
        {
            Destroy(gameObject);
        }
    }
}
