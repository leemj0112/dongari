using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MaxSpeed;
    Rigidbody2D PlayerRigid;

    private void Awake()
    {
         PlayerRigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //키에 따른 움직임 컨트롤
        float h = Input.GetAxisRaw("Horizontal");
        PlayerRigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);


        //오른쪽 최고 속도
        if(PlayerRigid.velocity.x > MaxSpeed )
            PlayerRigid.velocity = new Vector2(MaxSpeed, PlayerRigid.velocity.y);
        //왼쪽 최고 속도
        else if (PlayerRigid.velocity.x < MaxSpeed * (-1))
            PlayerRigid.velocity = new Vector2(MaxSpeed*(-1), PlayerRigid.velocity.y);

    }
}
