using System.Collections;
using System.Collections.Generic;
using System;   // Serializable を指定するために必要

[Serializable]  // シリアライズするために必要
public class PlayerData
{
    public int Level = 1;
    public int MaxHp = 100;
    public int Hp = 100;
    public int MaxMp = 30;
    public int Mp = 30;
    public int Exp = 0;
    public int Gold = 0;
}
