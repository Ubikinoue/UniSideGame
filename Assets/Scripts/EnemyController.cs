using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f; //�ړ����x

    public bool isToRight = false; //true:�E�����@false:������

    public float revTime = 0.0f; //���]����

    float time = 0; //���]���Ԃ͂��邽�߂̕ϐ�

    public LayerMask groundLayer; //�ێ��ʃ��C���[(�n�ʔ���p)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (this.isToRight)
        {
            //�����𔽓]������
            this.transform.localScale = new Vector2(-1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.revTime > 0)
        {
            time += Time.deltaTime;
            if (time >= this.revTime)
            {
                //���E�t���O�𔽓]������
                isToRight = !isToRight;
                //���Ԃ�������
                time = 0;
                if (this.isToRight)
                {
                    //�����𔽓]������
                    this.transform.localScale = new Vector2(-1, 1);
                }
                else
                {
                    //�����𔽓]������
                    this.transform.localScale = new Vector2(1, 1);
                }
            }
        }
    }

    void FixedUpdate()
    {
        ///�n�ʂ��ǂ����t���O
        bool isGround = false;

        ///�n�ʂƃ��C���[�ƐڐG���Ă��邩���K������
        isGround = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 0.5f, this.groundLayer);

        if (isGround)
        {
            //�n�ʂ̏�ɂ���Ƃ�����������
            //Rigidbody2D�̕��i���擾����
            Rigidbody2D rbody = this.GetComponent<Rigidbody2D>();
            if (this.isToRight)
            {
                //�E�ړ�
                rbody.linearVelocity = new Vector2(speed, rbody.linearVelocityY);
            }
            else
            {
                //���ړ�
                rbody.linearVelocity = new Vector2(-speed, rbody.linearVelocityY);
            }
        }
    }
}
