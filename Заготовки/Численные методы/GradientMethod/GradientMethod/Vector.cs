namespace GradientMethod
{
    public class Vector
    {
        public double this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public int size { get; private set; }

        private double[] array;

        public Vector(Vector v)
        {
            size = v.size;
            array = new double[size];
            for (int i = 0; i < size; i++)
                array[i] = v[i];
        }

        public Vector(double[] arr)
        {
            size = arr.Length;
            array = new double[size];
            for (int i = 0; i < size; i++)
                array[i] = arr[i];
        }

        public Vector(int size)
        {
            this.size = size;
            array = new double[size];
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector v = new Vector(v1);
            for (int i = 0; i < v1.size; i++)
                v[i] -= v2[i];

            return v;
        }

        public static Vector operator *(Vector v1, double x)
        {
            Vector v = new Vector(v1);
            for (int i = 0; i < v1.size; i++)
                v[i] *= x;

            return v;
        }

        public static Vector operator *(double x, Vector v1)
        {
            Vector v = new Vector(v1);
            for (int i = 0; i < v1.size; i++)
                v[i] *= x;

            return v;
        }

        public override string ToString()
        {
            return $"({string.Join(", ", array)})";
        }
    }
}
