using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{

    Transform m_transform; // 
    Rigidbody m_Rigidbody; // 物理演算的な移動
    Animator anim; // アニメ制御
    const string key_isWalking = "isWalking";
    const string key_isRunning = "isRunning";
    public float WALK_SP;
    public float TURN_SP;
    private Vector3 velocity;              // 移動方向
    private AudioSource audioSource;

    // タップ移動用
    private NavMeshAgent agent;
    private RaycastHit hit;
    private Ray ray;

    void Start()
    {
        // 自分のRigidbodyを取ってくる
//                m_Rigidbody = GetComponent<Rigidbody>();
        m_transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        hit.point = m_transform.position;
    }

    void Update()
    {
        // WASDで移動する
        float x = 0.0f;
        float z = 0.0f;
        velocity = Vector3.zero;
        float dash = 1.0f;
        bool walking = false;
        bool running = false;
        bool tap = false;

        // キー移動
        if (Input.GetKey(KeyCode.Space))
        {
            dash = 4.0f;
            running = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += WALK_SP * dash;
            //            x += WALK_SP * dash;
            walking = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= WALK_SP * dash;
//            x -= WALK_SP * dash;
            walking = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            velocity.z += WALK_SP * dash;
//            z += WALK_SP * dash;
            walking = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.z -= WALK_SP * dash;
//            z -= WALK_SP * dash;
            walking = true;
        }
        
        // タップ移動
/*        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                agent.SetDestination(hit.point);
                Debug.Log("sp:"+ agent.speed);
                agent.speed = dash;
                tap = true;
            }
        }
        if (Vector3.Distance(hit.point, m_transform.position) > 0.5f)
        {
*/            // "Walking"アニメーションを続ける
/*            tap = true;
//            Debug.Log("hit:" + hit.point);
//            Debug.Log("wani:" + m_transform.position);
        }
*/

        if ( ((walking == true) || (tap == true)) && (running == false) ) {
            anim.SetBool(key_isWalking, true);
        } else {
            anim.SetBool(key_isWalking, false);
        }

        if ( (walking == true) && (running == true) ) {
            anim.SetBool(key_isRunning, true);
        } else {
            anim.SetBool(key_isRunning, false);
        }

        //        velocity = velocity.normalized * WALK_SP * Time.deltaTime * dash;
        velocity = velocity.normalized * WALK_SP * dash;
//        Debug.Log(velocity);

        //                m_Rigidbody.velocity = new Vector3(x, 0.0f, z);
        if (velocity.magnitude > 0)
        {
            //        m_transform.Translate(velocity);
 //           m_transform.rotation = Quaternion.LookRotation(velocity);

//            m_transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), TURN_SP);
//            m_transform.position += velocity;
        }
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * velocity.z + Camera.main.transform.right * velocity.x;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        //        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
        //        velocity = velocity.normalized * WALK_SP * Time.deltaTime * 3.0f;

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            //            transform.rotation = Quaternion.LookRotation(moveForward);
                        m_transform.rotation = Quaternion.Slerp(transform.rotation,
                                                              Quaternion.LookRotation(moveForward),
                                                              TURN_SP);
            //            m_transform.position += velocity;
//            m_transform.rotation = Quaternion.LookRotation(moveForward);
            m_transform.position += moveForward;
        }
    }

    void Footstep()
    {
//        Debug.Log("footstep");
        audioSource = gameObject.GetComponent<AudioSource>();
//        audioSource.clip = audioClip;
//        audioSource.Play();
        audioSource.PlayOneShot(audioSource.clip);
    }

}