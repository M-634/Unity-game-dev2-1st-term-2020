using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;    // ファイルを操作するために必要

public class SaveText : MonoBehaviour
{
    [SerializeField] string m_string = "あいうえおかきくけこさしすせそたちつてと";
    /// <summary>データを保存するファイルのパス</summary>
    string m_path;

    private void Start()
    {
        m_path = Application.dataPath + "/text.txt";
    }

    /// <summary>テキストをファイルに保存する</summary>
    public void Save()
    {
        StreamWriter writer = new StreamWriter(m_path);
        writer.Write(m_string);
        writer.Flush();
        writer.Close();
    }

    /// <summary>ファイルからテキストを読み込む</summary>
    public void Load()
    {
        string text = "";
        StreamReader reader = new StreamReader(m_path);
        text = reader.ReadToEnd();
        reader.Close();
        Debug.Log(text);
    }
}
