using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab; // �v���C���[�����˂���e��Prefab
    public Transform firePoint;     // �e�𔭎˂���ʒu

    // �v���C���[�̋�`�T�C�Y
    public Vector2 playerSize = new Vector2(1.0f, 1.0f); // �v���C���[�̕��ƍ���

    void Update()
    {
        // ���N���b�N�Œe�𔭎�
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    // �e�𔭎˂��郁�\�b�h
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    // �v���C���[�̋�`�̈ʒu�����擾
    public Rect GetPlayerRect()
    {
        return new Rect(
            (Vector2)transform.position - playerSize / 2, // ���S�����`���v�Z
            playerSize
        );
    }
}
