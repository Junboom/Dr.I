using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


namespace Jinwon.Coroutine
{

    public class SongFadeOut : MonoBehaviour
    {


        public float animTime = 2f;//Fade 애니메이션 재생단위 (초)

        private Image fadeImage;//UGUI의 이미지 컴포넌트 참조변수

        private float start = 0f;
        private float end = 1f;
        private float time = 0f;

        private bool isPlaying = false; //Fade 애니메이션 중복 재생 방지

        private void Awake()
        {
            //Iamge 컴포넌트 검색하여 참조변수 값 설정
            fadeImage = GetComponent<Image>();
        }

        public void StartFadeAnim()
        {
            if (isPlaying == true)

                return;
            //Fade 애니메이션 재생
            Invoke("StartSecond", 0f);
        }

        public void StartSecond()
        {
            StartCoroutine("PlayFadeOut");
        }

        IEnumerator PlayFadeOut()
        {   
            isPlaying = true;

            Color color = fadeImage.color;
            time = 0f;
            color.a = Mathf.Lerp(start, end, time);

            while (color.a <0.9f)
            {
                time += Time.deltaTime / animTime;

                color.a = Mathf.Lerp(start, end, time);

                fadeImage.color = color;

                yield return null;

            }
         
         
            isPlaying = false;
            color.a = 0;


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
