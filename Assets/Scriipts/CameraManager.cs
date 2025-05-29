using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float leftLimit = 0.0f;      //���̌��E
    public float rightLimit = 0.0f;     //�E�̌��E
    public float topLimit = 0.0f;       //��̌��E
    public float bottomLimit = 0.0f;    //���̌��E

    public GameObject subScreen;  //�T�u�X�N���[���p

    //�����X�N���[���������邩�t���O(x)
    public bool isForceScrollX=false;

    //1�b�Ԃœ�����x���W�̗�
    public float scrollSpeedX = 0.5f;

    //�����X�N���[���������邩�t���O(y)
    public bool isForceScrollY=false;

    //1�b�Ԃœ�����y���W�̗�
    public float scrollSpeedY = 0.5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameState != "playing")
        {
            return;
        }
        //�Q�[����̃v���C���[�I�u�W�F�N�g���擾
        GameObject player 
        = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            float x= player.transform.position.x;
            float y= player.transform.position.y;
            float z= this.transform.position.z;

            if(this.isForceScrollX)
            {
                //���ɋ����X�N���[��
                x=this.transform.position.x
                    +(this.scrollSpeedX*Time.deltaTime);
            }
            if (this.isForceScrollY)
            {
                //���ɋ����X�N���[��
                y = this.transform.position.y
                    + (this.scrollSpeedY * Time.deltaTime);
            }
            if (x > rightLimit) 
            {            
                x = rightLimit;        
            }
            else if (x < leftLimit) 
            {
                x = leftLimit;
            }
            if (y > topLimit) 
            {
                y = topLimit;
            }
            else if (y < bottomLimit) 
            {
                y = bottomLimit;
            }

            //�J�����̍��W�̓v���C���[�̍��W���R�s�[
            this.transform.position
                 = new Vector3(x, y, z);

            //�T�u�X�N���[�����X�N���[�����Ă���
            if (subScreen != null)
            {
                y=subScreen.transform.position.y;
                z=subScreen.transform.position.z;
                subScreen.transform.position
                    = new Vector3(x / 2.0f, y, z);
            }
        }
    }
}
