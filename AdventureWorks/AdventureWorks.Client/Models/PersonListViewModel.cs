using System.Collections;

namespace AdventureWorks.Client.Models
{
    public class PersonListViewModel : ICollection<PersonViewModel>
    {
        private readonly List<PersonViewModel> _list;

        public PersonListViewModel()
        {
            _list = new List<PersonViewModel>();
        }

        public PersonListViewModel(IEnumerable<PersonViewModel> seed)
        {
            _list = seed.ToList();
        }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(PersonViewModel item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(PersonViewModel item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(PersonViewModel[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<PersonViewModel> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(PersonViewModel item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
