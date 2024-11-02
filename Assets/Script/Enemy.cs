using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // �G�̒e��Prefab
    [SerializeField] private Transform player;        // �v���C���[��Transform

    private float shootDistance;                      // ���ˊJ�n����
    private float shootInterval = 1.0f;               // ���ˊԊu
    private bool isShooting = false;                  // ���˒��t���O

    public Vector2 enemySize = new Vector2(1.0f, 1.0f); // �G�̋�`�T�C�Y
    private int health = 3;                            // �G�̃��C�t

    void Start()
    {
        shootDistance = Camera.main.orthographicSize * Camera.main.aspect / 2; // ���ˋ���
    }

    void Update()
    {
        // �v���C���[�Ƃ̋����𑪂�A�e�̔��˂��J�n�܂��͒�~
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
            Instantiate(bulletPrefab, transform.position, Quaternion.identity); // �e�𐶐�
            yield return new WaitForSeconds(shootInterval);
        }
    }

    // �G�̋�`�̈ʒu�����擾
    public Rect GetEnemyRect()
    {
        return new Rect(
            (Vector2)transform.position - enemySize / 2, // ���S�����`���v�Z
            enemySize
        );
    }

    // �v���C���[�̒e�������������̏���
    public void TakeDamage()
    {
        health--; // ���C�t������
        if (health <= 0)
        {
            Destroy(gameObject); // ���C�t��0�ɂȂ�����G������
        }
    }
}
