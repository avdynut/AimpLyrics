namespace Aimp4.Api
{
    public enum AIMPWindowMessage
    {
        WM_USER = 0x0400,
        // Messages, which you can send to window with "AIMPRemoteAccessClass" class
        // You can receive Window Handle via FindWindow function (see MSDN for details)
        WM_AIMP_COMMAND = WM_USER + 0x75,
        WM_AIMP_NOTIFY = WM_USER + 0x76,
        WM_AIMP_PROPERTY = WM_USER + 0x77,

        // See AIMP_RA_CMD_GET_ALBUMART command
        WM_AIMP_COPYDATA_ALBUMART_ID = 0x41495043,
    }
}