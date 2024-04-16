using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;    // ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody;  // �̵��� ����� ������ٵ� ������Ʈ

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("�浹 ����");
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            // �������κ��� PlayerController ������Ʈ�� �������µ� �����ߴٸ�
            if (playerController != null)
            {
                // ���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.Die();
            }
        }
    }
}
