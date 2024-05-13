using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;     // ������ ź���� ���� ������
    public float spawnRateMin = 0.5f;   // �ּ� ���� �ֱ�
    public float spawnRateMax = 3.0f;     // �ִ� ���� �ֱ�

    private Transform target;           // �߻��� ���
    private float spawnRate;            // ���� �ֱ�
    private float TimeAfterSpawn;       // �ֱ� ���� �������� ���� �ð�

    public AudioSource audioPlayer;

    void Start()
    {
        // �ֱ� ���� ���� �����ð��� 0���� �ʱ�ȭ
        TimeAfterSpawn = 0f;

        // ź�� ���� ������ spawnRoteMin�� spawnRoteMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform;

        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        // TimeAfterSpawn ����
        TimeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (TimeAfterSpawn > spawnRate) 
        {
            // ������ źȯ �߻� ���� �ð��� 0���� ������
            TimeAfterSpawn = 0f;

            // źȯ�� �����ϰ�, ĳ����(target)�� �ٶ󺸵��� ���� ��ȯ
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            // ���� źȯ ���� �ֱ� ��(spawnRate�� �ּ�(0.5��) �ִ�(0.3��) �������� ���� ������ �����۾� ����)
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            // ��ź ������ ��ź �߻��� ����
            audioPlayer.Play();
        }
    }
}
