using Data;

namespace Core
{
    public class Service : IService
    {
        private IRepository repository;

        public Service(IRepository _repository)
        {
            this.repository = _repository;
        }

        public string GetData()
        {
            return repository.GetMyDataFromDb().Title;
        }

        public void Save(string title)
        {
            repository.SaveDataToDb(title);
        }
    }
}