using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MaxSpeed;
    public float JumpPower;

    bool IsJumping;

    Rigidbody2D PlayerRigid;

    private void Awake()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
        IsJumping = false;
    }

    private void FixedUpdate()
    {
        //움직임 속도
        float h = Input.GetAxisRaw("Horizontal");
        PlayerRigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);


        //오른쪽 최고 속도
        if (PlayerRigid.velocity.x > MaxSpeed)
            PlayerRigid.velocity = new Vector2(MaxSpeed, PlayerRigid.velocity.y);
        //왼쪽 최고 속도
        else if (PlayerRigid.velocity.x < MaxSpeed * (-1))
            PlayerRigid.velocity = new Vector2(MaxSpeed * (-1), PlayerRigid.velocity.y);
    }
    private void Update()
    {
        //점프
        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            PlayerRigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            IsJumping = true;
        }

        //속도 멈춤
        if (Input.GetButtonUp("Horizontal"))
        {
            PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.normalized.x * 0.5f, PlayerRigid.velocity.y);
        }
    }

    //충돌 감지 및 점프 초기화
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsJumping = false;
        }
    }
}
