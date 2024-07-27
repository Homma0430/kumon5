using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // ’e‚Ì‘¬“x

    void Update()
    {
        // ‰E•ûŒü‚ÉˆÚ“®‚·‚é
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
