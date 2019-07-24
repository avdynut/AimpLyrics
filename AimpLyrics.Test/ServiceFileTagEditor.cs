using AIMP.SDK;
using AIMP.SDK.FileManager;
using AIMP.SDK.TagEditor;
using System;

namespace AimpLyrics.Test
{
    public class ServiceFileTagEditor : IAimpServiceFileTagEditor
    {
        public AimpActionResult EditFile(string filePath, out IAimpFileTagEditor editor)
        {
            editor = null;
            return AimpActionResult.NotImplemented;
        }

        public AimpActionResult EditFile(IAimpStream fileStream, out IAimpFileTagEditor editor)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult EditTag(string filePath, TagType tag, out IAimpFileInfo fileInfo)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult EditTag(IAimpStream fileStream, TagType tag, out IAimpFileInfo fileInfo)
        {
            throw new NotImplementedException();
        }
    }
}
