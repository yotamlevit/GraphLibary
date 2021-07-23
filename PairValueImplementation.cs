using System;

namespace GraphLibary
{
    // interface to simple data struckture - contain a pair of vertices
    public class PairValueImplementation<T> : IPairValue<T>
    {
        private readonly T _t1;//first vertex
        private readonly T _t2;//second vetex

        //init
        public PairValueImplementation(T t1, T t2)
        {
            if (t1 == null || t2 == null)
                throw new ArgumentNullException();
            if (t1.GetType() != t2.GetType())
                throw new AccessViolationException();
            _t1 = t1;
            _t2 = t2;
        }

        //Returns true if givin value is storedin the data structure
        public bool Contains(T value)
        {
            return value.Equals(_t1) || value.Equals(_t2); 
        }

        //Returns the first vertex
        public T GetFirst()
        {
            return _t1;
        }

        //Returns the second vertex
        public T GetSecond()
        {
            return _t2;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(PairValueImplementation<T>))
                return false;
            PairValueImplementation<T> casted = (PairValueImplementation<T>)obj;
            return casted._t1.Equals(_t1) && casted._t2.Equals(_t2);
        }

        //returns the hash of t1 +t2
        public override int GetHashCode()
        {
            return _t1.GetHashCode() + _t2.GetHashCode();
        }
    }
}
