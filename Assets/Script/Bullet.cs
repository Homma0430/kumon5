using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // 弾の速度

    void Update()
    {
        // 右方向に移動する
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
