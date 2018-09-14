using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


namespace Jinwon.Coroutine
{

    public class SongFadeIn : MonoBehaviour
    {


        public float animTime = 2f;//Fade 애니메이션 재생단위 (초)

        private Image fadeImage;//UGUI의 이미지 컴포넌트 참조변수

        private float start = 0.9f;  
        private float end = 0f; 
        private float time = 0f; 



        private void Awake()
        {
            //Iamge 컴포넌트 검색하여 참조변수 값 설정
            fadeImage = GetComponent<Image>();
        }

        public void StartFadeAnim()
        {
         //   if (isPlaying == true)
         //       return;
            //Fade 애니메이션 재생
            Invoke("StartSecond", 2.1f);
        }

        public void StartSecond()
        {
            StartCoroutine("PlayFadeIn");
        }
        IEnumerator PlayFadeIn()
        {

            Color color = fadeImage.color;
            time = 0f;
            color.a = Mathf.Lerp(start, end, time);

            while (color.a > 0f)  
            {
                time += Time.deltaTime / animTime ;

                color.a = Mathf.Lerp(start, end, time);

                fadeImage.color = color;

                yield return null;

            }
            


        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
