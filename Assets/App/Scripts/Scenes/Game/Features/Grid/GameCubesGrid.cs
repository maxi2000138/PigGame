using System.Collections.Generic;
using App.Scripts.Features.Cube;
using UnityEngine;

public class GameCubesGrid
{
    public Vector2Int Size { get; private set; }
    
    private GameCubeUnit[][] _matrix;
    private readonly List<GameCubeUnit> _units = new();
    
    public void Resize(Vector2Int size)
    {
        Size = size;
        
        _matrix = new GameCubeUnit[size.y][];
        for (var i = 0; i < size.y; i++) _matrix[i] = new GameCubeUnit[size.x];
    }

    public void SetAt(int i, int j, GameCubeUnit unit)
    {
        if (_matrix[i][j] != null) throw new ExceptionGameCubesGrid("cell not empty");

        if (_units.Contains(unit)) throw new ExceptionGameCubesGrid("unit already at grid");

        _matrix[i][j] = unit;
        unit.CellPosition = new Vector2Int(j, i);

        _units.Add(unit);
    }
    
    public void RemoveAt(int i, int j)
    {
        if (_matrix[i][j] == null) throw new ExceptionGameCubesGrid("cell empty");
        
        _units.Remove(_matrix[i][j]);
        _matrix[i][j] = null;
    }
}
