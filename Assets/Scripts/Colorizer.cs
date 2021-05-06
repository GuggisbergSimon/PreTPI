using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Class colorizing mesh renderers
/// </summary>
public class Colorizer : MonoBehaviour
{
    private enum ColorMode
    {
        Cycle,
        PingPong,
        Random
    }

    [SerializeField] private ColorMode colorMode = ColorMode.Cycle;
    [SerializeField] private MeshRenderer[] objectsToColorized = default;
    [SerializeField] private Color[] materialsToCycleThrough = default;
    private int _currentMat;
    private bool _isAscending;

    private void Awake()
    {
        ChangeMat();
    }

    /// <summary>
    /// Colorize the mesh renderers based on the parameters chosen in the inspector
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Colorize()
    {
        switch (colorMode)
        {
            case ColorMode.Cycle:
                _currentMat = (_currentMat + 1) % materialsToCycleThrough.Length;
                break;
            case ColorMode.PingPong:
                _currentMat += _isAscending ? 1 : -1;
                if (_currentMat < 0)
                {
                    _isAscending = true;
                }
                else if (_currentMat >= materialsToCycleThrough.Length)
                {
                    _isAscending = false;
                }
                _isAscending = _currentMat < 0;
                int range = materialsToCycleThrough.Length - 1;
                _currentMat = Mathf.Abs((_currentMat + range) % (range * 2) - range);
                break;
            case ColorMode.Random:
                _currentMat = Random.Range(0, materialsToCycleThrough.Length);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        ChangeMat();
    }

    private void ChangeMat()
    {
        foreach (var obj in objectsToColorized)
        {
            obj.material.color = materialsToCycleThrough[_currentMat];
        }
    }
}