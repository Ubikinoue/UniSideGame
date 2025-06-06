using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CannonController : MonoBehaviour
{
    //�S�C�ʗp�̃v���n�u
    public GameObject bulletPrefab;

    //���b�҂��Ă��甭�˂��邩�̐ݒ�
    public float delayTime = 3.0f;

    //�S�C�ʂ̑���
    public float speed = 4.0f;

    //�S�C�ʔ��ˊJ�n�̋���
    public float kyori = 8.0f;

    //�v���C���[�I�u�W�F�N�g�i�[�p
    GameObject player;

    //�Q�[�g�̃g�����X�t�H�[���i�[�p
    Transform gateTransform;

    //�o�ߎ���
    float keikaJikan = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�v���C���[���擾
        this.player
         = GameObject.FindGameObjectWithTag("Player");

        //�Q�[�g�̃g�����X�t�H�[���擾
        this.gateTransform 
            = transform.Find("gate");
    }

    // Update is called once per frame
    void Update()
    {
        //�o�ߎ��Ԍv�Z
        this.keikaJikan += Time.deltaTime;

        //�^�[�Q�b�g�Ƃ̎˒������`�F�b�N
        if(IsStart(this.player.transform.position))
        {
            //�o�ߎ��Ԃ��w�莞�Ԃ𒴂����甭��
            if(this.keikaJikan > this.delayTime)
            {
                //�C�e�����(�ʒu)
                Vector2 pos
                    = new Vector2(this.gateTransform.position.x
                        , this.gateTransform.position.y);

                //�C�e�����(����)
                GameObject bullet
                    = Instantiate(this.bulletPrefab
                                    , pos
                                    , Quaternion.identity);

                //�C���䂪�����Ă�������ɔ��˂���
                Rigidbody2D rbody
                    = bullet.GetComponent<Rigidbody2D>();
                float kakudoZ = transform.localEulerAngles.z;
                float x = Mathf.Cos(kakudoZ * Mathf.Deg2Rad);
                float y = Mathf.Sin(kakudoZ * Mathf.Deg2Rad);
                Vector2 v = new Vector2(x, y) * this.speed;

                //�C�e���ˁI
                rbody.AddForce(v, ForceMode2D.Impulse);
                //�o�ߎ��ԃ��Z�b�g
                this.keikaJikan = 0; 
            }
        }
    }

    /// <summary>
    /// �^�[�Q�b�g�̃|�W�V�����Ǝ����̋����𒲂ׂ�
    /// �ݒ苗���ȉ��ɂȂ�΃X�^�[�g�I(true)
    /// ����ȊO�̓X�^�[�g���Ȃ�(false)
    /// </summary>
    /// <param name="targetPos"></param>
    /// <returns></returns>
    bool IsStart(Vector2 targetPos)
    {
        //�^�[�Q�b�g�Ƃ̋������擾
        float k=Vector2.Distance(transform.position
                                , targetPos);
        if(k < this.kyori)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //�͈͕\��
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position
                                , this.kyori);
    }
}
