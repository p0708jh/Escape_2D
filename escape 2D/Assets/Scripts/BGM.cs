using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
        public AudioSource bgmSource;
        public List<AudioClip> bgm;
    private int i;
        public void Start()
        {
        //audioSource = GetComponent();
        i = bgm.Count;
        StartCoroutine(Play());
            //씬안에 모든 오디오소스중 현재 오디오 소스의 우선순위를 정한다.
            // 0 : 최우선, 256 : 최하, 128 : 기본값
        }

    IEnumerator Play()
    {
        while (true)
        {
            for (int j = 0; j < i; j++)
            {
                bgmSource.clip = bgm[j];
                bgmSource.volume = 0.5f;
                bgmSource.Play();

               // Debug.Log(j + bgm[j].length);
                yield return new WaitForSeconds (bgm[j].length);
            }
        }
    }
}
