﻿using UnityEngine;

public class DamageEnemy : DamageBasic
{
    // 碰撞開始執行一次
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // print($"<color=#69f>碰到的物件：{collision.gameObject.name}</color>");

        if (collision.gameObject.name.Contains("武器")) Damage(50);
    }

    // 碰撞結束執行一次
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    // 碰撞持續時直行約 60 FPS
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
}
