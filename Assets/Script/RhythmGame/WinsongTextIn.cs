using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using System.IO;



public class WindsongTextIn : MonoBehaviour
{

    public static List<string> list = new List<string>();
    int i = 0;
    public void Start()
    {
        Listing();

    }

    public void Listing()
    {

        string strFilePath;
        strFilePath = Application.dataPath + "/text/windsong.txt";
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









    void Update()

    {



    }


}