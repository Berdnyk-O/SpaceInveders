using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4f;

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if(collision.collider.tag == "enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
