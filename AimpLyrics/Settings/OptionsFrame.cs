using Aimp4.Api;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AimpLyrics.Settings
{
    public class OptionsFrame : IAIMPOptionsDialogFrame, IAIMPOptionsDialogFrameKeyboardHelper
    {
        private OptionsForm _optionsForm;

        public OptionsFrame()
        {
            Application.EnableVisualStyles();
        }

        public IAIMPString GetName()
        {
            var aimpString = AimpLyricsPlugin.Core.CreateString("Lyrics");
            Task.Delay(200).ContinueWith(t => aimpString?.ReleaseComObject());  // костыль, да не будет утечки памяти, аминь
            return aimpString;
        }

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
            var optionsService = AimpLyricsPlugin.Core.GetService<IAIMPServiceOptionsDialog>();
            optionsService.FrameModified(this);
        }

        public void DestroyFrame()
        {
            _optionsForm?.Close();
            _optionsForm = null;
        }

        public void Notification(AIMPOptionsDialogNotification notificationType)
        {
            var settings = new AimpLyricsPluginSettings();

            switch (notificationType)
            {
                case AIMPOptionsDialogNotification.Load:
                    if (_optionsForm != null)
                    {
                        _optionsForm.OpenWindowOnInitCheckBox.Checked = settings.OpenWindowOnInitializing;
                        _optionsForm.RestoreWindowHeightCheckBox.Checked = settings.RestoreWindowHeight;
                    }
                    break;

                case AIMPOptionsDialogNotification.Localization:
                    // set localization
                    break;

                case AIMPOptionsDialogNotification.Save:
                    if (_optionsForm != null)
                    {
                        settings.OpenWindowOnInitializing = _optionsForm.OpenWindowOnInitCheckBox.Checked;
                        settings.RestoreWindowHeight = _optionsForm.RestoreWindowHeightCheckBox.Checked;
                    }
                    break;

                case AIMPOptionsDialogNotification.CanSave:
                    break;
            }
        }

        #region IAimpOptionsDialogFrameKeyboardHelper
        [return: MarshalAs(UnmanagedType.Bool)]
        public bool DialogChar(char charCode, int unused)
        {
            return true;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        public bool DialogKey(ushort charCode, int unused)
        {
            return true;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        public bool SelectNextControl([MarshalAs(UnmanagedType.Bool)] bool findForward, [MarshalAs(UnmanagedType.Bool)] bool checkTabStop)
        {
            return true;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        public bool SelectFirstControl()
        {
            return true;
        }
        #endregion
    }
}
