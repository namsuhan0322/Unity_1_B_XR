using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;   // 플레이어 오브젝트에 있는 RigidBody 컴포넌트를 연결하기 위한 변수
    public float speed = 8f;        // 이동 속도 수치 값을 저장하는 변수

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {        
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3 (xSpeed, 0, zSpeed);

        // 리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()       // 플레이어 캐릭터가 사망시 호출되고 이 부분 내용이 처리됨.
    {
        // 자신의 게임 오브젝틀르 비활성화
        gameObject.SetActive(false);

        // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
