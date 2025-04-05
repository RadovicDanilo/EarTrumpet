using EarTrumpet.UI.Helpers;

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
        
        private readonly DebounceDispatcher _debouncer = new DebounceDispatcher(); 

        // Holds latest UI value before debounce finishes (used for immediate binding updates)
        private int _pendingDefaultVolume;

        public int DefaultVolume
        {
            get => _pendingDefaultVolume;
            set
            {
                if (_pendingDefaultVolume == value) return;
        
                _pendingDefaultVolume = value;
                // Notify UI immediately (text updates instantly)
                RaisePropertyChanged(nameof(DefaultVolume)); 
        
                // Delay applying volume changes to avoid excessive updates during dragging
                _debouncer.Debounce(250, () =>
                {
                    _settings.DefaultVolume = _pendingDefaultVolume;
                    // TODO: update app volumes
                });
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