using System;
using System.Collections;
using System.Collections.Generic;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp.Utilities
{
    /// <summary>
    /// Represent a vector of specified generic data.
    /// </summary>
    internal class Vector<T> : IEnumerable<T>, IDisposable
    {
        internal class VectorElement
        {
            public double Weight { get; set; }
            public T Value { get; set; }
        }

        internal class VectorEnumerator : IEnumerator<T>
        {
            private Vector<T> Vector { get; set; }
            private int Index { get; set; }

            public T Current { get; set; }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public VectorEnumerator(Vector<T> vector)
            {
                this.Vector = vector;
                this.Index = 0;
                this.Current = this.Vector[this.Index].Value;
            }

            public void Dispose()
            {
                this.Vector = null;
                this.Current = default(T);
            }

            public bool MoveNext()
            {
                try
                {
                    this.Index++;
                    this.Current = this.Vector[this.Index].Value;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public void Reset()
            {
                this.Current = this.Vector[0].Value;
            }
        }

        private List<VectorElement> Data { get; set; }

        public virtual int Length
        {
            get
            {
                return this.Data.Count;
            }
        }

        public virtual VectorElement this[int index]
        {
            get
            {
                return this.Data[index];
            }
        }

        public Vector()
        {
            this.Data = new List<VectorElement>();
        }

        public virtual void Add(T data, double weight)
        {
            this.Data.Add(new VectorElement { Value = data, Weight = weight });
        }

        /// <summary>
        /// Returns the number of how many of specified value vector contains.
        /// </summary>
        public virtual int NumberOfContainedValues(T value)
        {
            int numberOfElementsInVector = 0;
            foreach (VectorElement data in this.Data)
            {
                if (data.Value.Equals(value))
                {
                    numberOfElementsInVector++;
                }
            }
            return numberOfElementsInVector;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new VectorEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Dispose()
        {
            this.Data = null;
        }

        public static Vector<T> FromDirection(T[][] matrix, Point startingPoint, int dx, int dy)
        {
            Vector<T> vector = new Vector<T>();
            int vectorX = startingPoint.X, vectorY = startingPoint.Y;
            bool canGoForward = true;

            while (canGoForward)
            {
                vectorX += dx;
                vectorY += dy;

                if ((vectorX < 0) || (vectorX >= matrix.Length))
                {
                    canGoForward = false;
                }
                else if ((vectorY < 0) || (vectorY >= matrix[0].Length))
                {
                    canGoForward = false;
                }
                else
                {
                    T cellValue = matrix[vectorX][vectorY];
                    double weight = Math.Abs(startingPoint.X - vectorX + 1) * Math.Abs(startingPoint.Y - vectorY + 1);
                    if (weight == 0)
                    {
                        weight = 1;
                    }
                    vector.Add(cellValue, weight);
                }
            }

            return vector;
        }

        public static Vector<T> FromDirectionPair(T[][] matrix, Point startingPoint, int dx, int dy)
        {
            Vector<T> v1 = FromDirection(matrix, startingPoint, dx, dy);
            Vector<T> v2 = FromDirection(matrix, startingPoint, -dx, -dy);
            Vector<T> vector = v1 + v2;
            return vector;
        }

        public static Vector<T> operator +(Vector<T> v1, Vector<T> v2)
        {
            Vector<T> vector = new Vector<T>();
            v1.Data.ForEach(data => vector.Add(data.Value, data.Weight));
            v2.Data.ForEach(data => vector.Add(data.Value, data.Weight));
            return vector;
        }
    }
}