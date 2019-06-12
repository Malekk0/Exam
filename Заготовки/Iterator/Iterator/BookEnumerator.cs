using System;
using System.Collections.Generic;

namespace Iterator
{
    public class BookEnumerator : IBooksEnumerator
    {
        private int _pos = -1;
        private List<string> _booksList;

        public BookEnumerator(List<string> booksList)
        {
            _booksList = booksList;
        }

        public void MoveNext() //Обычно bool, чтобы знать, что конец списка
        {
            _pos = (_pos + 1) % _booksList.Count;
        }

        public void MovePrev()
        {
            _pos = _pos - 1;
            if (_pos < 0)
                _pos = _booksList.Count - 1;
        }

        public string Current
        {
            get
            {
                if (_pos < 0 || _pos >= _booksList.Count)
                    throw new InvalidOperationException();

                return _booksList[_pos];
            }
        }
    }
}
