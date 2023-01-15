using UnityEngine;
using UnityEngine.UI;

public class UIUnitSelect : MonoBehaviour
{
    public UnitType UnitType;
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(ChangeSpawnedUnitType);
    }

    private void ChangeSpawnedUnitType()
    {
        SpawnController.UnitType = UnitType;
    }
}
