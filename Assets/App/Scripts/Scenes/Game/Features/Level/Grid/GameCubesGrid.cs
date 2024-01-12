using System.Collections.Generic;
using App.Scripts.Features.Cube;
using UnityEngine;

public class GameCubesGrid
{
    public Vector2Int Size { get; private set; }
    
    private GameBlockUnit[][] _matrix;
    private readonly List<GameBlockUnit> _units = new();

    public bool IsValidPosition(Vector2Int position) => position.x >= 0 && position.x < Size.x && position.y >= 0 && position.y < Size.y;

    public void Resize(Vector2Int size)
    {
        Size = size;
        
        _matrix = new GameBlockUnit[size.y][];
        for (var i = 0; i < size.y; i++) _matrix[i] = new GameBlockUnit[size.x];
    }

    public bool TryGeteAt(Vector2Int position, out GameBlockUnit gameBlockUnit)
    {
        if (_matrix[position.x][position.y] != null)
        {
            gameBlockUnit = _matrix[position.x][position.y];
            return true;
        }

        gameBlockUnit = null;
        return false;
    }

    public void SetAt(int i, int j, GameBlockUnit unit)
    {
        if (_matrix[i][j] != null) throw new ExceptionGameCubesGrid("cell not empty");

        if (_units.Contains(unit)) throw new ExceptionGameCubesGrid("unit already at grid");

        _matrix[i][j] = unit;
        unit.CellPosition = new Vector2Int(j, i);

        _units.Add(unit);
    }
    
    public void RemoveAt(Vector2Int position)
    {
        if (_matrix[position.x][position.y] == null) throw new ExceptionGameCubesGrid("cell empty");
        
        _units.Remove(_matrix[position.x][position.y]);
        _matrix[position.x][position.y] = null;
    }
}
