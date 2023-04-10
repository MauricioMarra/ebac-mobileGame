using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public SOLevelPiece _levelSetup;

    [SerializeField] private List<GameObject> _levelPieces;
    [SerializeField] private GameObject _startPiece;
    [SerializeField] private GameObject _endPiece;
    [SerializeField] private GameObject _levelContainer;
    
    private GameObject _currentPiece;

    private float _sizeOfPiece = 10f;
    private int _numberOfPieces = 10;
    private string _endOfPieceString = "EndOfPiece";

    [SerializeField] int pieceIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _currentPiece = Instantiate(_startPiece, _levelContainer.transform);

        CreateLevel();

        var endPiece = Instantiate(_endPiece, _levelContainer.transform);
        endPiece.transform.position = _currentPiece.transform.position + new Vector3(0,0,_sizeOfPiece);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevelPiece()
    {
        var position = Vector3.zero;

        if (_currentPiece != null)
        {
            _sizeOfPiece = _currentPiece.transform.Find(_endOfPieceString).transform.localPosition.z;
            position = new Vector3(_currentPiece.transform.position.x, _currentPiece.transform.position.y, _currentPiece.transform.position.z + _sizeOfPiece);
        }

        _currentPiece = Instantiate(_levelPieces[Random.Range(0, _levelPieces.Count)], _levelContainer.transform);
        _currentPiece.transform.position = position;

        var artObjects = _currentPiece.GetComponentsInChildren<ArtContainer>();

        foreach (var element in artObjects)
        {
            var obj = ArtManager.instance.GetArtByType(_levelSetup.ArtType);

            element.ChangeArtGameObject(Instantiate(obj, element.transform));
        }

        ColorManager.instance.ChangeColorOfObjects(_levelSetup.ArtType);
    }

    private void CreateLevel()
    {
        for (var i=0; i< _numberOfPieces - 1; i++)
        {
            CreateLevelPiece();
        }
    }
}
