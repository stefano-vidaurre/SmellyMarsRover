namespace MarsRover;

// TODO: Large class
public class Rover
{
    private int _x;
    private int _y;
    private char _direction;
    // TODO: Temporary Field
    private readonly string _availableDirections = "NESW";
    private readonly string[] _obstacles;
    private bool _obstacleFound;

    // TODO: Long parameter list
    // TODO: Primitive obsession
    public Rover(int x, int y, char direction, string[] obstacles)
    {
        _x = x;
        _y = y;
        _direction = direction;
        _obstacles = obstacles;
    }
    
    // TODO: Primitive obsession
    public string GetState()
    {
        return !_obstacleFound ? $"{_x}:{_y}:{_direction}" : $"O:{_x}:{_y}:{_direction}";
    }

    // TODO: Primitive obsession
    // TODO: Long method
    // TODO: Comments
    // TODO: Divergent Change
    public void Execute(string commands)
    {
        foreach(char command in commands)
        {
            
            if (command == 'M')
            {
                // TODO: Switch statement
                switch (_direction)
                {
                    case 'E':
                        _obstacleFound = _obstacles.Contains($"{_x + 1}:{_y}");
                        // check if rover reached plateau limit or found an obstacle
                        _x = _x < 9 && !_obstacleFound ? _x += 1 : _x;
                        break;
                    case 'S':
                        _obstacleFound = _obstacles.Contains($"{_x}:{_y + 1}");
                        // check if rover reached plateau limit or found an obstacle
                        _y = _y < 9 && !_obstacleFound ? _y += 1 : _y;
                        break;
                    case 'W':
                        _obstacleFound = _obstacles.Contains($"{_x - 1}:{_y}");
                        // check if rover reached plateau limit or found an obstacle
                        _x = _x > 0 && !_obstacleFound ? _x -= 1 : _x;
                        break;
                    case 'N':
                        _obstacleFound = _obstacles.Contains($"{_x}:{_y - 1}");
                        // check if rover reached plateau limit or found an obstacle
                        _y = _y > 0 && !_obstacleFound ? _y -= 1 : _y;
                        break;
                }
            }
            else if(command == 'L')
            {
                // get new direction
                var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                if (currentDirectionPosition != 0)
                {
                    _direction = _availableDirections[currentDirectionPosition-1];
                }
                else
                {
                    _direction = _availableDirections[3];
                }
            } else if (command == 'R')
            {
                // get new direction
                var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                if (currentDirectionPosition != 3)
                {
                    _direction = _availableDirections[currentDirectionPosition+1];
                }
                else
                {
                    _direction = _availableDirections[0];
                }
            }
        }
    }
}