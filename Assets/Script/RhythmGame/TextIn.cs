using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using System.IO;



public class TextIn : MonoBehaviour
{

    public static List<string> list = new List<string>();
    int i = 0;

    public GameObject Text;

    public void Start()
    {



        Listing();

    }

    public void Listing()
    {

        string strFilePath;
        strFilePath = Application.dataPath + TextTrans.text;
        string readstr;
        FileStream fs = new FileStream(strFilePath, FileMode.Open);
        StreamReader sr = new StreamReader(fs);


        while ((readstr = sr.ReadLine()) != null)
        {


            list.Add(readstr);


            i++;
        }


        sr.Close();
        fs.Close();
    }

    public static List<float> Bal()
    {
        List<float> num = new List<float>();
        for (int i = 0; i < list.Count; i++)
        {
            num.Add(Convert.ToSingle(list[i]));
            //Debug.Log(num);

        }
        return num;
    }

    public static List<float> Ending()
    {
        List<float> Endingnum = new List<float>();

        Endingnum.Add(Convert.ToSingle(list[list.Count]));
        //마지막 타임스탬프를 저장해서 리턴함 


        return Endingnum;
    }

    public static void Erase()
    {
        list.RemoveRange(0, list.Count);
        //리스트 모든 항목삭제 
    }








    void Update()

    {



    }


}