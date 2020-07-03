using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;    // ファイル操作をするために必要
using System.Runtime.Serialization.Formatters.Binary;   // BinaryFormatter を使うために必要

public class SaveBinaryData : MonoBehaviour
{
    PlayerData m_playerData;
    string m_path;

    void Start()
    {
        m_playerData = new PlayerData();
        m_path = Application.dataPath + "/PlayerData.dat";
    }

    public void Damage()
    {
        m_playerData.Hp -= 1;
        Debug.Log("ダメージを受けた。HP: " + m_playerData.Hp);
    }

    public void Heal()
    {
        m_playerData.Hp = m_playerData.MaxHp;
        Debug.Log("HP が回復した。HP: " + m_playerData.Hp);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(m_path, FileMode.Create, FileAccess.Write);
        bf.Serialize(fs, m_playerData);
        Debug.Log("セーブ完了。ファイル名: " + m_path);
    }

    public void Load()
    {
        FileStream fs = new FileStream(m_path, FileMode.Open, FileAccess.Read);
        BinaryFormatter bf = new BinaryFormatter();
        m_playerData = bf.Deserialize(fs) as PlayerData;
        Debug.Log(m_path + "からデータをロードした。");
    }

    public void ShowPlayerData()
    {
        string message = "";
        message += "Hp: " + m_playerData.Hp + "\r\n";
        message += "Level: " + m_playerData.Level + "\r\n";
        message += "MaxHp: " + m_playerData.MaxHp + "\r\n";
        message += "MaxMp: " + m_playerData.MaxMp + "\r\n";
        message += "Mp: " + m_playerData.Mp + "\r\n";
        message += "Gold: " + m_playerData.Gold;
        Debug.Log(message);
    }
}
