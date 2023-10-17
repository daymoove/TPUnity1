using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class grid : MonoBehaviour
{
    public int _width, _height;

    public GameObject _tilePrefab;

    public GameObject _wall;

    public GameObject _player;

    public GameObject _objecttopush;

    public GameObject _endpos;

    public GameObject _gamemanager;



    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {

        for (int x = 0; x < _width+1; x++)
        {
            for (int y = 0; y < _height+1; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x+transform.position.x, y+ transform.position.y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                if (x <= 0 || x >= _width || y<=0 || y >= _height)
                {
                    var spawnedwall = Instantiate(_wall, new Vector3(x + transform.position.x, y + transform.position.y), Quaternion.identity);
                    spawnedwall.name = $"Wall {x} {y}";
                }
            }
        }
        var spawnedplayer = Instantiate(_player, new Vector3(0, 0,-1), Quaternion.identity);
        spawnedplayer.name = "player";


        var spawnobjecttopush = Instantiate(_objecttopush, new Vector3(1, 1), Quaternion.identity);
        var spawnobjecttopush2 = Instantiate(_objecttopush, new Vector3(3, 3), Quaternion.identity);

        var spawnendpos = Instantiate(_endpos, new Vector3(2, -2), Quaternion.identity);
        var spawnendpos2 = Instantiate(_endpos, new Vector3(-3, 2), Quaternion.identity);

        var spawngamemanager = Instantiate(_gamemanager, new Vector3(0, 0), Quaternion.identity);

        
    }
}
