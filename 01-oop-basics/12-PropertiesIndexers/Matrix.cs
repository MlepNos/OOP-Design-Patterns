// Matrix.cs
namespace PropertiesIndexersDemo
{
    // Shows: multi-parameter indexer `this[int r, int c]`
    class Matrix
    {
        private readonly double[,] _data;

        public int Rows { get; }
        public int Cols { get; }

        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0) throw new ArgumentException("Positive size required.");
            Rows = rows; Cols = cols;
            _data = new double[rows, cols];
        }

        public double this[int r, int c]
        {
            get
            {
                BoundsCheck(r, c);
                return _data[r, c];
            }
            set
            {
                BoundsCheck(r, c);
                _data[r, c] = value;
            }
        }

        private void BoundsCheck(int r, int c)
        {
            if (r < 0 || r >= Rows) throw new IndexOutOfRangeException(nameof(r));
            if (c < 0 || c >= Cols) throw new IndexOutOfRangeException(nameof(c));
        }

        // Expression-bodied property
        public bool IsSquare => Rows == Cols;

        public override string ToString()
        {
            var lines = new List<string>();
            for (int r = 0; r < Rows; r++)
            {
                var row = new List<string>();
                for (int c = 0; c < Cols; c++) row.Add(this[r, c].ToString("0.##"));
                lines.Add(string.Join("\t", row));
            }
            return string.Join(Environment.NewLine, lines);
        }
    }
}
