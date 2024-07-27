using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet��Prefab���A�T�C�����邽�߂̕ϐ�
    public Transform firePoint; // �e�̔��ˈʒu���w�肷�邽�߂�Transform

    void Update()
    {
        // �}�E�X�̍��N���b�N�������ꂽ�Ƃ��ɒe�𔭎˂���
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // �e�𔭎ˈʒu�ɐ�������
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
