using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G2Score_Manager : MonoBehaviour
{

    public static int score;


    public static float timeSpan;
    public static float hitTIme;
    public static float CountNum;
    public static float CountNum2;


    public static float StartTime;
    public static float EndTime;
    public static float FullRunningTime;

    public static float StarGameTime = 0; // 따라보기 총 시간 0
    public static float AllTimes = 0;       // 따라보기 총 반복횟수 0

    public static float checkTime = 0;          // 따라보기 맞춘 시간  0
    public static float HitTimes = 0;           // 횃보기 맞춘 횟수 0
    public static float howManyTimesStar = 0;   //따라보기 총 플레이횟수
    public static float howManyTimesTorch = 0;  //홱보기 총 플레이횟수

    public static float TorchGameTime = 0;  // 홱보기 총 시간 0
    public static float HitAccuracy = 0;    // 홱보기 맞춘 비율 
    public static float MovingAccuracy = 0; //따라보기 맞춘 비율

    public static bool corutinStarter = false;

    public static string user;
    public string CreateUrl;


    void Start()
    {
        CreateUrl = "http://223.194.155.79//project/InsertUser1.php";

    }


    private void Awake()
    {
        score = 0;
        timeSpan = 0;
        hitTIme = 0;
        CountNum = 4f;

    }


    private void Update()
    {
        FullRunningTime += Time.deltaTime;
        if (corutinStarter)
        {
            corutinStarter = false;
            StartCoroutine(DataBaseSubmit());
        }

        //FullRunningTime을 DB로 보내는 코드 >>걍 적으면 실시간으로 계속 감
    }

    /*IEnumerator Username()  //따라보기 운동의 총 시간 
    {
        WWWForm form = new WWWForm();
        user = test.IDInputField1; //test파일 25번째줄 static public string IDInputField1;
        string usernamePost = user.ToString();
        //StarGameTime을 Db로 보내는 코드
        form.AddField("StarGameTimePost", usernamePost);
        WWW webRequest = new WWW(CreateUrl, form);
        yield return webRequest;

    }*/

    public IEnumerator DataBaseSubmit()  //따라보기 운동의 총 시간 
    {
        WWWForm form = new WWWForm();
        //string StarGameTime1 = StarGameTime.ToString();
        //StarGameTime을 Db로 보내는 코드
        Debug.Log(LoginScene.IDInputField1);

        form.AddField("usernamePost", LoginScene.IDInputField1);
        WWW webRequest = new WWW(CreateUrl, form);

        yield return new WaitUntil(() => webRequest.isDone);
        Debug.Log(webRequest.text);

        string[] score = webRequest.text.Split(new char[] { ' ', ',', '/', '<', '>', '\n' });
        //foreach(string s in score)
        //{
        //    Debug.Log(s);
        //}

        float score1 = float.Parse(score[score.Length - 6]) + StarGameTime;
        float score2 = float.Parse(score[score.Length - 5]) + AllTimes;
        float score3 = float.Parse(score[score.Length - 4]) + checkTime;
        float score4 = float.Parse(score[score.Length - 3]) + HitTimes;
        float score5 = float.Parse(score[score.Length - 2]) + howManyTimesStar;
        float score6 = float.Parse(score[score.Length - 1]) + howManyTimesTorch;



        form.AddField("usernamePost", LoginScene.IDInputField1);
        form.AddField("StarGameTimePost", score1.ToString());
        form.AddField("TorchGameTimePost", score2.ToString());
        form.AddField("MovingAccuracyPost", score3.ToString());
        form.AddField("HitAccuracyPost", score4.ToString());
        form.AddField("HowManyTimesStarPost", score5.ToString());
        form.AddField("HowManyTimesTorchPost", score6.ToString());



        webRequest = new WWW(CreateUrl, form);

        yield return new WaitUntil(() => webRequest.isDone);
        checkTime = 0;
        TorchGameTime = 0;
        MovingAccuracy = 0;
        HitAccuracy = 0;
        howManyTimesStar = 0;
        howManyTimesTorch = 0;
        Debug.Log(webRequest.text);

    }

    public static float starAcc = 0;
    public void CalStarAccuracy1()// 스타 정확성 + 스타 이용시간 >>게임이 종료되고 메뉴화면으로 갈때 실행 		
    {

        starAcc = (StarMove.acc_Time / StarMove.total_Time) * 100; //스타 정확성 (성공 시간 / 총 이용시간)		

    }

   

}
