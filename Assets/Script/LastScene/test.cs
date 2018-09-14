using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //InputField나 GameObject를 받아올려면 UI를 import해줘야함
using UnityEngine.SceneManagement; //scene을 넘기기위해 사용하는 import

namespace username
{
public class test : MonoBehaviour {

    [Header("LoginPanel")]
    public InputField IDInputField;
    public InputField PassInputField;
    [Header("CreateAccountPanel")]
    public InputField New_IDInputField;
    public InputField New_PassInputField;
    public InputField New_EmailInputField;
    public GameObject CreateAccountPanelObj;
    public GameObject LoginPanelObj;
    public GameObject warnPanelObj;

    public string LoginUrl;
    public string CreateUrl;

    static public string IDInputField1;
    public string PassInputField1;
    
    //public static float totaltime;
    //private bool gettime = false;
    // Use this for initialization
    void Start()
    {

        LoginUrl = "http://192.168.200.128/project/Login.php";
        CreateUrl = "http://192.168.200.128/project/InsertUser.php";

    }
    /*private void Update()
    {
        gamestartBtn();
    }*/

    public void LoginBtn()
    {

        StartCoroutine(LoginCo());
    }

    IEnumerator LoginCo()
    {
        Debug.Log(IDInputField.text);
        string IDInputField1 = IDInputField.text.ToString();
        Debug.Log(PassInputField.text);
        string PassInputField1 = PassInputField.text.ToString();

        WWWForm form = new WWWForm();
        form.AddField("usernamePost", IDInputField1);
        form.AddField("passwordPost", PassInputField1);
        //form.AddField("totaltimePost",totaltime);
        
        WWW webRequest = new WWW(LoginUrl, form);
        yield return webRequest;

        //Debug.Log("login seccess" + IDInputField.text);
        if (webRequest.text == "login seccess"+ PassInputField.text)
        {
            SceneManager.LoadScene("MenuScene2");
        }
        else
        {
            warnPanelObj.SetActive(true);
        }


    }


    public void OpenCreateAccountBtn()
    {
        LoginPanelObj.SetActive(false);
        CreateAccountPanelObj.SetActive(true);

    }


    public void CreateAccountBtn()
    {
        StartCoroutine(CreateCo());
        CreateAccountPanelObj.SetActive(false);
        LoginPanelObj.SetActive(true);

    }

    IEnumerator CreateCo()
    {


        WWWForm form = new WWWForm();
        form.AddField("usernamePost", New_IDInputField.text);
        form.AddField("passwordPost", New_PassInputField.text);
        form.AddField("emailPost", New_EmailInputField.text);


        WWW webRequest = new WWW(CreateUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);



        yield return null;
    }

    public void warnBtn()
    {
        warnPanelObj.SetActive(false);
    }
    /*public void gamestartBtn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gettime = true;
        }
        if (gettime)
        {
            totaltime += Time.deltaTime;
            Debug.Log(totaltime);
        }
        if (Input.GetMouseButtonDown(1))
        {
            gettime = false;
        }
        if (!gettime)
        {
            Debug.Log("stop");
        }
    }*/

}
}