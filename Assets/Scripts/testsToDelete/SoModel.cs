using UnityEngine;

[CreateAssetMenu(fileName = "TestSo", menuName = "ScriptableObjects/Test", order = 1)]
public class SoModel : ScriptableObject
{
    public string nameSo;
    public int testSo;
    public Vector3[] testsSo;
}