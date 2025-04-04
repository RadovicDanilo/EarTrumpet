namespace EarTrumpet.UI.ViewModels
{
    public class EarTrumpetCommunitySettingsPageViewModel : SettingsPageViewModel
    {
        private readonly AppSettings _settings;
        public bool UseLogarithmicVolume
        {
            get => _settings.UseLogarithmicVolume;
            set => _settings.UseLogarithmicVolume = value;
        }
        
        public int DefaultVolume
        {
            get => _settings.DefaultVolume;
            set  
            {
                _settings.DefaultVolume = value;
                RaisePropertyChanged(nameof(DefaultVolume));
            }
        }

        public EarTrumpetCommunitySettingsPageViewModel(AppSettings settings) : base(null)
        {
            _settings = settings;
            Title = Properties.Resources.CommunitySettingsPageText;
            Glyph = "\xE902";
        }
    }
}