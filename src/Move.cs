using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// キャラクターの操作
public class Move : MonoBehaviour
{

    Transform m_transform;                      // 座標系
    Rigidbody m_Rigidbody;                      // 物理演算系
    Animator anim;                              // アニメ制御
    const string key_isWalking = "isWalking";   // アニメ用歩行状態キー
    const string key_isRunning = "isRunning";   // アニメ用走行状態キー
    public float WALK_SP;                       // 歩行速度(チューニング用にグローバル)
    public float TURN_SP;                       // 走行速度(チューニング用にグローバル)
    private Vector3 velocity;                   // 移動方向
    private AudioSource audioSource;            // 音の発生源

    // タップ移動用(未使用)
    private NavMeshAgent agent;
    private RaycastHit hit;
    private Ray ray;

    void Start()
    {
        m_transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        hit.point = m_transform.position;
    }

    void Update()
    {
        float x = 0.0f;
        float z = 0.0f;
        velocity = Vector3.zero;
        float dash = 1.0f;
        bool walking = false;
        bool running = false;
        bool tap = false;
        bool key_state= false;

        // WASD＝上下左右で移動、Spaceと組み合わせるとダッシュ
        if (Input.GetKey(KeyCode.Space)){dash = 4.0f;running = true;}
        if (Input.GetKey(KeyCode.D)){velocity.x += WALK_SP * dash;walking = true;}
        if (Input.GetKey(KeyCode.A)){velocity.x -= WALK_SP * dash;walking = true;}
        if (Input.GetKey(KeyCode.W)){velocity.z += WALK_SP * dash;walking = true;}
        if (Input.GetKey(KeyCode.S)){velocity.z -= WALK_SP * dash;walking = true;}
        
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

        // 歩くモーション
        if ( ((walking == true) || (tap == true)) && (running == false) ) {
            key_state = true;
        } else {
            key_state = false;
        }
        anim.SetBool(key_isWalking, key_state);

        // 走るモーション
        key_state = false;
        if ( (walking == true) && (running == true) ) {
            key_state = true;
        } else {
            key_state = false;
        }
        anim.SetBool(key_isRunning, key_state);

        velocity = velocity.normalized * WALK_SP * dash;
//      Debug.Log(velocity);

        // ベクトルの大きさ
//        if (velocity.magnitude > 0)
//        {
//           m_transform.Translate(velocity);
//           m_transform.rotation = Quaternion.LookRotation(velocity);

//           m_transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), TURN_SP);
//           m_transform.position += velocity;
//        }
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

        // キャラクターの向きを進行方向にして移動
        if (moveForward != Vector3.zero)
        {
            m_transform.rotation = Quaternion.Slerp(transform.rotation,
                                                    Quaternion.LookRotation(moveForward),
                                                    TURN_SP);
            m_transform.position += moveForward;
        }
    }

    // 足音を鳴らす
    void Footstep()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
    }

}