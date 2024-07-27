using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; 

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
