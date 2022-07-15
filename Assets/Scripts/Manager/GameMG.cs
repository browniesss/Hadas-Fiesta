using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMG : Singleton<GameMG>
{
    public float PlayTime;  //플레이 시간 저장
    private float time_start;
    private float time_current;
    private float time_Max = 5f;
    private bool isEnded;

    //플레이 시간
    private void Check_Timer()
    {
        time_current = Time.time - time_start;
        if (time_current < time_Max)
        {
           // text_Timer.text = $"{time_current:N2}";
            Debug.Log(time_current);
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }

    private void End_Timer()
    {
        Debug.Log("End");
        time_current = time_Max;
       // text_Timer.text = $"{time_current:N2}";
        isEnded = true;
    }


    private void Reset_Timer()
    {
        time_start = Time.time;
        time_current = 0;
      //  text_Timer.text = $"{time_current:N2}";
        isEnded = false;
        Debug.Log("Start");
    }

    void startGame()
    {
        // 게임 저장데이터
        //게임필드
        //캐릭터 생성
        // UI매니저 호출
    }

    //로딩 씬 만들기
    //로딩중 

    //게임종료 저장

    //몬스터 캐릭터 로드
    
    //몬스터랑 캐릭터 만드는 규칙
    //스탯종류가 어떤지 역할 
    //캐릭터 
    //스탯 클래스 
    //스킬 데이터 계산

    public void Damage_calculator()
    {
        //데미지= (가해)공격력 - (피해)방어력 
    }

    void Update()
    {
        if (isEnded)
            return;

        Check_Timer();
    }


    void Start()
    {
        Reset_Timer();
    }

}
