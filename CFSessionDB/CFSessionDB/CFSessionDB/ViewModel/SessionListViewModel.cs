using CFSessionDB.Data;
using CFSessionDB.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CFSessionDB.ViewModel
{
	public class SessionListViewModel : INotifyPropertyChanged
	{
        Database _database = new Database();
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Session> _sessionsList;

        public ObservableCollection<Session> SessionsList
        {
            get { return _sessionsList; }
            set
            {
                _sessionsList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SessionsList"));
            }
        }
        public async Task FetchDataAsync()
        {
            var list = await _database.GetAllSessionAsync();
            SessionsList = new ObservableCollection<Session>(list);

        }
        public SessionListViewModel()
        {
            FetchDataAsync();
        }


	}
}