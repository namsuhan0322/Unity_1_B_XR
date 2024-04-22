using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;   // �÷��̾� ������Ʈ�� �ִ� RigidBody ������Ʈ�� �����ϱ� ���� ����
    public float speed = 8f;        // �̵� �ӵ� ��ġ ���� �����ϴ� ����

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {        
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3 (xSpeed, 0, zSpeed);

        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()       // �÷��̾� ĳ���Ͱ� ����� ȣ��ǰ� �� �κ� ������ ó����.
    {
        // �ڽ��� ���� ������Ʋ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
