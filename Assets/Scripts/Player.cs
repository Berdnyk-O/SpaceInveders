using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform LaunchOffset;

    private float _speed = 8f;

    [SerializeField] private Rigidbody2D _rigidbody;

    private void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            Debug.LogWarning("Fire)");
            Instantiate(BulletPrefab, LaunchOffset.position, transform.rotation);
        }
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _speed, _rigidbody.velocity.y);
    }
}
