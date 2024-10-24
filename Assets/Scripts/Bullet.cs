using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4f;

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HIT"); 
        Destroy(gameObject);
    }
}
