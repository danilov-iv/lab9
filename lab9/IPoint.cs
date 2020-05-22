using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class IPoint
    {
        public int _rad;
        public int _x;
        public int _y;
        public int _sx;
        public int _sy;
        public int _vx;
        public int _vy;
        public double k;
        int _maxx;
        int _maxy;
        public int _num;
        public int _svx;
        public int _svy;
        public IPoint(int rad, int x, int y, int vx, int vy, int maxx, int maxy, int num)
        {
            _rad = rad;
            _x = x;
            _y = y;
            _vx = vx;
            _vy = vy;
            _svx = vx;
            _svy = vy;
            _maxx = maxx;
            _maxy = maxy;
            _num = num;
        }
        public void Update(IPoint[] Arr)
        {
            foreach (var i in Arr)
            {
                if (i._num != _num)
                {
                    if (Math.Abs((_x) - (i._sx)) <= _rad && Math.Abs((_y) - (i._sy)) <= _rad)
                    {
                        _vx = i._svx;
                        _vy = i._svy;
                    }
                }
            }
            if (_x + _vx + _rad >= _maxx || _x + _vx - _rad <= 0)
            {
                _vx = -_vx;
            }
            if (_y + _vy + _rad >= _maxy || _y + _vy - _rad <= 0)
            {
                _vy = -_vy;
            }
            _x += _vx;
            _y += _vy;
        }
        public bool Chek(int rad, int x, int y, List<IPoint> Arr)
        {
            foreach (var i in Arr)
            {
                if (Math.Abs((x) - (i._x)) <= _rad && Math.Abs((y) - (i._y)) <= _rad)
                {
                    return false;
                }
            }
            return true;

        }
        public void ChSpd(int k)
        {
            if (_vx >= 0)
            {
                if (_vx + k > 0)
                {
                    _vx = _vx + k;
                    _svx = _vx + k;
                }
                else
                {
                    _vx = 0;
                    _svx = 0;
                }
            }
            else
            {
                if (_vx + k < 0)
                {
                    _vx = _vx - k;
                    _svx = _vx - k;
                }
                else
                {
                    _vx = 0;
                    _svx = 0;
                }
            }
            if (_vy >= 0)
            {
                if (_vy + k > 0)
                {
                    _vy = _vy + k;
                    _svy = _vy + k;
                }
                else
                {
                    _vy = 0;
                    _svy = 0;
                }
            }
            else
            {
                if (_vy + k < 0)
                {
                    _vy = _vy - k;
                    _svy = _vy - k;
                }
                else
                {
                    _vy = 0;
                    _svy = 0;
                }
            }
        }
    }
}