using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // �e�̑��x

    void Update()
    {
        // �E�����Ɉړ�����
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
