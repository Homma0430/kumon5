using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 5f;

    // プレイヤーの参照
    private Player player;

    void Start()
    {
        // シーン上のプレイヤーを取得
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        // 左方向に移動
        transform.position += Vector3.left * speed * Time.deltaTime;

        // 当たり判定をチェック
        if (player != null && CheckCollisionWithPlayer())
        {
            // 当たったら弾を消滅
            Destroy(gameObject);
        }
    }

    // プレイヤーとの当たり判定
    private bool CheckCollisionWithPlayer()
    {
        // 弾の位置を点とみなしてプレイヤーの矩形と判定
        Vector2 bulletPosition = transform.position;
        Rect playerRect = player.GetPlayerRect();

        return playerRect.Contains(bulletPosition);
    }
}
