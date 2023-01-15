using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    public static UnitType UnitType = UnitType.KnightPelegrini;

    [SerializeField] private List<PrefabUnitData> _prefabUnitDates;
    [SerializeField] private List<SpriteUnitData> _spriteUnitDates;

    [SerializeField] private Transform _unitContainer;

    [SerializeField] private UIUnitSelect _cardPrefab;
    [SerializeField] private Transform _cardTransform;

    [SerializeField] private Button _spawnButton;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _clearButton;

    [SerializeField] private TMP_Text _unitCountText;

    private List<GameObject> _units;

    private void Start()
    {
        _units = new List<GameObject>();
        _spawnButton.onClick.AddListener(SpawnUnit);
        _deleteButton.onClick.AddListener(DeleteUnit);
        _clearButton.onClick.AddListener(ClearUnit);
        _unitCountText.text = "0";
        CreateCards();
    }

    private void CreateCards()
    {
        foreach (var spriteUnit in _spriteUnitDates)
        {
            var card = Instantiate(_cardPrefab, _cardTransform);
            card.GetComponent<Image>().sprite = spriteUnit.Sprite;
            card.UnitType = spriteUnit.Type;
        }
    }

    private void SpawnUnit()
    {
        foreach (var prefabUnit in _prefabUnitDates)
        {
            if (prefabUnit.Type == UnitType)
            {
                var unit = Instantiate(prefabUnit.Prefab, _unitContainer);
                unit.transform.position = new Vector3(Random.Range(4.5f, -4.5f), 0.5f, Random.Range(4.5f, -4.5f));
                _units.Add(unit);
            }
        }

        _unitCountText.text = _units.Count.ToString();
    }

    private void DeleteUnit()
    {
        Destroy(_units[_units.Count-1]);
        _units.Remove(_units[_units.Count-1]);
        _unitCountText.text = _units.Count.ToString();
    }

    private void ClearUnit()
    {
        foreach (var unit in _units)
        {
            Destroy(unit);
        }

        _units.Clear();
        _unitCountText.text = _units.Count.ToString();
    }
}

[Serializable]
public class PrefabUnitData
{
    public UnitType Type;
    public GameObject Prefab;
}

[Serializable]
public class SpriteUnitData
{
    public UnitType Type;
    public Sprite Sprite;
}