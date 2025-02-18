using UnityEngine;

public class Stopwatch
{
    private float _startTime;
    private float _elapsedTime;
    private bool _isRunning;

    // Constructor
    public Stopwatch()
    {
        Reset();
    }

    // Start the stopwatch
    public void Start()
    {
        if (!_isRunning)
        {
            _startTime = Time.time - _elapsedTime;
            _isRunning = true;
        }
    }

    // Stop the stopwatch
    public void Stop()
    {
        if (_isRunning)
        {
            _elapsedTime = Time.time - _startTime;
            _isRunning = false;
        }
    }

    // Reset the stopwatch
    public void Reset()
    {
        _elapsedTime = 0f;
        _isRunning = false;
    }

    // Get the elapsed time in seconds
    public float GetElapsedTime()
    {
        if (_isRunning)
        {
            return Time.time - _startTime;
        }
        return _elapsedTime;
    }

    // Check if the stopwatch is running
    public bool IsRunning()
    {
        return _isRunning;
    }
}