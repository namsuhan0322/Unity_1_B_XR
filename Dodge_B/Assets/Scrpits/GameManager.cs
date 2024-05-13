using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;     // ���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText;               // �����ð� ǥ���� �ٽ�Ʈ ������Ʈ
    public Text recordText;             // �ְ� ����� ǥ���� �ٽ�Ʈ ������Ʈ

    private float surviverTime;         // ���� �ð�
    private bool isGameOver;            // ���ӿ��� ����

    public GameObject playerDie;

    void Start()
    {
        // ���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        surviverTime = 0;
        isGameOver = false;
    }

    void Update()
    {
        // ���ӿ����� �ƴ� ����
        if (!isGameOver)
        {       
            // ���� �ð� ����
            surviverTime += Time.deltaTime;

            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time: " + (int)surviverTime;
        }
        else
        {
            gameoverText.SetActive(true);

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    { 
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameOver = true;

        // ���� ���� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive (true);

        // BestTIme Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviverTime > bestTime)
        {
            // �ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviverTime;

            // ����� �ְ� ������ BestTIme Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "BestTIme : " + (int)bestTime;

        playerDie.SetActive(true);
    }
}
