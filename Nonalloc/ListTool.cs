using System;
using System.Collections.Generic;

namespace Euclase.Nonalloc {
    public class ListTool<T> {

        private List<T> _temp;
        private List<T> _result;
        //private List<T> _rresult;

        public ListTool() {
            _temp = new List<T>();
            _result = new List<T>();
        }

        public ListTool<T> From(List<T> list) {
            //_result = _rresult;
            _result.Clear();
            foreach(var l in list)
                _result.Add(l);

            return this;
        }

        public ListTool<T> From(List<T> list, ref List<T> result) {
            if(result == null)
                result = new List<T>();

            _result = result;
            _result.Clear();

            foreach(var l in list)
                _result.Add(l);

            return this;
        }

        private void MoveToTemp(ref List<T> list) {
            _temp.Clear();

            foreach(var l in list)
                _temp.Add(l);

            list.Clear();
        }

        public ListTool<T> Where(Func<T, bool> predicate) {
            MoveToTemp(ref _result);
            foreach(T obj in _temp) {
                if(predicate(obj))
                    _result.Add(obj);
            }
            return this;
        }

        public ListTool<T> Except(List<T> second) {
            MoveToTemp(ref _result);
            foreach(T obj in _temp) {
                if(second.IndexOf(obj) == -1)
                    _result.Add(obj);
            }
            return this;
        }

        public ListTool<T> Intersect(List<T> second) {
            MoveToTemp(ref _result);
            foreach(T obj in _temp) {
                if(second.IndexOf(obj) != -1)
                    _result.Add(obj);
            }
            return this;
        }

        public ListTool<T> Union(List<T> second) {
            foreach(T obj in second)
                if(_result.IndexOf(obj) == -1)
                    _result.Add(obj);
            return this;
        }

        public ListTool<T> Concat(List<T> second) {
            foreach(T obj in second)
                _result.Add(obj);
            return this;
        }

        public ListTool<T> Select<R>(ref List<R> result, Func<T, R> selector) {
            foreach(T obj in _result)
                result.Add(selector(obj));

            return this;
        }

        public ListTool<T> SelectMany<R>(ref List<R> result, Func<T, IEnumerable<R>> selector) {
            foreach(T obj in _result) 
                foreach(R rObj in selector(obj)) 
                    result.Add(rObj);

            return this;
        }

        public ListTool<T> Cast<R>(ref List<R> result) {
            foreach(object obj in _result)
                result.Add((R)obj);

            return this;
        }

        public List<T> ToList() {
            return _result;
        }

        public T FirstOrDefault() {
            if(_temp.Count == 0)
                return default(T);

            return _temp[0];
        }

        public void CopyTo(ref List<T> list) {
            foreach(var l in _result)
                list.Add(l);
        }

    }
}
