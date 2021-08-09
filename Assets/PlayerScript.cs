using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Inspector")]
    [SerializeField] Rigidbody2D rigid;

    [Header("Time")]
    [SerializeField] float curDashCool;

    [Header("PlayerState")]
    public bool isGround;
    public bool canMove;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float maxDashCoolTime;
    [SerializeField] float dashPower;

    [Header("Axis")]
    [SerializeField] float inputX;

    private void Update()
    {
        //���� ��Ÿ�� ���
        if (curDashCool >= 0) curDashCool -= Time.deltaTime;

        //���� ��Ÿ���� ���Ұ� Shift������ ����
        if (curDashCool < 0 && Input.GetKeyDown(KeyCode.LeftShift) && inputX != 0) StartCoroutine(Dash());

        if (canMove) Move();

        //���� �ְ� �����̽��ٸ� ������ ���� ����
        if (Input.GetKeyDown(KeyCode.Space) && isGround) Jump();
    }

    void Move()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        rigid.velocity = new Vector2(inputX * moveSpeed, rigid.velocity.y);
    }

    void Jump()
    {
        rigid.AddForce(new Vector2(0, jumpPower));
    }

    IEnumerator Dash()
    {
        curDashCool = maxDashCoolTime;

        canMove = false;

        rigid.velocity = new Vector2(0, 0);
        if (inputX > 0) rigid.velocity = new Vector2(dashPower, 0);
        else rigid.velocity = new Vector2(-dashPower, 0);

        yield return new WaitForSeconds(0.1f);

        canMove = true;
    }
}
