using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5f;

    void Update()
    {
        // �e���E�����Ɉړ�
        transform.position += Vector3.right * speed * Time.deltaTime;

        // �V�[����̂��ׂĂ̓G�Ɠ����蔻����`�F�b�N
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            if (CheckCollisionWithEnemy(enemy))
            {
                enemy.TakeDamage(); // �G�Ƀ_���[�W��^����
                Destroy(gameObject); // �e�����ł�����
                break;
            }
        }
    }

    // �G�Ƃ̓����蔻��
    private bool CheckCollisionWithEnemy(Enemy enemy)
    {
        Vector2 bulletPosition = transform.position; // �e�̈ʒu
        Rect enemyRect = enemy.GetEnemyRect();       // �G�̋�`�̈�

        return enemyRect.Contains(bulletPosition); // �G�̋�`���ɒe�����邩�ǂ����𔻒�
    }
}
