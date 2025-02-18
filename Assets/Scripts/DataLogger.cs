using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLogger : MonoBehaviour
{
    // Singleton instance
    private static DataLogger _instance;
    public static DataLogger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DataLogger>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("DataLogger");
                    _instance = singletonObject.AddComponent<DataLogger>();
                }
            }
            return _instance;
        }
    }

    private string _filePath;
    private List<string> _dataLines = new List<string>();

    private void Awake()
    {
        // Ensure only one instance exists
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scene changes

        // Set the file path in the persistent data directory
        _filePath = Path.Combine(Application.persistentDataPath, "runtime_data.txt");

        // Log the file path for debugging
        Debug.Log("Data will be saved to: " + _filePath);
    }

    public void LogData(string data)
    {
        // Add a timestamp to the data
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        string dataLine = $"{timestamp}, {data}";

        // Add the data line to the list
        _dataLines.Add(dataLine);
    }
    

    public void SaveDataToFile()
    {
        // Write all data lines to the file
        using (StreamWriter writer = new StreamWriter(_filePath, true)) // Append mode
        {
            foreach (string line in _dataLines)
            {
                writer.WriteLine(line);
            }
        }

        // Clear the data lines after saving
        _dataLines.Clear();

        Debug.Log("Data saved to file.");
    }

    // private void OnApplicationQuit()
    // {
    //     // Save any remaining data when the app quits
    //     SaveDataToFile();
    // }
}