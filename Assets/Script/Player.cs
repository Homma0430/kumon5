using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab; // BulletのPrefabをアサインするための変数
    public Transform firePoint; // 弾の発射位置を指定するためのTransform

    void Update()
    {
        // マウスの左クリックが押されたときに弾を発射する
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 弾を発射位置に生成する
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
