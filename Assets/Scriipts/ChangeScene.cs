using UnityEngine;
//���V�[���̐؂�ւ��ɕK�v��
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //�ǂݍ��ރV�[����
    public string sceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �V�[���ǂݍ��ޗp
    /// </summary>
    public void Load()
    {
        SceneManager.LoadScene(this.sceneName);
    }
}
