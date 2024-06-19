using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody m_RigidBody;//�洢����Ҷ�������ĸ��������
    public float fMaxForce = 500.0f;//�洢����������������ֵ.
    private float m_CurForce = 0.0f;//�洢��ǰ�������������ֵ
    private Vector3 originalPosition;//�洢��ҵĳ�ʼλ��
    public GameObject Box=null; //�洢һ�������Ԥ���塣
    public float fMinDistance = 1.2f;//���ڴ洢�������ɵ���С����
    public float fMaxDistance= 3.0f;//���ڴ洢�������ɵ�������
    public float fMinHeight = 0.3f;//���ڴ洢�������ɵ���С�߶�
    public float fMaxHeight = 2.0f;//���ڴ洢�������ɵ����߶�

    private Vector3 m_Direction= Vector3.forward; //���ڴ洢�������ɵķ���
    private float m_Directance = 0.0f;//���ڴ洢�������ɵľ��롣
    private float m_Height = 0.0f;//���ڴ洢�������ɵĸ߶ȡ�

    private GameObject m_CurCube = null;//����һ��˽�е� GameObject ���������ڴ洢��ǰ���顣
    private GameObject m_NextCube = null;//����һ��˽�е� GameObject ���������ڴ洢��һ�����顣
  
    private Animator m_Animator=null;

    private UIManager m_UI=null;

    public AudioSource clickSound;
    public AudioSource generateSound;
    void Start()
    {
        
        m_RigidBody = GetComponent<Rigidbody>();//����ǰ��Ϸ����Player�������� Rigidbody �����ֵ������ m_RigidBody
        m_Animator= GetComponent<Animator>();
        m_UI= GetComponent<UIManager>();
        originalPosition = transform.position; //��¼����Ҷ���ĳ�ʼλ�á�
        m_NextCube = GeneranteBox(); //��Ϸ��ʼʱ��������һ�����飬��������Ϊ��һ������洢������
    }

    void Update()
    {
        GameObject obj =GetHitObject ();//������ GetHitObject() ��������ȡ��ҵ�ǰ�Ƿ���������Ϸ��������ײ�����صĽ���洢�� obj ������
        if (obj != null) //������ obj �Ƿ�Ϊ null�������Ϊ null����ִ�к����߼���
        { 
            if(obj.tag=="Cube")//�����ײ������Ϸ����ı�ǩ�Ƿ�Ϊ "Cube"��
            {
                if(m_CurCube ==null) //����ǣ�����ײ���ķ��鸳ֵ�� m_CurCube����ʾ��Ϸ��ʼ��
                {
                    m_CurCube = obj;//��Ϸ��ʼ
                }
                else if (m_NextCube==obj)//�����ײ���ķ����Ƿ�Ϊ��һ�����顣����ǣ������ӷ�����
                                         
                {
                    m_UI.AddScore(1);
                    Destroy(m_CurCube);
                    m_CurCube =m_NextCube;
                    m_NextCube =GeneranteBox ();
                    generateSound.Play();
                    m_RigidBody.Sleep();//��¼���������µ�ǰ�������һ�����飬
                    m_RigidBody.WakeUp (); //Ȼ������Ҷ���ĸ������߲����ѣ�Ϊ������һ��������׼����
                    m_Animator.SetBool("Forward", false);
                    m_Animator.SetBool("Left", false);

                }
            }
            else
            {
                
            }
        }
        if (Input.GetMouseButtonDown(0)) //�������Ƿ�����������
        {
            originalPosition = transform.position;
            if (clickSound != null)
            {
                clickSound.Play(); // �����Ч���ڣ��򲥷���Ч
            }
            //����ǣ�����Ҷ���ĵ�ǰλ�ø�ֵ�� originalPosition����¼��Ұ������ʱ��λ�á�
        }
        else if (Input.GetMouseButton(0))//�������Ƿ�һֱ��ס��������
        {
            m_CurForce += Time.deltaTime * 100;
            if (m_CurForce > fMaxForce) //����ǣ�����ʱ�����ӵ�ǰ������ֵ m_CurForce�������������ֵΪ fMaxForce��
                m_CurForce = fMaxForce;
          

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Jump();
            m_CurForce = 0.0f;
            if (clickSound != null)
            {
                clickSound.Stop();
            }
        }
        ShowScale();
    }
    //��������
    private void ShowScale()
    {
        float sc = (fMaxForce - m_CurForce * 0.5f) / fMaxForce;
        Vector3 scale= transform.localScale;
        scale.y = sc * 0.2f;
        transform .localScale = scale;
    }

    private void Jump()
    {
        m_RigidBody.AddForce(Vector3.up * m_CurForce);
        m_RigidBody.AddForce(m_Direction * m_CurForce);
        if (m_Direction == Vector3.forward)
            m_Animator.SetBool("Forward", true);
        else
            m_Animator.SetBool("Left", true);

        transform.position = originalPosition;
    }
    private GameObject  GeneranteBox()
    {
        GameObject obj=GameObject.Instantiate(Box);//����һ���µĺ���
        m_Directance =Random .Range(fMinDistance ,fMaxDistance);
        m_Height = Random.Range(0.5f, 1f);
        m_Direction = Random.Range(0,2) == 1 ? Vector3.forward:Vector3 .left;

       Vector3 pos =Vector3 .zero ;
        if(m_CurCube ==null)
            pos =m_Direction *m_Directance +transform .position;
        else
            pos=m_Direction *m_Directance +m_CurCube .transform .position;
        pos.y = 2.0f ;
        obj.transform.position =pos;

        obj.transform .localScale =new Vector3(1,m_Height ,1);
        obj.GetComponent<MeshRenderer>().material.color = new Color
            (Random .Range (0.0f,1.0f),
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f));
        return obj;
    }
  private GameObject GetHitObject()
    {
        RaycastHit hit;
        if(Physics .Raycast (transform .position ,Vector3.down, out hit,0.2f))
        {
           
            return hit.collider .gameObject ;
        }
        else
        {
            Vector3[] vOffests = {Vector3 .forward ,Vector3 .back,Vector3 .left,Vector3 .right}; 
            foreach (Vector3 vof in vOffests)
            {
                if (Physics.Raycast(transform.position+vof*0.1f, Vector3.down, out hit, 0.2f))
                {
                    
                    return hit.collider.gameObject;
                }
            }
        }
        return null;
    }
}
