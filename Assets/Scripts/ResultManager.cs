using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;//TextMeshPro�p

public class ResultManager : MonoBehaviour
{
    //�X�R�A�e�L�X�g�i�[�p
    public GameObject scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //���v�X�R�A���X�R�A�{�[�h�ɕ\������
        scoreText.GetComponent<TMP_Text>().text
                = GameManager.totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
