using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // 敵の弾のPrefab
    [SerializeField] private Transform player;        // プレイヤーのTransform

    private float shootDistance;                      // 発射開始距離
    private float shootInterval = 1.0f;               // 発射間隔
    private bool isShooting = false;                  // 発射中フラグ

    public Vector2 enemySize = new Vector2(1.0f, 1.0f); // 敵の矩形サイズ
    private int health = 3;                            // 敵のライフ

    void Start()
    {
        shootDistance = Camera.main.orthographicSize * Camera.main.aspect / 2; // 発射距離
    }

    void Update()
    {
        // プレイヤーとの距離を測り、弾の発射を開始または停止
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= shootDistance && !isShooting)
        {
            StartCoroutine(Shoot());
            isShooting = true;
        }
        else if (distanceToPlayer > shootDistance)
        {
            StopCoroutine(Shoot());
            isShooting = false;
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity); // 弾を生成
            yield return new WaitForSeconds(shootInterval);
        }
    }

    // 敵の矩形の位置情報を取得
    public Rect GetEnemyRect()
    {
        return new Rect(
            (Vector2)transform.position - enemySize / 2, // 中心から矩形を計算
            enemySize
        );
    }

    // プレイヤーの弾が当たった時の処理
    public void TakeDamage()
    {
        health--; // ライフを減少
        if (health <= 0)
        {
            Destroy(gameObject); // ライフが0になったら敵を消滅
        }
    }
}
