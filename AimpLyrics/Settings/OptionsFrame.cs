using AIMP.SDK.Options;
using AIMP.SDK.Player;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable enable
namespace AimpLyrics.Settings
{
    public class OptionsFrame : IAimpOptionsDialogFrame, IAimpOptionsDialogFrameKeyboardHelper
    {
        private OptionsForm? _optionsForm;
        private readonly IAimpServiceOptionsDialog _optionsService;
        private readonly ILyricsPluginSettings _settings;

        public OptionsFrame(IAimpPlayer player)
        {
            _optionsService = player.ServiceOptionsDialog;
            _settings = new AimpLyricsPluginSettings(player.ServiceConfig);

            Application.EnableVisualStyles();
        }

        public string GetName() => "Lyrics";

        public IntPtr CreateFrame(IntPtr parentWindow)
        {
            _optionsForm = new OptionsForm();

            SetParent(_optionsForm.Handle, parentWindow);

            _optionsForm.OpenWindowOnInitCheckBox.Click += OnCheckBoxClick;
            _optionsForm.RestoreWindowHeightCheckBox.Click += OnCheckBoxClick;

            _optionsForm.Show();
            return _optionsForm.Handle;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void OnCheckBoxClick(object sender, EventArgs e)
        {
            _optionsService.FrameModified(this);
        }

        public void DestroyFrame()
        {
            _optionsForm?.Close();
            _optionsForm = null;
        }

        public void Notification(OptionsDialogFrameNotificationType notificationType)
        {
            switch (notificationType)
            {
                case OptionsDialogFrameNotificationType.AIMP_SERVICE_OPTIONSDIALOG_NOTIFICATION_LOAD:
                    if (_optionsForm != null)
                    {
                        _optionsForm.OpenWindowOnInitCheckBox.Checked = _settings.OpenWindowOnInitializing;
                        _optionsForm.RestoreWindowHeightCheckBox.Checked = _settings.RestoreWindowHeight;
                    }
                    break;

                case OptionsDialogFrameNotificationType.AIMP_SERVICE_OPTIONSDIALOG_NOTIFICATION_LOCALIZATION:
                    // set localization
                    break;

                case OptionsDialogFrameNotificationType.AIMP_SERVICE_OPTIONSDIALOG_NOTIFICATION_SAVE:
                    if (_optionsForm != null)
                    {
                        _settings.OpenWindowOnInitializing = _optionsForm.OpenWindowOnInitCheckBox.Checked;
                        _settings.RestoreWindowHeight = _optionsForm.RestoreWindowHeightCheckBox.Checked;
                    }
                    break;

                case OptionsDialogFrameNotificationType.AIMP_SERVICE_OPTIONSDIALOG_NOTIFICATION_CAN_SAVE:
                    break;
            }
        }

        #region IAimpOptionsDialogFrameKeyboardHelper
        public bool DialogKey(int charCode)
        {
            return true;
        }

        public bool SelectFirstControl()
        {
            return true;
        }

        public bool SelectNextControl(int findForward, int isTabKeyAction)
        {
            return true;
        }
        #endregion
    }
}
