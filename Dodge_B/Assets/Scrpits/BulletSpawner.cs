using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;     // 생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;   // 최소 생성 주기
    public float spawnRateMax = 3.0f;     // 최대 생성 주기

    private Transform target;           // 발사할 대상
    private float spawnRate;            // 생성 주기
    private float TimeAfterSpawn;       // 최근 생겅 시점에서 지난 시간

    public AudioSource audioPlayer;

    void Start()
    {
        // 최근 생성 이후 누적시간을 0으로 초기화
        TimeAfterSpawn = 0f;

        // 탄알 생성 간격을 spawnRoteMin과 spawnRoteMax 사이에서 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;

        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        // TimeAfterSpawn 갱신
        TimeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if (TimeAfterSpawn > spawnRate) 
        {
            // 마지막 탄환 발사 이후 시간을 0으로 돌리고
            TimeAfterSpawn = 0f;

            // 탄환을 생성하고, 캐릭터(target)을 바라보도록 방향 전환
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            // 다음 탄환 생성 주기 값(spawnRate를 최소(0.5초) 최대(0.3초) 범위에서 랜덥 값으로 결정작업 진행)
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            // 포탄 생성시 포탄 발사음 실행
            audioPlayer.Play();
        }
    }
}
