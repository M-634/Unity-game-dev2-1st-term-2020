using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_playerPrefab;
    SaveData m_saveData;
    string m_path;

    void Start()
    {
        m_path = Application.dataPath + ".text";
        m_saveData = new SaveData();
        StartGame();
    }

    /// <summary>スタート地点（原点）にプレイヤーを生成する</summary>
    public void StartGame()
    {
        SpawnPlayer(0f, 0f);
    }

    /// <summary>場所を指定してプレイヤーを生成する。現在存在しているプレイヤーは破棄する</summary>
    /// <param name="posX">プレイヤーを生成するX座標</param>
    /// <param name="posY">プレイヤーを生成するY座標</param>
    void SpawnPlayer(float posX, float posY)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go)
        {
            Destroy(go);
        }
        go = Instantiate(m_playerPrefab);
        go.transform.position = new Vector2(posX, posY);
    }

    public void SaveGame()
    {
        // ここにコードを追加する
        //playerの座標をセットする
        Vector3 currentPlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        m_saveData.posX = currentPlayerPos.x;
        m_saveData.posY = currentPlayerPos.y;

        string json = JsonUtility.ToJson(m_saveData, true);
        Debug.Log("シリアライズされた JSON データ: " + json);
        //PlayerPrefs.SetString(m_key, json);

        StreamWriter writer = new StreamWriter(m_path);
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    public void LoadGame()
    {
        // ここにコードを追加する
        //string json = PlayerPrefs.GetString(m_key);
        string json = "";
        StreamReader reader = new StreamReader(m_path);
        json = reader.ReadToEnd();
        reader.Close();
        m_saveData = JsonUtility.FromJson<SaveData>(json);

        Debug.Log(json);

        //playerの座標を更新する
        SpawnPlayer(m_saveData.posX, m_saveData.posY);
    }
}
