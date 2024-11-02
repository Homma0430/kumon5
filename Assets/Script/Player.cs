using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab; // プレイヤーが発射する弾のPrefab
    public Transform firePoint;     // 弾を発射する位置

    // プレイヤーの矩形サイズ
    public Vector2 playerSize = new Vector2(1.0f, 1.0f); // プレイヤーの幅と高さ

    void Update()
    {
        // 左クリックで弾を発射
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    // 弾を発射するメソッド
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    // プレイヤーの矩形の位置情報を取得
    public Rect GetPlayerRect()
    {
        return new Rect(
            (Vector2)transform.position - playerSize / 2, // 中心から矩形を計算
            playerSize
        );
    }
}
