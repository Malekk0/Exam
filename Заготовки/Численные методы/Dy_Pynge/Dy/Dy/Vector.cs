using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dy
{
    class Vector
    {
        private double[] _vector;

        public int Length
        {
            get { return _vector.Length; }
        }

        public double this[int i]
        {
            get { return _vector[i]; }
            private set { _vector[i] = value; }
        }

        public Vector(double[] v)
        {
            _vector = new double[v.Length];
            for (int i = 0; i < v.Length; i++)
                _vector[i] = v[i];
        }
        
        public Vector(Vector v)
        {
            _vector = new double[v.Length];
            for (int i = 0; i < v.Length; i++)
                _vector[i] = v[i];
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            double[] d = new double[v1.Length];
            for (int i = 0; i < v1.Length; i++)
                d[i] = v1[i] + v2[i];

            return new Vector(d);
        }

        public static Vector operator *(double c, Vector v2)
        {
            double[] d = new double[v2.Length];
            for (int i = 0; i < v2.Length; i++)
                d[i] = c * v2[i];

            return new Vector(d);
        }
    }
}
