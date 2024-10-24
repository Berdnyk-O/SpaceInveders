using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 8f;

    [SerializeField] private Rigidbody2D _rigidbody;
    
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _speed, _rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("fire");
        }
    }
}
