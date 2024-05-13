using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;     // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText;               // 생존시간 표시할 텐스트 컴포넌트
    public Text recordText;             // 최고 기록을 표시할 텐스트 컴포넌트

    private float surviverTime;         // 생존 시간
    private bool isGameOver;            // 게임오버 상태

    public GameObject playerDie;

    void Start()
    {
        // 생존 시간과 게임오버 상태 초기화
        surviverTime = 0;
        isGameOver = false;
    }

    void Update()
    {
        // 게임오버가 아닌 동안
        if (!isGameOver)
        {       
            // 생존 시간 갱신
            surviverTime += Time.deltaTime;

            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
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
        // 현재 상태를 게임오버 상태로 전환
        isGameOver = true;

        // 게임 오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive (true);

        // BestTIme 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviverTime > bestTime)
        {
            // 최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviverTime;

            // 변경된 최고 가록을 BestTIme 키로 지정
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "BestTIme : " + (int)bestTime;

        playerDie.SetActive(true);
    }
}
