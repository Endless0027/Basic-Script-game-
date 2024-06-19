using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody m_RigidBody;//存储与玩家对象关联的刚体组件。
    public float fMaxForce = 500.0f;//存储玩家蓄力的最大力量值.
    private float m_CurForce = 0.0f;//存储当前玩家蓄力的力量值
    private Vector3 originalPosition;//存储玩家的初始位置
    public GameObject Box=null; //存储一个方块的预制体。
    public float fMinDistance = 1.2f;//用于存储方块生成的最小距离
    public float fMaxDistance= 3.0f;//用于存储方块生成的最大距离
    public float fMinHeight = 0.3f;//用于存储方块生成的最小高度
    public float fMaxHeight = 2.0f;//用于存储方块生成的最大高度

    private Vector3 m_Direction= Vector3.forward; //用于存储方块生成的方向。
    private float m_Directance = 0.0f;//用于存储方块生成的距离。
    private float m_Height = 0.0f;//用于存储方块生成的高度。

    private GameObject m_CurCube = null;//声明一个私有的 GameObject 变量，用于存储当前方块。
    private GameObject m_NextCube = null;//声明一个私有的 GameObject 变量，用于存储下一个方块。
  
    private Animator m_Animator=null;

    private UIManager m_UI=null;

    public AudioSource clickSound;
    public AudioSource generateSound;
    void Start()
    {
        
        m_RigidBody = GetComponent<Rigidbody>();//将当前游戏对象（Player）关联的 Rigidbody 组件赋值给变量 m_RigidBody
        m_Animator= GetComponent<Animator>();
        m_UI= GetComponent<UIManager>();
        originalPosition = transform.position; //记录了玩家对象的初始位置。
        m_NextCube = GeneranteBox(); //游戏开始时，会生成一个方块，并将其作为下一个方块存储起来。
    }

    void Update()
    {
        GameObject obj =GetHitObject ();//调用了 GetHitObject() 方法，获取玩家当前是否与其他游戏对象发生碰撞。返回的结果存储在 obj 变量中
        if (obj != null) //检查变量 obj 是否为 null。如果不为 null，则执行后续逻辑。
        { 
            if(obj.tag=="Cube")//检查碰撞到的游戏对象的标签是否为 "Cube"。
            {
                if(m_CurCube ==null) //如果是，则将碰撞到的方块赋值给 m_CurCube，表示游戏开始。
                {
                    m_CurCube = obj;//游戏开始
                }
                else if (m_NextCube==obj)//检查碰撞到的方块是否为下一个方块。如果是，则增加分数，
                                         
                {
                    m_UI.AddScore(1);
                    Destroy(m_CurCube);
                    m_CurCube =m_NextCube;
                    m_NextCube =GeneranteBox ();
                    generateSound.Play();
                    m_RigidBody.Sleep();//记录分数并更新当前方块和下一个方块，
                    m_RigidBody.WakeUp (); //然后让玩家对象的刚体休眠并唤醒，为生成下一个方块做准备。
                    m_Animator.SetBool("Forward", false);
                    m_Animator.SetBool("Left", false);

                }
            }
            else
            {
                
            }
        }
        if (Input.GetMouseButtonDown(0)) //检测玩家是否按下鼠标左键。
        {
            originalPosition = transform.position;
            if (clickSound != null)
            {
                clickSound.Play(); // 如果音效存在，则播放音效
            }
            //如果是，将玩家对象的当前位置赋值给 originalPosition，记录玩家按下鼠标时的位置。
        }
        else if (Input.GetMouseButton(0))//检测玩家是否一直按住鼠标左键。
        {
            m_CurForce += Time.deltaTime * 100;
            if (m_CurForce > fMaxForce) //如果是，根据时间增加当前的力量值 m_CurForce，并限制其最大值为 fMaxForce。
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
    //蓄力表现
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
        GameObject obj=GameObject.Instantiate(Box);//创建一个新的盒子
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
