using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 5f;

    // �v���C���[�̎Q��
    private Player player;

    void Start()
    {
        // �V�[����̃v���C���[���擾
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        // �������Ɉړ�
        transform.position += Vector3.left * speed * Time.deltaTime;

        // �����蔻����`�F�b�N
        if (player != null && CheckCollisionWithPlayer())
        {
            // ����������e������
            Destroy(gameObject);
        }
    }

    // �v���C���[�Ƃ̓����蔻��
    private bool CheckCollisionWithPlayer()
    {
        // �e�̈ʒu��_�Ƃ݂Ȃ��ăv���C���[�̋�`�Ɣ���
        Vector2 bulletPosition = transform.position;
        Rect playerRect = player.GetPlayerRect();

        return playerRect.Contains(bulletPosition);
    }
}
