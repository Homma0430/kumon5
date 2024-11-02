using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5f;

    void Update()
    {
        // 弾を右方向に移動
        transform.position += Vector3.right * speed * Time.deltaTime;

        // シーン上のすべての敵と当たり判定をチェック
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            if (CheckCollisionWithEnemy(enemy))
            {
                enemy.TakeDamage(); // 敵にダメージを与える
                Destroy(gameObject); // 弾を消滅させる
                break;
            }
        }
    }

    // 敵との当たり判定
    private bool CheckCollisionWithEnemy(Enemy enemy)
    {
        Vector2 bulletPosition = transform.position; // 弾の位置
        Rect enemyRect = enemy.GetEnemyRect();       // 敵の矩形領域

        return enemyRect.Contains(bulletPosition); // 敵の矩形内に弾があるかどうかを判定
    }
}
