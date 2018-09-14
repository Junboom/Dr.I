using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMove : MonoBehaviour
{

    // public float moveSpeed = 1f;
    public static bool starMoveSetActive = false;
    public static float acc_Time = 0; //kh
    public static float total_Time = 0; //kh
    float Count = 0;
    int stage = 0;
    float Direction = 0;
    float CurrentPos = 0;
    public static float SideToSide = 2f; // 물체가 한번 이동하는데 걸린 시간 
    float StartTime = 4f;
    bool b = true;
    private GameObject ScoreBoard;
    private GameObject CountBoard;
    private GameObject WaitingText;
    private GameObject Cube;
    private float startLookTime;

    Vector3 StartPos = new Vector3(0f, 2f, 1f);
    Vector3 TargetPos = new Vector3(4f, 2f, 1f);
    Vector3 StartPos2 = new Vector3(1.5f, 3f, 1f);
    Vector3 TargetPos2 = new Vector3(1.5f, 0.5f, 1f);
    Vector3 StartPos3 = new Vector3(0.5f, 3f, 1f);
    Vector3 TargetPos3 = new Vector3(3.5f, 0.5f, 1f);
    Vector3 StartPos4 = new Vector3(3.5f, 3f, 1f);
    Vector3 TargetPos4 = new Vector3(0.5f, 0.5f, 1f);


    private void Awake()//이게 만들어지면 한번만 실행되는 함수
    {
    }

    private void Start()
    {
        ScoreBoard = GameObject.Find("CubeScoreText");
        CountBoard = GameObject.Find("CubeCountDown");
        Cube = GameObject.Find("MovingCube");
        WaitingText = GameObject.Find("GetReadyText");
        WaitingText.SetActive(false);
        CountBoard.SetActive(false);
        Cube.SetActive(false);
        //starMoveSetActive = true;
    }
    private void Update() // 큐브 오브젝트가 호출되면 반복되는 함수 
    {
        Move();
    }


    public void Move()

    {
        if (starMoveSetActive)
        {
            CurrentPos += Time.deltaTime / SideToSide;
            Count += Time.deltaTime;
            Direction += Time.deltaTime;
            if (Direction < StartTime - 3) // 1
            {
                ObjectHiding();
                WaitingText.SetActive(true);

            }
            else if (Direction < StartTime - 2.9f) // 1.1
            {
                WaitingText.SetActive(false);
                G2Score_Manager.CountNum = 3.9f;

            }
            else if (Direction < StartTime) // 4
            {
                CountDown();
            }
            else if (Direction < StartTime + 0.1f) // 4.1
            {
                CountBoard.SetActive(false);
            }
            else if (Direction < StartTime + (SideToSide * 2f)) //10
            {
                Cube.SetActive(true);
                ScoreBoard.SetActive(true);
                if (stage % 2 == 0) Cube.transform.position = Vector3.Lerp(StartPos, TargetPos, CurrentPos);
                else Cube.transform.position = Vector3.Lerp(TargetPos, StartPos, CurrentPos);
                if (Count > SideToSide) NumReset();
            }
            else if (Direction < StartTime + (SideToSide * 2) + 1f) //11
            {
                ObjectHiding();
                WaitingText.SetActive(true);

            }
            else if (Direction < StartTime + (SideToSide * 2) + 1.1f) //11.1
            {
                WaitingText.SetActive(false);
                G2Score_Manager.CountNum = 3.9f;

            }
            else if (Direction < StartTime + (SideToSide * 2) + 4f) // 14
            {
                CountDown();
            }
            else if (Direction < StartTime + (SideToSide * 2) + 4.1f) // 14.1
            {
                CountBoard.SetActive(false);
            }
            else if (Direction < StartTime + (SideToSide * 4) + 4f)  // 20
            {
                Cube.SetActive(true);
                ScoreBoard.SetActive(true);
                if (stage % 2 == 0) Cube.transform.position = Vector3.Lerp(StartPos2, TargetPos2, CurrentPos);
                else Cube.transform.position = Vector3.Lerp(TargetPos2, StartPos2, CurrentPos);
                if (Count > SideToSide) NumReset();
            }
            else if (Direction < StartTime + (SideToSide * 4) + 5f) //21
            {
                ObjectHiding();
                WaitingText.SetActive(true);

            }
            else if (Direction < StartTime + (SideToSide * 4) + 5.1f) // 21.1
            {
                WaitingText.SetActive(false);
                G2Score_Manager.CountNum = 3.9f;

            }
            else if (Direction < StartTime + (SideToSide * 4) + 8f) // 24
            {
                CountDown();
            }
            else if (Direction < StartTime + (SideToSide * 4) + 8.1f) // 24.1
            {
                CountBoard.SetActive(false);
            }
            else if (Direction < StartTime + (SideToSide * 6) + 8f) // 30
            {

                Cube.SetActive(true);
                ScoreBoard.SetActive(true);
                if (stage % 2 == 0) Cube.transform.position = Vector3.Lerp(StartPos3, TargetPos3, CurrentPos);
                else Cube.transform.position = Vector3.Lerp(TargetPos3, StartPos3, CurrentPos);
                if (Count > SideToSide) NumReset();
            }
            else if (Direction < StartTime + (SideToSide * 6) + 9f) // 31
            {
                ObjectHiding();
                WaitingText.SetActive(true);

            }
            else if (Direction < StartTime + (SideToSide * 6) + 9.1f) //31.1
            {
                WaitingText.SetActive(false);
                G2Score_Manager.CountNum = 3.9f;

            }
            else if (Direction < StartTime + (SideToSide * 6) + 12f) // 34
            {
                CountDown();
            }
            else if (Direction < StartTime + (SideToSide * 6) + 12.1f) // 34.1
            {
                CountBoard.SetActive(false);
            }
            else if (Direction < StartTime + (SideToSide * 8) + 12f) //40
            {

                Cube.SetActive(true);
                ScoreBoard.SetActive(true);
                if (stage % 2 == 0) Cube.transform.position = Vector3.Lerp(StartPos4, TargetPos4, CurrentPos);
                else Cube.transform.position = Vector3.Lerp(TargetPos4, StartPos4, CurrentPos);
                if (Count > SideToSide) NumReset();
            }
            else if (Direction < StartTime + (SideToSide * 8) + 12.1f)
            {
                Direction = 0;
                starMoveSetActive = false;
                Cube.SetActive(false);
                GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEventColliderEnabled(true);
                Debug.Log("끗");
                G2Score_Manager.howManyTimesStar = 1;
                G2Score_Manager.corutinStarter = true;
            }
            else Direction = 0;

            G2Score_Manager.StarGameTime = SideToSide * 8;  //kh
        }

        RaycastHit hit;

        if (Physics.Raycast(RayManager.rays.left, out hit, 100f, 1 << 13) ||
                Physics.Raycast(RayManager.rays.right, out hit, 100f, 1 << 13))
        {
            startLookTime += Time.deltaTime; //

            if (startLookTime > 2)
            {
                TextManager.beginning = TextManager.showStringSec * 10f;
                startLookTime = 0;

            }
        }
        else startLookTime = 0;

    }




    private void ObjectHiding()
    {
        b = true;
        ScoreBoard.SetActive(false);
        Cube.SetActive(false);


    }
    private void NumReset()
    {
        stage++;
        Count = 0;
        CurrentPos = 0;
    }

    public void CountDown()
    {

        if (b)
        {
            G2Score_Manager.CountNum -= Time.deltaTime;



            if (G2Score_Manager.CountNum > 1)
            {

                CountBoard.SetActive(true);
            }

            else
            {
                b = false;
                CountBoard.SetActive(false);
            }
        }
        else
        {

            G2Score_Manager.CountNum = 3.9f;
        }
    }


}