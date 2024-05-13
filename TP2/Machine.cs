using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2;

public class Machine
{
    private int x;
    private int y;

public Machine(int x, int y)
{
    SetPosition(x, y);
}

public (int, int) GetCurrentPosition()
{
    return (x, y);
}

public void Move(int dx, int dy)
{
    x += dx;
    y += dy;
}

public bool CanMount((int, int) blockPosition)
{
    return GetCurrentPosition() == blockPosition;
}

public void SetPosition(int x, int y)
{
    this.x = x;
    this.y = y;
}
}
