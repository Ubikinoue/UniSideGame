using UnityEngine;

public class TimeController : MonoBehaviour
{
    //�J�E���g�_�E�������邩�ǂ���
    public bool isCountDown = true;

    //�Q�[���̍ő厞��
    public float gameTime = 30.0f;

    //���݂̌o�ߎ���
    public float displayTime = 0.0f;

    //�^�C���I�[�o�[�������ǂ���
    public bool isTimeOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(this.isCountDown==true)
        {
            //�J�E���g�_�E���ݒ肪True�̏ꍇ��
            //�\�����Ԃ��ő厞�Ԃɐݒ肷��
            this.displayTime = this.gameTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԑ؂�Ȃ�����J�E���g���Ȃ�
        if(this.isTimeOver==true)
        {
            return;
        }

        if(this.isCountDown==true)
        {
            this.displayTime =
                this.displayTime-Time.deltaTime;
            
            //�\�����Ԃ�0�ɂȂ����玞�Ԑ؂�
            if(this.displayTime<0.0f)
            {
                this.isTimeOver = true;
            }
            //Debug.Log("displayTime:" + this.displayTime);
        }
    }
}
