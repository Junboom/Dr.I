using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{


    public static int Sender = 0;
    public static int AfterSender = 0;
    public static float beginning;

    private GameObject[] spotLight = new GameObject[5];

    
    private bool fireOff = true;
    public TextMesh ConvertableText;
    float RunningTime;
    private Color origin;
    private float alpha;
    public static bool initAlpha = false;
    public static float showStringSec = 3.5f;
    private float gazeTime = 0f;
    
    // Use this for initialization
    void Awake()
    {
        ConvertableText = GameObject.Find("ConvertableText").GetComponent<TextMesh>();
        origin = ConvertableText.color;
        alpha = origin.a;
    }



    // Update is called once per frame
    void Update()
    {
        StartGuide(); //게임이 시작되었을 때 안내문구 

        if (AfterSender > 0) //센더가 있을 경우
        {
            RunningTime += Time.deltaTime;

            if (RunningTime < 2)
            {

                Sender = AfterSender; // 현제 센더에 들어온 애프터센더를 대입 (교체)               
                GuidingText(); // 텍스트 출력 

            }
            else
            {
                ConvertableText.text = " "; //2초 후에 공백란으로 교체 
                RunningTime = 0; //러닝타임 초기화
                AfterSender = 0;//애프터 센더 버퍼 초기화     
            }
        }

        RepeatDescription();

    }



    void GuidingText()
    {
      //  Debug.Log(alpha);
        switch (Sender)
        {
            case 1:
                ConvertableText.text = "게임을 시작합니다.";

                break;
            case 2:
                ConvertableText.text = "게임이 종료되었습니다.";
                break;
            case 3:
                ConvertableText.text = "반짝이는 물체에 시선을 고정하세요 ";
                break;
            case 4:
                ConvertableText.text = "반짝이는 다른 물체를 찾아보세요 ";
                break;
            case 5:
                ConvertableText.text = "잘하셨습니다 ";
                break;
            case 6:
                ConvertableText.text = "안녕하세요";
                break;
            case 7:
                ConvertableText.text = "Project C 에 오신 것을 환영합니다. ";
                break;
            case 8:
                ConvertableText.text = "속도가 증가하였습니다.";
                break;
            case 9:
                GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEmissionEnabled(true, 0);
                ConvertableText.text = "홱보기 운동을 원하시면 게시판을 바라봐 주세요.";
                if (alpha < 0.2) GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEmissionEnabled(false, 0);
                break;
            case 10:
                GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEmissionEnabled(true, 1);
                ConvertableText.text = "따라보기 운동을 원하시면 술통을 바라봐 주세요.";
                if (alpha < 0.2) GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEmissionEnabled(false, 1);
                break;
            case 11:
                GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEmissionEnabled(true, 2);
                ConvertableText.text = "속도를 올리시려면 물고기 액자를 바라봐 주세요.";
                if (alpha < 0.2) GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEmissionEnabled(false, 2);
                break;
            case 12:
                GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEmissionEnabled(true, 3);
                ConvertableText.text = "속도를 내리시려면 장작더미를 바라봐 주세요.";
                if (alpha < 0.2) GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEmissionEnabled(false, 3);
                break;
            case 13:
                GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEmissionEnabled(true, 4);
                ConvertableText.text = "설명을 다시 보시려면 바로밑의 테이블을 바라봐 주세요.";
                if (alpha < 0.2) GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEmissionEnabled(false, 4);
                // if (alpha < 0.3) spotLight[4].SetActive(false);
                break;
            case 14:
                
                ConvertableText.text = "속도가 빨라집니다. 현재속도 : x" + (5/LookTorch.AfterSwitchTime).ToString();
                break;
            case 15:
                
                ConvertableText.text = "속도가 느려집니다. 현재속도 : x" + (5/LookTorch.AfterSwitchTime).ToString();
                break;
            case 16:

                ConvertableText.text = "홱보기 운동이 시작됩니다. 빛나는 물체를 바라보세요.";
                break;
            case 17:

                ConvertableText.text = "따라보기 운동이 시작됩니다. 빛나는 물체를 바라보세요.";
                break;

        }

    }


    void StartGuide()
    {
        //씬이 시작되었을 때 안내문구 출력 - 
        beginning += Time.deltaTime;
        alpha -= Time.deltaTime/showStringSec;
        ConvertableText.color = new Color(origin.r, origin.g, origin.b, alpha);
        if (beginning < showStringSec)
        {
            if (beginning < 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;
            }
            AfterSender = 6;
        }
        else if (beginning < showStringSec * 2)
        {
            if (beginning < showStringSec + 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;
            }
            AfterSender = 7;
        }
        else if (beginning < showStringSec * 3)
        {
            if (beginning < showStringSec * 2 + 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;
            }
            AfterSender = 9;

        }
        else if (beginning < showStringSec * 4)
        {
            if (beginning < showStringSec * 3 + 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;
            }
            AfterSender = 10;
        }
        else if (beginning < showStringSec * 5)
        {
            if (beginning < showStringSec * 4 + 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;
            }
            AfterSender = 11;
        }
        else if (beginning < showStringSec * 6)
        {
            if (beginning < showStringSec * 5 + 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;
            }
            AfterSender = 12;
        }
        else if (beginning < showStringSec * 7)
        {
            AfterSender = 13;

            if (beginning < showStringSec * 6 + 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;                
            }
            if (beginning > showStringSec * 7f - 0.05f) beginning += 50;
        }
        else if (beginning < showStringSec * 8)
        {
            AfterSender = 14; //스피드 업

            if (beginning < showStringSec * 7 + 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;
            }
            if (beginning > showStringSec * 8f - 0.05f) beginning += 50;

        }
        else if (beginning < showStringSec * 9)
        {
            AfterSender = 15; //스피드 다운

            if (beginning < showStringSec * 8 + 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;
            }
            if (beginning > showStringSec * 9f - 0.05f) beginning += 50;

        }
        else if (beginning < showStringSec * 10)
        {
            AfterSender = 16; //홱보기 시작

            if (beginning < showStringSec * 9 + 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;
            }
            if (beginning > showStringSec * 10f - 0.05f)
            {
                beginning += 50;
                GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEventColliderEnabled(false);
                LookTorch.StartBool = true;
            }

        }
        else if (beginning < showStringSec * 11)
        {
            AfterSender = 16; //홱보기 시작

            if (beginning < showStringSec * 10 + 0.1f) initAlpha = true;
            if (initAlpha)
            {
                initAlpha = false;
                alpha = 1;
            }
            if (beginning > showStringSec * 11f - 0.05f)
            {
                beginning += 50;
                StarMove.starMoveSetActive = true;
                GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().SetEventColliderEnabled(false);

            }

        }
        else if (fireOff)
        {
            GameObject.Find("AllLightOnOff").GetComponent<AllLightOnOff>().FireOn();
            fireOff = false;
        }
    }

    void RepeatDescription()
    {
        RaycastHit hit;

        if (Physics.Raycast(RayManager.rays.left, out hit, 100f, 1 << 14) &&
                Physics.Raycast(RayManager.rays.right, out hit, 100f, 1 << 14))
        {
            gazeTime += Time.deltaTime; //
            
            if (gazeTime > 2)
            {
                alpha = 1;
                AfterSender = 7;
                beginning = showStringSec * 3;
                gazeTime = 0;
            }
        }
        else gazeTime = 0;
    }

}
