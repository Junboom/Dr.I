using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTorch : MonoBehaviour
{


    // 구분



    private int Count = 0;
    public static int EmNum;
    private float speedUpLookTime, speedDownLookTime;
    private float startLookTime;
    private float rTorchHitTime;
    private float lTorchHitTime;
    public static bool StartBool = false;
    private FOVELookSample leftTorch, rightTorch;
    private bool a, b;

    

    private enum LeftRight 
    {
        LEFT_TORCH = 0,
        RIGHT_TORCH = 1,
        NEITHER_TORCH = 2
    };

    LeftRight whichTorch;

    //    NumBucket  NumBucket = GameObject.Find("NumBucket").GetComponent<NumBucket>();
    //   private int a = NumBucket.SwitchTimeMethod(4);
    private float SwitchTime = 3;
    public static float AfterSwitchTime = 3;



    private void Awake()
    {

    }
    void Start()
    {
        a = true;
        b = true;
        whichTorch = LeftRight.NEITHER_TORCH;
        leftTorch = GameObject.Find("RealLTorch").GetComponent<FOVELookSample>();
        rightTorch = GameObject.Find("RealRTorch").GetComponent<FOVELookSample>();

    }

    void Update()
    {
        Routine();
    }

    public void SwitchFocus()
    {
        Debug.Log("스위치포커스");
        InvokeRepeating("LightOn", 0f, SwitchTime);
        //에미션을  키는 함수를 SwitchTime 초마다 실행시킨다    
        Count = 0;
    }


    public void LightOn()
    {
        
        if (Count < 6)
        {
            if (Count % 2 == 0)
            {
               // Debug.Log("왼쪽 에미션");
                //Debug.Log("현재 카운트" + Count);

                rightTorch.emissionOff();
                rightTorch.fire.SetActive(false);
                leftTorch.emissionOn();
                //왼쪽 에미션 켜지는 함수
                whichTorch = LeftRight.RIGHT_TORCH; //에미션을 없애고 라이트를 키기위한 판별자 
                Count++;
                G2Score_Manager.AllTimes++; // 횟수 ++ 
            }
            else
            {
                Debug.Log("오른쪽 에미션");
                Debug.Log("현재 카운트" + Count);

                leftTorch.emissionOff();
                leftTorch.fire.SetActive(false);
                rightTorch.emissionOn();
                //오른쪽 에미션 켜지는 함수
                Count++;
                whichTorch = LeftRight.LEFT_TORCH;
                G2Score_Manager.AllTimes++;
            }
        }
        else
        {
            Debug.Log("에미션 루틴 종료");
            // Count = 0; //반복 하기위한 카운트 초기화
            leftTorch.emissionOff();
            rightTorch.emissionOff();
            leftTorch.fire.SetActive(false);
            rightTorch.fire.SetActive(false);
            CancelInvoke("LightOn");
            GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEventColliderEnabled(true);
            whichTorch = LeftRight.NEITHER_TORCH;
            G2Score_Manager.howManyTimesTorch = 1;
            G2Score_Manager.corutinStarter = true;
        }


    }


    //클릭하면 에미션이 사라지고 라이트가 나오는 코드
    void FireOn()
    {

        RaycastHit hit;
        if (whichTorch == LeftRight.RIGHT_TORCH) //왼쪽 에미션에 불이 들어왔을경우
        {
            if (Physics.Raycast(RayManager.rays.left, out hit, Mathf.Infinity, 1 << 8) ||
                    Physics.Raycast(RayManager.rays.right, out hit, Mathf.Infinity, 1 << 8)) 
            {
                lTorchHitTime += Time.deltaTime; // 히트타임 생성

                if (lTorchHitTime > 1) //1초 이상 맞췄을 경우 아래 코드 실행 
                {
                    leftTorch.emissionOff();
                    //왼쪽 에미션 사라지는 코드
                    // 왼쪽 라이트 켜지는 코드
                     if (a)                
                     {
                        a = false;
                        G2Score_Manager.HitTimes++; //본 횟수 ++
                        Debug.Log(G2Score_Manager.HitTimes);
                        b = true;
                     }
            
                    lTorchHitTime = 0;
                    
                }

            }
            else lTorchHitTime = 0;

        }
        else if(whichTorch == LeftRight.LEFT_TORCH)//오른쪽 에미션에 불이 들어왔을 경우
        {
            if (Physics.Raycast(RayManager.rays.left, out hit, 100f, 1 << 9) ||
                    Physics.Raycast(RayManager.rays.right, out hit, 100f, 1 << 9))
            {
                rTorchHitTime += Time.deltaTime; //

                if (rTorchHitTime > 1)
                {
                    rightTorch.emissionOff();
                    //오른쪽 에미션 사라지는 코드
                    //+오른쪽 라이트 켜지는 코드 
                    //if (lTorchHitTime < 3)
                    if(b)
                    {
                        b = false;
                        G2Score_Manager.HitTimes++; //본 횟수 ++
                        a = true;
                    }
                    rTorchHitTime = 0;
                   

                }
            }
            else rTorchHitTime = 0;



        }

    }

    void SpeedUpDown()
    {


        RaycastHit hit;
        if (Physics.Raycast(RayManager.rays.left, out hit, 100f, 1 << 10) ||
                Physics.Raycast(RayManager.rays.right, out hit, 100f, 1 << 10))
        {
            speedUpLookTime += Time.deltaTime; //

            if (speedUpLookTime > 2)
            {
                AfterSwitchTime *= 0.8f;
                StarMove.SideToSide *= 0.8f;
                if (AfterSwitchTime < 2.5) AfterSwitchTime = 2.5f;
                TextManager.beginning = TextManager.showStringSec * 7f;
                speedUpLookTime = 0;
            }
        }
        else speedUpLookTime = 0;

        if (Physics.Raycast(RayManager.rays.left, out hit, 100f, 1 << 15) ||
                Physics.Raycast(RayManager.rays.right, out hit, 100f, 1 << 15))
        {
            speedDownLookTime += Time.deltaTime; //

            if (speedDownLookTime > 2)
            {
                AfterSwitchTime /= 0.8f;
                StarMove.SideToSide /= 0.8f;
                if (AfterSwitchTime > 10) AfterSwitchTime = 10f;
                TextManager.beginning = TextManager.showStringSec * 8f;
                speedDownLookTime = 0;
            }
        }
        else speedDownLookTime = 0;

    }

 

    void StartGame()
    {

        RaycastHit hit;

        if (Physics.Raycast(RayManager.rays.left, out hit, 100f, 1 << 11) ||
                Physics.Raycast(RayManager.rays.right, out hit, 100f, 1 << 11))
        {
            startLookTime += Time.deltaTime; //

            if (startLookTime > 2)
            {
                TextManager.beginning = TextManager.showStringSec * 9f;
                startLookTime = 0;
            }
        }
        else startLookTime = 0;

    }

    void Routine()
    {
        SpeedUpDown();
        StartGame();
        FireOn();
        if (Count<6 &&Count >0 )
        {
            G2Score_Manager.TorchGameTime += Time.deltaTime; //홱보기 운동 시간 체크 \

        }
        if (StartBool)
        {
            StartBool = false;
            a = true;
            b = true;
            SwitchFocus();
        }
       

        if (SwitchTime != AfterSwitchTime)
        {
            SwitchTime = AfterSwitchTime;
            //속도가 올라갔습니다 안내문 
            Debug.Log("속도가 증가됩니다");
        }



    }

}


