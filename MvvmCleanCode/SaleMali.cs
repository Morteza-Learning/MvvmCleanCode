using MvvmCleanCode.Properties;

namespace MvvmCleanCode
{
    public class SaleMali 
    {
        public SaleMali()
        {
        }
        public SaleMali(string salJadid)
        {
            CurrentSalMali = salJadid;
        }
        public string CurrentSalMali 
        { 
            get { return Settings.Default.DatabaseName; }
            private set
            {
                if (!isCurrentSalMali(value))
                {
                    ChangeSalMali(value);
                }
                
            }
        }
        
        public void ChangeSalMali(string value)
        {
            Settings.Default.DatabaseName = value;
            Settings.Default.Save();
            Settings.Default.Reload();
        }
        
        public bool isCurrentSalMali(string changeSal)
        {
            return changeSal == Settings.Default.DatabaseName;
        }
        
    }
}
