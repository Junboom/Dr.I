using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class DrawCircle : MonoBehaviour
{

    //위치를 왔다갔다할 원들 
    public GameObject obj0;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
   

    //if문 구별 조건 변수 
    
    
    void Start()
    {

        obj0.SetActive(false);
        obj1.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
        obj4.SetActive(false);
        obj5.SetActive(false);



        //텍스트에 저장된 리스트를 한줄씩 읽어 그 타임대로 함수를 호출 
        for (int i=0; i < TextIn.list.Count ; i++)
        {
            Invoke("Draw", TextIn.Bal()[i]-0.91f);
           // Invoke("Erase", TextIn.Bal()[i]+1.2f);
           
        }
        Invoke("Ending", TextIn.Bal()[TextIn.list.Count - 1] + 2.0f);



    }

    void Update()
    {
       

    }

     public void Draw()
    {
        // 원을 그리는 로직 
        int a = 20;
        int b = 10;
        
        //랜덤 x좌표 a와 랜덤 y좌표 b를 생성 한다
        a = Random.Range(-20, 20);
        b = Random.Range(-10, 10);
        if (!obj0.activeSelf)
        {
            

            //숨겨진 오브젝트를 불러와 x,y에 위치시킴
            obj0.SetActive(true);
            obj0.transform.localPosition = new Vector3(a, b, -20);



        }
        else if (!obj1.activeSelf)
        {


            obj1.SetActive(true);
            obj1.transform.localPosition = new Vector3(a, b, -20);


        }
        else if (!obj2.activeSelf)
        {

            obj2.SetActive(true);
            obj2.transform.localPosition = new Vector3(a, b, -20);


        }
        else if (!obj3.activeSelf)
        {

            obj3.SetActive(true);
            obj3.transform.localPosition = new Vector3(a, b, -20);

        }
        else if (!obj4.activeSelf)
        {

            obj4.SetActive(true);
            obj4.transform.localPosition = new Vector3(a, b, -20);

        }
        else if (!obj5.activeSelf)
        {
            
            obj5.SetActive(true);
            obj5.transform.localPosition = new Vector3(a, b, -20);

        }


        
        

    }

    //엔딩화면을 출력하는 코드
    public void Ending()
    {

        //원 중복해서 나오는 것을 방지 -
        TextIn.Erase();

        //끝난 후에 메인메뉴로 넘어감
        SceneManager.LoadScene("MenuScene2");




    }


}
